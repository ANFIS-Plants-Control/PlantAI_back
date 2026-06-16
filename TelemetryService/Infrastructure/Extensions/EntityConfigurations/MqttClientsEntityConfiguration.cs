using Core.Models.mqtt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions.EntityConfigurations
{
    public class MqttClientsEntityConfiguration : IEntityTypeConfiguration<MqttClient>
    {
        public void Configure(EntityTypeBuilder<MqttClient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Topics)
                .WithMany(x => x.Subscriptions);
        
            builder.HasOne(x => x.Broker)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.BrokerId);
        }
    }
}
