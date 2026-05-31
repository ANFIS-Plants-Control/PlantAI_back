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

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.Subscriptions)
                .HasForeignKey(x => x.TopicId);
        
            builder.HasOne(x => x.Broker)
                .WithMany(x => x.Clients)
                .HasForeignKey(x => x.BrokerId);
        }
    }
}
