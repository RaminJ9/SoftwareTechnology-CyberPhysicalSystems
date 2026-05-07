namespace ST_CPS_Backend;

/*
 If forgot how it works:
 https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-10.0&tabs=visual-studio
 https://www.youtube.com/watch?v=elwx4Yhgs4Y
 */
public class WeatherPollingService : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                await ApiService.GetInstance().ApiServiceMethod();
                Console.WriteLine("Weather data fetched and saved: " + DateTime.Now);
            }
            catch (Exception e)
            {
                Console.WriteLine("Poller error: " + e.Message);
            }

            await Task.Delay(TimeSpan.FromMinutes(15), stoppingToken);
        }
    }
}