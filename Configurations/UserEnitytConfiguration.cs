using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantAI.Interfaces;
using PlantAI.Models;

namespace PlantAI.Configurations
{
    public class UserEnitytConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("Users_pkey");

            builder.HasIndex(e => e.RoleId, "Users_Role_id_idx");

            builder.HasIndex(e => e.Login, "users_login_unique").IsUnique();

            builder.Property(e => e.Id).HasColumnName("id");
            builder.Property(e => e.Login).HasMaxLength(255);
            builder.Property(e => e.Password).HasMaxLength(255);
            builder.Property(e => e.RoleId).HasColumnName("Role_id");

            builder.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_foreign");
        }
    }
}
