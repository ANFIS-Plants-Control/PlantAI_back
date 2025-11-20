using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantAI.Models;

namespace PlantAI.Configurations
{
    public class AnswerEntityConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> modelBuilder)
        {
            modelBuilder.HasKey(e => e.Id).HasName("Answers_pkey");

            modelBuilder.HasIndex(e => e.SensorId, "Answers_Sensor_id_idx");

            modelBuilder.HasIndex(e => e.StatisticId, "Answers_Statistic_id_idx");

            modelBuilder.Property(e => e.Id).HasColumnName("id");
            modelBuilder.Property(e => e.Date).HasColumnType("timestamp without time zone");
            modelBuilder.Property(e => e.Recommend).HasColumnType("json");
            modelBuilder.Property(e => e.SensorId).HasColumnName("Sensor_id");
            modelBuilder.Property(e => e.StatisticId).HasColumnName("Statistic_id");

            modelBuilder.HasOne(d => d.Sensor).WithMany(p => p.Answers)
                .HasForeignKey(d => d.SensorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("answers_sensor_id_foreign");

            modelBuilder.HasOne(d => d.Statistic).WithMany(p => p.Answers)
                .HasForeignKey(d => d.StatisticId)
                .HasConstraintName("answers_statistic_id_foreign");
        }
    }
}
