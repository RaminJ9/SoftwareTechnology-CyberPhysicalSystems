namespace ST_CPS_Backend.Models
{
    
    // Summery Data that will be saved in the Database.
    public class DailySummery
    {
        public int Id;
        public string Date;
        public double _MinTemperature;
        public double _MaxTemperature;
        public int _MinHumidity;
        public int _MaxHumidity;
        public double _MinWindSpeed;
        public double _MaxWindSpeed;

    }
}
