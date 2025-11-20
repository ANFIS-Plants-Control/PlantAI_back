using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Configurations
{
    public class SensorTypeEntityConfiguration : IEntityTypeConfiguration<SensorType>
    {
        public void Configure(EntityTypeBuilder<SensorType> builder)
        {
            builder.HasKey(e => e.Id).HasName("Sensor_Type_pkey");

            builder.ToTable("Sensor_Type");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Type).HasMaxLength(255);
        }
    }
}
