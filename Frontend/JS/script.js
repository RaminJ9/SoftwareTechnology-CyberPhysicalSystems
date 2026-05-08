
// 
// fetch("https://api.open-meteo.com/v1/forecast?latitude=59.91&longitude=10.75&models=metno_seamless&current=temperature_2m,relative_humidity_2m,wind_speed_10m&past_days=0&forecast_days=3&wind_speed_unit=ms&timezone=Europe%2FCopenhagen")
//     .then(response => response.json())
//     .then(data => console.log(data))
//     .catch(error =>console.error(error));

fetch("http://localhost:5256/api/values/weather")
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(error =>console.error(error));