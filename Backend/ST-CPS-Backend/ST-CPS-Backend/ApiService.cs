using System.Text.Json;
using System.Text.Json.Serialization;
using ST_CPS_Backend.Models;

namespace ST_CPS_Backend;

public class ApiService
{
    // Singleton Class Design Pattern.
    
    private static ApiService instance;
    
    static Object myLock = new Object();

    private ApiService()
    {
    }
    public static ApiService GetInstance()
    {
         lock (myLock)
         {
              if (instance == null)
              {
                   return instance = new ApiService();
              }
              return instance;
         }
    }
    

    private string url = "https://api.open-meteo.com/v1/forecast?latitude=59.91&longitude=10.75&models=metno_seamless&current=temperature_2m,relative_humidity_2m,wind_speed_10m&past_days=0&forecast_days=3&wind_speed_unit=ms&timezone=Europe%2FCopenhagen";
    
    HttpClient client = new HttpClient();

    public async Task ApiServiceMethod()
    {
         try 
         { 
              HttpResponseMessage response = await client.GetAsync(url); 
              if (response.IsSuccessStatusCode) 
              { 
                   string json = await response.Content.ReadAsStringAsync();
                   
                   CurrentWeather data = JsonSerializer.Deserialize<CurrentWeather>(json); 
                   DataForDB snapshot = new DataForDB() 
                   { 
                        Timestamp = data.current.time, 
                        Temperature = data.current.temperature_2m, 
                        Humidity = data.current.relative_humidity_2m, 
                        WindSpeed = data.current.wind_speed_10m
                   }; 
                   await program.DbMeth.SaveInDb(snapshot);
              }
              else 
              { 
                   Console.WriteLine("Error" + response.StatusCode);
              }
         }
         catch (Exception ex) 
         { 
              Console.WriteLine("Request Failed" + ex.Message);
         }
    }
}