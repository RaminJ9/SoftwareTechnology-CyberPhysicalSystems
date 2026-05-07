namespace ST_CPS_Backend.Models;


// Normal Data that will be saved in the Database.
public class DataForDB
{
    public DateTime Timestamp { get; set; }
    public double Temperature { get; set; }
    public double Humidity { get; set; }
    public double WindSpeed { get; set; }
}