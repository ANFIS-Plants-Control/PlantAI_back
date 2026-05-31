using AuthService.Core.Models;
using Core.Models;
using Infrastructure.Extension.ModelExtensions;
using Microsoft.EntityFrameworkCore;
namespace AuthService.Infrastructure.Persistant;
public class AuthDbContext: DbContext 
{

    public DbSet<User> Users { get; protected set; }
    public DbSet<UserRole> UserRoles { get; protected set; }

    public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new UserModelExtension());
        builder.ApplyConfiguration(new UserRoleModelExtension());
    }
}