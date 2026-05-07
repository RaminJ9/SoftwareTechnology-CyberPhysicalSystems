using Microsoft.EntityFrameworkCore;
using ST_CPS_Backend.Models;

namespace ST_CPS_Backend.DB;


public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<DataForDB> WeatherSnapshots { get; set; }
    public DbSet<DailySummery> DailySummery { get; set; }
}