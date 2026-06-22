using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions.EntityConfigurations
{
    internal class SensorTypeEntityConfiguration : IEntityTypeConfiguration<SensorType>
    {
        public void Configure(EntityTypeBuilder<SensorType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData([
                new SensorType{Id = 1, TypeName="Temperature"},
                new SensorType{Id = 2, TypeName="Humidity"},
                new SensorType{Id = 3, TypeName="CO2"}
            ]);
        }
    }
}
