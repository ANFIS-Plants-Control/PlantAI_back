using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Configurations
{
    public class ReportEntityConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(e => e.Id).HasName("Reports_pkey");

            builder.HasIndex(e => e.UserId, "Reports_User_id_idx");

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Date).HasColumnType("timestamp without time zone");
            builder.Property(e => e.UserId).HasColumnName("User_id");

            builder.HasOne(d => d.User).WithMany(p => p.Reports)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reports_user_id_foreign");
        }
    }
}
