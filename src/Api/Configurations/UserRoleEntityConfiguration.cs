using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlantAI.Models;

namespace PlantAI.Configurations
{
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(e => e.Id).HasName("User_Role_pkey");

            builder.ToTable("User_Role");

            builder.Property(e => e.Id).HasColumnName("id");
        }
    }
}
