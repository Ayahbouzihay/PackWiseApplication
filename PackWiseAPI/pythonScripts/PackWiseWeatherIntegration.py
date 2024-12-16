# Weather Data Retrieval and Storage Script
# This script fetches weather data, generates packing recommendations,
# and stores the data in a PostgreSQL database.

# Import required libraries
from geopy.geocoders import Nominatim
import requests
import DBConnector
import json
import sys
from datetime import datetime

# Initialize the database connection
my_db = DBConnector.MyDB()

def create_weather_table():
    sqlCommand = """
    CREATE TABLE IF NOT EXISTS Weather (
        id SERIAL PRIMARY KEY,
        city VARCHAR(255) NOT NULL,
        state VARCHAR(255) NOT NULL,
        name VARCHAR(255),
        date DATE NOT NULL,
        temperature VARCHAR(50),
        wind_speed VARCHAR(50),
        wind_direction VARCHAR(50),
        forecast TEXT,
        humidity VARCHAR(50),
        precipitation VARCHAR(50),
        recommendation TEXT
    );
    """
    try:
        my_db.query(sqlCommand, '')
        print("Table Weather created successfully. Please access pgAdmin to verify table creation.")
    except Exception as e:
        print(f"An error occurred while creating the table: {e}")

# Fetch weather data from NOAA API
def get_weather_data(latitude, longitude):
    """Fetch weather data from NOAA's National Weather Service API."""
    headers = {'User-Agent': 'YourAppName (your.email@example.com)'}  # Replace with valid info
    points_url = f"https://api.weather.gov/points/{latitude},{longitude}"
    response = requests.get(points_url, headers=headers)
    response.raise_for_status()
    data = response.json()

    forecast_url = data['properties']['forecast']
    hourly_forecast_url = data['properties']['forecastHourly']

    forecast_response = requests.get(forecast_url, headers=headers)
    forecast_response.raise_for_status()
    forecast_data = forecast_response.json()

    hourly_forecast_response = requests.get(hourly_forecast_url, headers=headers)
    hourly_forecast_response.raise_for_status()
    hourly_forecast_data = hourly_forecast_response.json()

    return forecast_data, hourly_forecast_data

# Extract and structure weather data
def extract_detailed_weather(forecast_data, hourly_forecast_data):
    weather_details = []
    for daily_period in forecast_data['properties']['periods']:
        details = {
            "name": daily_period['name'],
            "start_time": daily_period['startTime'],
            "end_time": daily_period['endTime'],
            "temperature": f"{daily_period['temperature']}\u00b0{daily_period['temperatureUnit']}",
            "wind_speed": daily_period['windSpeed'],
            "wind_direction": daily_period['windDirection'],
            "forecast": daily_period['shortForecast']
        }
        weather_details.append(details)

    for i, hourly_period in enumerate(hourly_forecast_data['properties']['periods'][:len(weather_details)]):
        humidity = hourly_period.get('relativeHumidity', {}).get('value', 'N/A')
        precipitation = hourly_period.get('probabilityOfPrecipitation', {}).get('value', 'N/A')
        weather_details[i]["humidity"] = f"{humidity}%" if humidity != 'N/A' else "N/A"
        weather_details[i]["precipitation"] = f"{precipitation}%" if precipitation != 'N/A' else "N/A"

    return weather_details

# Generate packing recommendations based on weather conditions
def generate_recommendations(weather_detail):
    recommendations = []
    if "rain" in weather_detail['forecast'].lower():
        recommendations.append("Pack an umbrella or a raincoat.")
    if "snow" in weather_detail['forecast'].lower():
        recommendations.append("Wear warm clothes and carry snow boots.")
    if "hot" in weather_detail['forecast'].lower() or int(weather_detail['temperature'].split('\u00b0')[0]) > 85:
        recommendations.append("Carry light clothing and stay hydrated.")
    if "cold" in weather_detail['forecast'].lower() or int(weather_detail['temperature'].split('\u00b0')[0]) < 50:
        recommendations.append("Dress warmly and carry gloves.")
    return " ".join(recommendations)

# Store weather data in PostgreSQL
def store_weather_data(city, state, date, weather_details):
    for detail in weather_details:
        recommendation = generate_recommendations(detail)
        forecast_date = detail['start_time'][:10]  # Extract YYYY-MM-DD from the start_time
        sqlCommand = """
        INSERT INTO Weather (city, state, name, date, temperature, wind_speed, wind_direction, forecast, humidity, precipitation, recommendation)
        VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s);
        """
        params = (
            city,
            state,
            detail['name'],
            forecast_date,
            detail['temperature'],
            detail['wind_speed'],
            detail['wind_direction'],
            detail['forecast'],
            detail['humidity'],
            detail['precipitation'],
            recommendation
        )
        try:
            my_db.query(sqlCommand, params)
            print(f"Weather data for {detail['name']} on {forecast_date} inserted successfully.")
        except Exception as e:
            print(f"An error occurred while inserting data: {e}")
        
# Geocode city to latitude and longitude
def get_latitude_longitude(city):
    geolocator = Nominatim(user_agent="weather_app")
    location = geolocator.geocode(city)
    if location:
        return location.latitude, location.longitude
    else:
        raise Exception(f"Could not find location for city: {city}")

# Main function to coordinate the process
def main(city, state, date):
    try:
        # Validate date format (YYYY-MM-DD)
        try:
            datetime.strptime(date, "%Y-%m-%d")
        except ValueError:
            raise ValueError("Invalid date format. Use YYYY-MM-DD.")

        latitude, longitude = get_latitude_longitude(city)
        create_weather_table()
        print(f"Fetching weather data for {city}, {state} on {date}...")

        forecast_data, hourly_forecast_data = get_weather_data(latitude, longitude)
        weather_details = extract_detailed_weather(forecast_data, hourly_forecast_data)

        # Print forecast details
        print("\nWeather Forecast Details:")
        for detail in weather_details:
            print(f"Forecast Name: {detail['name']}")
            print(f"Temperature: {detail['temperature']}")
            print(f"Wind Speed: {detail['wind_speed']}")
            print(f"Wind Direction: {detail['wind_direction']}")
            print(f"Forecast: {detail['forecast']}")
            print(f"Humidity: {detail['humidity']}")
            print(f"Precipitation: {detail['precipitation']}")
            print(f"Recommendations: {generate_recommendations(detail)}")
            print("--------------------------------------------------")

        store_weather_data(city, date, state, weather_details)  # Pass city, date, weather details to store_weather_data
        
        # Convert the weather details to JSON
        weather_json = json.dumps(weather_details, indent=4)
        print("\nFull Weather JSON Data:")
        print(weather_json)  # Print the JSON data to the output
    except Exception as e:
        print(f"An error occurred: {e}")

# Example usage
if __name__ == "__main__":
    # Extract city, state, and date from command-line arguments
    if len(sys.argv) < 4:
        print("Usage: python script.py <city> <date> <state>")
        sys.exit(1)
    
    city = sys.argv[1]  # City (e.g., "Morgantown")
    date = sys.argv[2]  # Date (e.g., "2024-12-16")
    state = sys.argv[3]  # State (e.g., "WV")

    main(city, state, date)
