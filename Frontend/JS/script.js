let chart = null;
    
async function loadChartAll() {
    const res = await fetch("http://localhost:5256/api/values/weather");
    const data = await res.json();

    const labels = data.map(d => d.time);
    const temps  = data.map(d => d.temperature_2m);

    chart = new Chart(document.getElementById('weatherGraph').getContext('2d'), {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Temperature (°C)',
                data: temps,
                borderColor: 'rgb(255, 0, 0)',
                fill: false,
                tension: 0.1
            }]
        },
        options: {
            responsive: true
        }
    });
}

async function loadChartTemp() {
    const res = await fetch("http://localhost:5256/api/values/weather");
    const data = await res.json();

    const labels = data.map(d => d.time);
    const temps  = data.map(d => d.temperature_2m);

    chart = new Chart(document.getElementById('weatherGraph').getContext('2d'), {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Temperature (°C)',
                data: temps,
                borderColor: 'rgb(255, 0, 0)',
                fill: false,
                tension: 0.1
            }]
        },
        options: {
            responsive: true
        }
    });
}

async function loadChartWindSpeed() {
    const res = await fetch("http://localhost:5256/api/values/weather");
    const data = await res.json();

    const labels = data.map(d => d.time);
    const windSpeed  = data.map(d => d.wind_speed_10m);

    chart = new Chart(document.getElementById('weatherGraph').getContext('2d'), {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Wind Speed (m/s)',
                data: windSpeed,
                borderColor: 'rgb(116, 113, 113)',
                fill: false,
                tension: 0.1
            }]
        },
        options: {
            responsive: true
        }
    });
}

async function loadChartHumidity() {
    const res = await fetch("http://localhost:5256/api/values/weather");
    const data = await res.json();

    const labels = data.map(d => d.time);
    const humidity  = data.map(d => d.relative_humidity_2m);

    chart = new Chart(document.getElementById('weatherGraph').getContext('2d'), {
        type: 'line',
        data: {
            labels: labels,
            datasets: [{
                label: 'Humidity (%)',
                data: humidity,
                borderColor: 'rgb(68, 123, 187)',
                fill: false,
                tension: 0.1
            }]
        },
        options: {
            responsive: true
        }
    });
}

document.getElementById('ButtonTemp').addEventListener('click', () => {
    if (chart) chart.destroy();
    loadChartTemp();
});

document.getElementById('ButtonWindSpeed').addEventListener('click', () => {
    if (chart) chart.destroy();
    loadChartWindSpeed();
});

document.getElementById('ButtonHumidity').addEventListener('click', () => {
    if (chart) chart.destroy();
    loadChartHumidity();
});
