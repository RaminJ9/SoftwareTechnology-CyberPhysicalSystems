using Npgsql;
using ST_CPS_Backend.Models;

namespace ST_CPS_Backend;

public class DBMethods
{
    
    NpgsqlConnection connection;

    public DBMethods(NpgsqlConnection connection)
    {
        this.connection = connection;
    }


    public async void DeleteAllTables()
    {
        try
        {
            await using (var cmd = new NpgsqlCommand("DROP TABLE IF EXISTS(WeatherData, DaySummery)", connection));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public void CreateTables()
    {
        DeleteDataTable();
        CreateDataTable();
        CreateSummeryTable();
    } 
    
    public async Task DeleteDataTable()
    {
        try
        {
            await using (var cmd = new NpgsqlCommand("DROP TABLE IF EXISTS(WeatherData)", connection));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    public async Task CreateDataTable()
    {
        try
        {
            await using (var cmd = new NpgsqlCommand(@"
            CREATE TABLE IF NOT EXISTS WeatherData (
                id SERIAL PRIMARY KEY,
                timestamp TIMESTAMP NOT NULL,
                temperature DOUBLE PRECISION NOT NULL,
                humidity INT NOT NULL,
                windspeed DOUBLE PRECISION NOT NULL
            )", connection))
            {
                await cmd.ExecuteNonQueryAsync(); // this is what runs the command that is being made above.
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    public async Task SaveInDb(DataForDB snapshot)
    {
        try
        {
            await using (var cmd = new NpgsqlCommand(@"INSERT INTO WeatherData (timestamp, temperature, humidity, windspeed) VALUES (@time, @temp, @humidity, @windspeed)", connection))
            {
                cmd.Parameters.AddWithValue("@time", snapshot.Timestamp);
                cmd.Parameters.AddWithValue("@temp", snapshot.Temperature);
                cmd.Parameters.AddWithValue("@humidity", snapshot.Humidity);
                cmd.Parameters.AddWithValue("@windspeed", snapshot.WindSpeed);
                await cmd.ExecuteNonQueryAsync();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private async void CreateSummeryTable()
    {
        try
        {
            await using (var cmd = new NpgsqlCommand("CREATE TABLE DaySummery", connection))
            {
                
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
    }
    
    
    

}