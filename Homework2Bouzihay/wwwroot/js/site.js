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


    
