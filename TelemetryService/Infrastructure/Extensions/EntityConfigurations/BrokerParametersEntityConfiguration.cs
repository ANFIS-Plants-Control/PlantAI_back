using Core.Models.mqtt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions.EntityConfigurations
{
    public class BrokerParametersEntityConfiguration : IEntityTypeConfiguration<BrokerParpameters>
    {
        public void Configure(EntityTypeBuilder<BrokerParpameters> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => new { b.Host, b.Port })
                .IsUnique();
        }
    }
}
