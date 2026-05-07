namespace ST_CPS_Backend.Models
{
    // data that we will be working with
    
    public class WeatherValues // hourly
    {
        
        public DateTime time {get; set;}
        public double temperature_2m  {get; set;}
        public int relative_humidity_2m {get; set;}
        public double wind_speed_10m {get; set;}


    }
    
    public class CurrentWeather //openmateo
    {
        public WeatherValues current {get; set;}
    }
    
}
