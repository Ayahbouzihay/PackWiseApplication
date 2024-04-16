// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//console.log('JavaScript code loaded');
async function displayTripCat(categoryName) {
    const response = await fetch(`https://localhost:7270/api/SelectTrip/${categoryName}`);
    const data = await response.json();
    document.getElementById('chosenTrip').innerHTML = data[0].categoryName;
    document.getElementById('chosenTrip').style.visibility = "visible";
}

async function DateResults(date) {
    const response = await fetch(`https://localhost:7270/api/InputTripDates?Date=${date}`);
    const data = await response.json();
    document.getElementById('dateElement').innerHTML = data[0].date;
    document.getElementById('dateElement').style.visibility = "visible";
}

async function fetchRecommendations(travelerID, date) {
    const response = await fetch(`https://localhost:7270/api/PackingRecommendation/travelerid=${travelerID}&date=${date}`);
    const data = await response.json();

    document.getElementById('recommendationID').innerHTML = data[0].recommendationID;
    document.getElementById('travelerID').innerHTML = data[0].travelerID;
    document.getElementById('date').innerHTML = data[0].date;
    document.getElementById('tripCategoryID').innerHTML = data[0].tripCategoryID;
    document.getElementById('criteriaID').innerHTML = data[0].criteriaID;
    document.getElementById('recommendations').innerHTML = data[0].recommendations;
   
        
    }


async function displayActivitieslist() {
    const categoryId = document.getElementById('categorySelect').value;
    console.log('Selected Category ID:', categoryId); // Log the selected category ID

    const response = await fetch(`https://localhost:7270/api/ExploreActivities/${categoryId}`);
    const data = await response.json();
    console.log('Received Data:', data); // Log the received data

    const activityListDiv = document.getElementById('activityList');
    activityListDiv.innerHTML = ''; // Clear previous activities

    data.forEach(activity => {
        const activityNameDiv = document.createElement('div');
        activityNameDiv.textContent = activity.ActivityName;
        activityListDiv.appendChild(activityNameDiv);
    });
}




