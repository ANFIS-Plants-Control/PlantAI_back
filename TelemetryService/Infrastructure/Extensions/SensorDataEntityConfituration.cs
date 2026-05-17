using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extensions
{
    internal class SensorDataEntityConfituration : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.SensorType)
                .WithMany(x => x.SensorsData)
                .HasForeignKey(x => x.SensorType)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.DataGroup)
                .WithMany(x => x.SensorsData)
                .HasForeignKey(x => x.DataGroup)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
