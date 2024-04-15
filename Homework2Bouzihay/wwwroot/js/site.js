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

async function fetchRecommendations(categoryId, date) {
    const response = await fetch(`https://localhost:7270/api/GetPackingRecommendations?travelerId=${travelerId}&date=${date}`);
    if (!response.ok) {
        throw new Error('Failed to fetch recommendations');
    }
    return await response.json();
}

async function renderRecommendations(travelerId, date) {
    try {
        const recommendations = await fetchRecommendations(travelerId, date);
        const recommendationsDiv = document.getElementById('recommendations');
        recommendationsDiv.innerHTML = ''; // Clear previous recommendations

        if (recommendations.length === 0) {
            recommendationsDiv.textContent = 'No recommendations available';
            return;
        }

        const recommendationList = document.createElement('ul');
        recommendations.forEach(recommendation => {
            const listItem = document.createElement('li');
            listItem.textContent = `Recommendation ID: ${recommendations.recommendationID}, Recommendations: ${recommendations.recommendations}`;
            recommendationList.appendChild(listItem);
        });

        recommendationsDiv.appendChild(recommendationList);
    } catch (error) {
        console.error('Error fetching or rendering recommendations:', error);
    }
}


    
