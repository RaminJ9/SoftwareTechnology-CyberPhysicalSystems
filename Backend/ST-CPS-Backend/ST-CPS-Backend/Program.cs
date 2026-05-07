
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
        DbMeth = new DBMethods(Connection);
        await DbMeth.DeleteDataTable();
        await DbMeth.CreateDataTable();
        var asd = ApiService.GetInstance();
        await asd.ApiServiceMethod();
        await DbMeth.FetchData();
        
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        { app.MapOpenApi(); }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
        
    }
}