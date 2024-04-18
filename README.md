# PackWise Web Application

## Project Overview
PackWise is a web application designed to provide personalized packing recommendations based on weather predictions and user preferences. With PackWise, users can efficiently pack for various climates and activities, enhancing their travel experience.

## Deployment Guide
To deploy PackWise on a blank VM, follow these steps:

1. **Database Setup**:
   - Execute the SQL scripts provided in the `database` folder on your SQL Server to create the database schema.
   - Ensure to execute the stored procedures for proper functionality.

2. **Clone Repository**:
   - Clone the repository from [GitHub](https://github.com/Ayahbouzihay/Homework2Bouzihay) to your local machine.

3. **Configure Visual Studio**:
   - Open the solution in Visual Studio.
   - Navigate to the execute menu and go to settings.
   - Start only the `PackWiseAPI` project and select none for `Homework2Bouzihay`.

5. **Run the Application**:
   - Stop debugging and go back into settings.
   - Start both projects (`PackWiseAPI` and `Homework2Bouzihay`) and execute.
## Testing Instructions
Since PackWise currently relies on manually inputted data and does not have location or weather APIs integrated, specific dates, IDs, and categories must be used to test the functionality of the website. Below are some examples:

- **Trip ID 1**:
  - Date: March 16, 2024
  - Category: 1

- **Trip ID 2**:
  - Date: April 10, 2024
  - Category: 2

- **Another Trip ID 2**:
  - Date: April 11, 2024
  - Category: 2

## API Documentation
### Explore Activities API (Ayah-mounina Bouzihay)
- **Purpose**: Retrieves a list of activities based on the selected trip category.
- **Inputs**: Category ID (unique identifier for the trip category)
- **Outputs**: List of activities based on the category

### Get Packing Recommendations API (Ayah-mounina bouzihay)
- **Purpose**: Retrieves personalized packing recommendations for a specific trip date.
- **Inputs**: Trip Date
- **Outputs**: List of packing recommendations

### Input Trip Dates API (Ayden Pratt) (to be combined with Get Packing Recommendations in the future) (Ayden Pratt)
- **Purpose**: Allows users to input the dates of their trip.
- **Inputs**: Date
- **Outputs**: Returns a list of packing recommendations objects.
- we realized a tad bit too late, that both our API's output packing recommendations. but we've been  using input trip Dates to intake the date and getPackingRecommendations to out put the recommendations.

### Select Trip API (Ayden Pratt)
- **Purpose**: Allows users to select the type of trip they will be taking.
- **Inputs**: Category Name
- **Outputs**: List of available trip categories.

## Razor Pages

### Homepage (`Index.cshtml`) - Ayah-mounina Bouzihay
Description:
The homepage serves as an introduction to the application and its features.
Features:
- Provides an overview of Packwise and its mission.
- Offers options for users to explore activities, manage travel budgets, and get personalized packing recommendations.
- Contains buttons linking to other pages such as Explore Activities, Travel Budget, and Select Trip Dates.
![Screenshot 2024-04-17 234736](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/7ce532f5-2a3c-4d2a-839b-799d59aa4205)

### Select Trip Dates (`SelectTripDates.cshtml`) - Ayden Pratt
Description:
Allows users to select the type of trip they will be taking.
Features:
- Displays categories of trips such as hiking, beach, skiing, and camping.
- Users can select a trip category from the dropdown menu and submit their choice.
- Upon submission, users are redirected to a page to input trip dates and view personalized packing recommendations.
![Screenshot 2024-04-17 234805](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/1dc961ad-a48b-4638-938d-519025493750)
![Screenshot 2024-04-17 234842](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/52868f2f-115c-45f1-bef7-2b4eec949afb)

###Search Location and Input Dates (TripNames.cshtml) - (Ayah-mounina Bouzihay)
Description:
This dynamic page enables users to choose a location and date for their selected trip category. It provides sleek input boxes for entering the location and selecting the date.
Features:
- Users can choose a trip category and proceed to select a location and date.
- Sleek input boxes enhance user experience for entering location and date information.
- users can search for available locations or dates for their trip.
- The page design ensures consistency with the site's aesthetic and usability standards.
![Screenshot 2024-04-17 234904](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/dc7b0978-a8f6-4077-8114-75bf8280a70b)

### Explore Activities (`ExploreActivities.cshtml`) - (Ayah-mounina Bouzihay, Ayden Pratt)
Description:
Dynamic page showcasing activities related to the selected trip category.
Features:
- Users can select a trip category (e.g., hiking, beach) from the dropdown menu. 
- Upon submission, displays a list of activities related to the chosen category.  
- Activities are fetched from the Explore Activities API and displayed dynamically on the page. 
![Screenshot 2024-04-18 001841](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/eb0d1732-1dd0-4a7c-8772-b1e67ff3e56a)
### Personalized Packing Recommendations (`DateSearch.cshtml`) (Ayden Pratt, Ayah-mounina Bouzihay)
Description:
Allows users to input trip dates and retrieve personalized packing recommendations.
Features:
- Users can input their traveler ID and desired trip date to fetch recommendations.
- Utilizes the Packing Recommendations API to retrieve packing suggestions based on user input.
- Displays recommendations for clothing, toiletries, accessories, etc., tailored to the trip and weather conditions.
![Screenshot 2024-04-17 234941](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/f7e4456e-21e2-4efa-9d78-6211f03f67b8)
![Screenshot 2024-04-18 001910](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/34ac3e8e-c752-4a33-902e-c8d4461dc4e2)

### Travel Budget (`TravelBudget.cshtml`) (Ayah-mounina Bouzihay)
Description:
Displays estimated travel budget for different destinations.
Features:
- Shows estimated costs for transportation, accommodation, meals, and activities for destinations like Paris, Marrakesh, and Gaza.
- Provides a breakdown of expenses in a tabular format for easy comparison.
![Screenshot 2024-04-17 234700](https://github.com/Ayahbouzihay/Homework2Bouzihay/assets/142525295/e4c911f4-55a6-4657-89a4-64885ca5b2c1)

## Application Description
PackWise offers personalized packing recommendations and activity suggestions to streamline the travel planning process. Users can select their trip type, input dates, and receive tailored packing lists and activity options.

## Developer Documentation
If a new group of developers were to take over PackWise, they would need to familiarize themselves with:

- The structure of the codebase and the purpose of each file and directory.
- API integration methods and data retrieval processes.
- Database schema and data management procedures.
- User interface components and design patterns.

## Future Enhancements
- Combine Input Trip Dates and Get Packing Recommendations APIs for streamlined functionality.
- Remove the requirement for a traveler ID in the Get Packing Recommendations API.
- Implement adjustments to allow non-members to try out the application before joining.

## Monetization Strategy
PackWise can generate revenue through:

1. **Freemium Model**: Offering basic features for free with premium subscription plans for advanced features.
2. **In-App Purchases**: Selling premium packing templates, travel guides, and ad-free experiences.
3. **Advertising Revenue**: Displaying targeted advertisements and sponsored content.
4. **Affiliate Marketing**: Earning commission through referrals to travel gear and products.

## Conclusion
PackWise aims to revolutionize travel planning by providing personalized packing recommendations and activity suggestions. With a diverse monetization strategy and potential for profitability, PackWise is poised for success in the travel tech industry.













































































## Project Overview

This project aims to develop a web application that provides personalized packing recommendations based on weather predictions and user preferences. With this application, users can efficiently pack for diverse climates, making their trips more comfortable and enjoyable.

## Page Descriptions

| Page Name                          | Description                                                                                                  |
|------------------------------------|--------------------------------------------------------------------------------------------------------------|
| Homepage                           | Serves as an introduction to our application, highlighting its benefits and features. Users can navigate to other pages from here.                   |
| Personalized Packing Recommendations | Displays personalized packing recommendations for various categories such as clothing, toiletries, and accessories based on user input and weather forecasts. |

## Competitive Analysis

In the competitive analysis, I explored three websites—Packtor, PackPoint, and TripIt—that offer packing assistance and travel planning services. Each website showcases unique features and technologies:

### Website A: Packtor

Packtor is a web application designed to streamline the packing process by offering personalized recommendations based on weather forecasts and user preferences. The platform features a clean and intuitive user interface, utilizing modern web development technologies like React for the front end and Node.js for the back end. Packtor stands out for its user-friendly interface, accurate packing suggestions, and effective use of innovative web technologies.

### Website B: PackPoint

PackPoint is a popular packing app available on both web and mobile platforms, providing personalized packing lists tailored to travel destination, duration, and activities. The website boasts a minimalist design with easy navigation and employs HTML, CSS, and JavaScript for front-end development. Its simplicity, responsiveness, and seamless integration with the mobile app make PackPoint a convenient tool for travelers.

### Website C: TripIt

TripIt is a comprehensive travel planning platform offering itinerary management, booking organization, and real-time updates for travelers. The website features a sleek design and robust functionality, utilizing advanced front-end frameworks like Angular or Vue.js and back-end technologies such as Node.js or Java. With its feature-rich platform and user-friendly interface, TripIt remains a top choice for frequent travelers seeking comprehensive travel organization tools.
## Git Reositories 
### Weather-API (https://github.com/robertoduessmann/weather-api)
This repository offers an API for retrieving weather data from various sources, providing code snippets and examples for seamless integration into applications. The README provides clear instructions on installation, usage, and available endpoints, along with examples of API responses and error handling, making it a valuable resource for developers seeking weather data programmatically.
### Packing-List-App (https://github.com/jessekorzan/packing-list-app)  
hosts code for a packing list application, relevant for projects involving personalized packing recommendations based on weather predictions. The README presents an overview of the application's features, installation instructions, and usage guidelines, supplemented with screenshots and descriptions of key functionalities. This practical solution for managing packing lists aligns well with the project's objectives, with the README effectively communicating functionality and usage for developers in similar endeavors.

## Future Enhancements

- Integration of additional travel-related features such as trip type: hiking/ leisure/ surfing.
- Integrating Weather data into the web app.

## Reflection on Resources

In completing this project, I found generative AI tools like ChatGPT to be incredibly useful for generating content and refining project documentation. Additionally, resources such as online tutorials, documentation, and coding forums were invaluable for overcoming technical challenges and enhancing our development skills. While generative AI provided helpful insights, human judgment and critical thinking were essential for interpreting and applying the generated content effectively.

## Links and Resources

- [Bootswatch - Quartz](https://bootswatch.com/quartz/)
- [W3C CSS Validator](https://jigsaw.w3.org/css-validator/)
- [W3Schools - Bootstrap 5 Tutorial](https://www.w3schools.com/bootstrap5/index.php)
- [Bootswatch](https://bootswatch.com/)
- [W3Schools - HTML Scripting](https://www.w3schools.com/html/html_scripts.asp)
- References from ChatGPT queries:
  1. "write custom CSS for the PersonalizedPackingRecommendations Page.  with at least 3 properties. This should accomplish something that CANNOT be done using Bootstrap classes."
  2. "Create HTML elements for the custom CSS above."
