
using Core.Models;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace TelemetryService.Infrastructure.Persistant;
public class TelemetryDbContext : DbContext
{

    public DbSet<SensorData> SensorsData { get; set; }
    public DbSet<DataGroup> DataGroups { get; set; }

    public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new SensorDataEntityConfituration());
        builder.ApplyConfiguration(new DataGroupEntityConfiguration());
        builder.ApplyConfiguration(new SensorTypeEntityConfiguration());
    }

}