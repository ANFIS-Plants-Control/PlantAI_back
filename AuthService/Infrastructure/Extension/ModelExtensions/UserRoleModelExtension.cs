using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Extension.ModelExtensions
{
    public class UserRoleModelExtension : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasData([
                new UserRole {Id = 1, RoleName = "Admin" },
                new UserRole {Id = 2, RoleName = "Manager" },
                new UserRole {Id = 3, RoleName = "Agronomist" }
            ]);
        }
    }
}
