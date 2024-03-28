# Web Pages
1. Homepage
- Description:
	- Introduction to the application and its features.
	- Features a brief overview of the services offered.
	- Provides options for user registration and login.
	- Allows users to navigate to other pages such as Explore Activities or Personalized Packing Recommendations.
2. User Registration/Login Page:
- Description:
	- Combines both user registration and login functionalities on a single page.
	- Provides fields for username/email, password, and options for registration or login.
	- Validates user input and provides error messages for invalid entries.
	- Upon successful registration or login, redirects users to their personalized dashboard or the page they were trying to access.
3. Select Trip and Input Dates Page:
- Description:
	- Allows users to select the type of trip they will be taking (e.g., hiking, beach, business).
	- Provides options or a dropdown menu to choose the trip category.
	- Enables users to input the dates of their trip using a calendar or date picker.
	- Validates input to ensure trip dates are valid and within the future timeframe.
	- After inputting dates and selecting a trip category, redirects users to the View Packing Recommendations page.
4. View Packing Recommendations Page:
- Description:
	- Displays personalized packing recommendations for the selected trip and dates.
	- Utilizes the "View Packing Recommendation" API to fetch recommendations based on user input.
	- Presents packing recommendations for clothing, toiletries, accessories, etc., tailored to the trip and weather conditions.
	- Allows users to add recommended items to their packing list or mark them as packed.
5. Explore Activities Page:
- Description:
	- Dynamic page showcasing activities related to the selected trip category.
	- Utilizes the "Explore Activities" API to retrieve a list of activities based on the chosen trip category.
	- Users can explore various activities such as sightseeing, adventure sports, cultural experiences, etc.
	- Each activity card includes a brief description, image, and relevant details.
6. User Dashboard Page:
- Description:
	- Dynamic page displaying personalized information and options for the logged-in user.
	- Shows user-specific data such as upcoming trips, packing lists, saved activities, etc.
	- Allows users to manage their profile settings, update preferences, change passwords, etc.
	- Provides quick access to frequently used features like creating new trips, accessing packing recommendations, viewing activity wishlist, etc.

# Web API Documentation

## Explore Activities (Ayah-Mounina Bouzihay)

### Purpose:
Retrieves a list of activities based on the selected trip category.

### Inputs:
- Category ID: Unique identifier for the trip category

### Outputs:
- List of activities
  - Activity name
  - Description
  - Location
  - Duration

## Get Packing Recommendations (Ayah-mounina Bouzihay)

### Purpose:
Retrieves personalized packing recommendations for a specific traveler and trip date.

### Inputs:
- Traveler ID: Unique identifier for the traveler
- Trip Date: Date of the trip

### Outputs:
- List of packing recommendations
