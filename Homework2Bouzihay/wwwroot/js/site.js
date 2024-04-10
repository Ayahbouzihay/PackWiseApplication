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
/ Add an event listener to the form submission event
document.getElementById('dateForm').addEventListener('submit', async function (event) {
    event.preventDefault(); // Prevent the default form submission behavior

    // Get the selected date from the input field
    const selectedDate = document.getElementById('date').value;
    console.log('Selected Date:', selectedDate);

    // Call the function to fetch packing recommendations based on the selected date
    await fetchPackingRecommendations(selectedDate);
});

// Function to fetch packing recommendations based on the selected date
async function fetchPackingRecommendations(selectedDate) {
    try {
        const response = await fetch(`https://localhost:7270/api/InputTripDates/${selectedDate}`);
        if (!response.ok) {
            throw new Error('Failed to fetch packing recommendations');
        }
        const data = await response.json();
        console.log('Packing Recommendations:', data);
        // You can update the UI to display the packing recommendations here
    } catch (error) {
        console.error('Error:', error.message);
    }
}
// Add an event listener to the form submission event
document.getElementById('dateForm').addEventListener('submit', async function (event) {
    event.preventDefault(); // Prevent the default form submission behavior

    // Get the selected date from the input field
    const selectedDate = document.getElementById('date').value;
    console.log('Selected Date:', selectedDate);

    // Call the function to fetch packing recommendations based on the selected date
    await fetchPackingRecommendations(selectedDate);
});

// Function to fetch packing recommendations based on the selected date
async function fetchPackingRecommendations(selectedDate) {
    try {
        const response = await fetch(`https://localhost:7270/api/InputTripDates/${selectedDate}`);
        if (!response.ok) {
            throw new Error('Failed to fetch packing recommendations');
        }
        const data = await response.json();
        console.log('Packing Recommendations:', data);
        // You can update the UI to display the packing recommendations here
        displayPackingRecommendations(data); // Assuming you have a function to display packing recommendations
    } catch (error) {
        console.error('Error:', error.message);
    }
}

// Function to display packing recommendations
function displayPackingRecommendations(packingRecommendations) {
    // Update the UI to display the packing recommendations
    const packingListDiv = document.getElementById('packingRecommendations');
    packingListDiv.innerHTML = ''; // Clear previous content
    packingRecommendations.forEach(recommendation => {
        const listItem = document.createElement('div');
        listItem.textContent = recommendation.itemName; // Example property name, adjust as needed
        packingListDiv.appendChild(listItem);
    });
}