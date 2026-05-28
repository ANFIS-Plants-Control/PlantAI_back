using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions
{
    public class MqttClientOptionsEntityConfiguration : IEntityTypeConfiguration<MqttClientOptions>
    {
        public void Configure(EntityTypeBuilder<MqttClientOptions> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
