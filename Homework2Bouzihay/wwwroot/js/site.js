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
   
        //const recommendations = await response.json();
        //const recommendationsDiv = document.getElementById('recommendations');
        //recommendationsDiv.innerHTML = ''; // Clear previous recommendations

        ////if (recommendations.length === 0) {
        ////    recommendationsDiv.textContent = 'No recommendations available';
        ////    return;
        ////}

        //const table = document.createElement('table');
        //table.border = '1';

        //// Create table header row
        //const headerRow = document.createElement('tr');
        //for (const key in recommendations[0]) {
        //    const th = document.createElement('th');
        //    th.textContent = key;
        //    headerRow.appendChild(th);
        //}
        //table.appendChild(headerRow);

        //// Create table rows for each recommendation
        //recommendations.forEach(recommendation => {
        //    const row = document.createElement('tr');
        //    for (const key in recommendation) {
        //        const td = document.createElement('td');
        //        td.textContent = recommendation[key];
        //        row.appendChild(td);
        //    }
        //    table.appendChild(row);
        //});
    }


async function displayActivities(categoryID) {
    const response = await fetch(`https://localhost:7270/api/ExploreActivities/${categoryID}`);
    const data = await response.json();

}