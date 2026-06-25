
using Core.Models;
using Core.Models.mqtt;
using Infrastructure.Extensions.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace TelemetryService.Infrastructure.Persistant;

public class TelemetryDbContext : DbContext
{

    public DbSet<SensorData> SensorsData { get; set; }
    public DbSet<DataGroup> DataGroups { get; set; }
    public DbSet<MqttClient> MqttClients { get; set; }
    public DbSet<BrokerParpameters> BrokerParameters { get; set; }
    public DbSet<TopicDefinition> TopicDefinitions { get; set; }

    public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new SensorDataEntityConfituration());
        builder.ApplyConfiguration(new DataGroupEntityConfiguration());
        builder.ApplyConfiguration(new SensorTypeEntityConfiguration());
        builder.ApplyConfiguration(new MqttClientsEntityConfiguration());
        builder.ApplyConfiguration(new TopicDefinitionEntityConfiguration());
        builder.ApplyConfiguration(new BrokerParametersEntityConfiguration());
    }
}