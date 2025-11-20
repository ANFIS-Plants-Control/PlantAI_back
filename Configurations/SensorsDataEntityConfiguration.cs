using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantAI.Models;

namespace PlantAI.Configurations
{
    public class SensorsDataEntityConfiguration : IEntityTypeConfiguration<SensorsData>
    {
        public void Configure(EntityTypeBuilder<SensorsData> builder)
        {
            builder.HasKey(e => e.Id).HasName("Sensors_Data_pkey");

            builder.ToTable("Sensors_Data");

            builder.HasIndex(e => e.TypeId, "Sensors_Data_Type_id_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Data).HasColumnType("json");
            builder.Property(e => e.Date).HasColumnType("timestamp without time zone");
            builder.Property(e => e.TypeId).HasColumnName("Type_id");

            builder.HasOne(d => d.Type).WithMany(p => p.SensorsData)
                .HasForeignKey(d => d.TypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sensors_data_type_id_foreign");
        }
    }
}
