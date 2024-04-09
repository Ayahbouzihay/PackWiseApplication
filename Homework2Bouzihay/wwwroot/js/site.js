// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

async function displayTripCat(categoryName) {
    const response = await fetch(`https://localhost:7270/api/SelectTrip/${categoryName}`);
    const data = await response.json();
    document.getElementById('TripName').innerHTML = data[0].categoryName;
    document.getElementById('TripName').style.visibility = "visible";
}

async function DateResults(date) {
    const response = await fetch(`https://localhost:7270/api/InputTripDates/${date}`);
    const data = await response.json();
    document.getElementById('date').innerHTML = data[0].date;
    document.getElementById('date').style.visibility = "visible";
    DateWeatherResults(data[0].temperatureC);
}

// Define DateWeatherResults function separately
async function DateWeatherResults(temperatureC) {
    const response = await fetch(`https://localhost:7270/WeatherForecast/${temperatureC}`);
    const data = await response.json();
    document.getElementById('temperatureC').innerHTML = data[0].temperatureC;
    document.getElementById('temperatureC').style.visibility = "visible";
    document.getElementById('temperatureF').innerHTML = data[0].temperatureF;
    document.getElementById('temperatureF').style.visibility = "visible";
    document.getElementById('summary').innerHTML = data[0].summary;
    document.getElementById('summary').style.visibility = "visible";
}
