
using Npgsql;
using ST_CPS_Backend;
using ST_CPS_Backend.Authentication;

public class program
{
    // class level properties instead of method level properties. They just end up being used by main, instead of created in main method.
    public static NpgsqlConnection Connection { get; private set; }
    public static DBMethods DbMeth { get; private set; }
    
    static async Task Main(string[] args)
    {
        
        var builder = WebApplication.CreateBuilder(args);
        
         
        Connection = await Authentication.StartConnection(); // starts connection to the database
        
        DbMeth = new DBMethods(Connection); // Creates object so we can use the SQL commands.
        // await DbMeth.DeleteDataTable();
        await DbMeth.CreateDataTable();
        // these below will be removed, they are just for testing.
        // var asd = ApiService.GetInstance(); // singleton of the apiservice, that is being used.
        // await asd.ApiServiceMethod(); // the api call method.
        // await DbMeth.FetchData(); // fetches the data
        
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();
        
        builder.Services.AddSingleton(DbMeth);
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        builder.Services.AddHostedService<WeatherPollingService>(); // runs the backgroundservice.
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        { app.MapOpenApi(); }
        app.UseCors();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
        
    }
}