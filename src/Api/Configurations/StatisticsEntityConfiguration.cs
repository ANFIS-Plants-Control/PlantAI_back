using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantAI.Models;

namespace PlantAI.Configurations
{
    public class StatisticsEntityConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            builder.HasKey(e => e.Id).HasName("Statistics_pkey");

            builder.HasIndex(e => e.ReportId, "Statistics_Report_id_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.ChangeHour)
                .HasColumnType("json")
                .HasColumnName("Change_Hour");
            builder.Property(e => e.Date).HasColumnType("timestamp without time zone");
            builder.Property(e => e.ReportId).HasColumnName("Report_id");

            builder.HasOne(d => d.Report).WithMany(p => p.Statistics)
                .HasForeignKey(d => d.ReportId)
                .HasConstraintName("statistics_report_id_foreign");
        }
    }
}
