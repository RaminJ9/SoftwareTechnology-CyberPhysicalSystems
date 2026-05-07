using Npgsql;

namespace ST_CPS_Backend.Authentication;

// Will authenticate and open connection to PostgreSQL database.
public class Authentication
{
    private static string password;
    
     public static void GetInformation()
    {
        try
        {
            string filename = "Authentication\\password.csv";
            using (StreamReader sr = new StreamReader(filename))
            {
                password = sr.ReadLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Couldnt read password" + e.Message);
            throw;
        }
    }
     
    // Pretty sure the connection string has to be inside of the method since it will run before GetInformation() method.
    public static async Task<NpgsqlConnection> StartConnection()
    {
        GetInformation();
        string connectionString = $"Host=localhost;Port=5432;Username=postgres;Password={password};Database=postgres;";
        try
        {
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);
            var dataSource = dataSourceBuilder.Build();
            var connection = await dataSource.OpenConnectionAsync();
            return connection;
        }
        catch (Exception e)
        {
            Console.WriteLine("Couldnt connect to database"+e);
            throw;
        }
    }
    
}