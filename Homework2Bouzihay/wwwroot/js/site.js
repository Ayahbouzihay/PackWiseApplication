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
    const response = await fetch(`https://localhost:7270/api/PackingRecommendation?travelerid=${travelerID}&date=${date}`);
    const data = await response.json();

    document.getElementById('travelerID').innerText = data[0].travelerID;
    document.getElementById('date').innerText = data[0].date;
    document.getElementById('recommendations').innerText = data[0].recommendations;
}

async function getRecommendations() {
    const travelerID = document.getElementById('travelerIDInput').value;
    const date = document.getElementById('dateInput').value;
    await fetchRecommendations(travelerID, date);
}


async function DisplayActivities(categoryID) {
    const response = await fetch(`https://localhost:7270/api/ExploreActivities/${categoryID}`);
    const data = await response.json();
    const activityList = document.getElementById('activityList');
    activityList.innerHTML = ''; 
    data.forEach(activity => {
        const activityElement = document.createElement('div');
        activityElement.textContent = activity.activityName;
        activityList.appendChild(activityElement);
    });
}

function displayActivitieslist() {
    const categoryID = document.getElementById('categorySelect').value;
    DisplayActivities(categoryID);
}



