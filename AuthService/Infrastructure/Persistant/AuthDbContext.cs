using Microsoft.EntityFrameworkCore;
namespace AuthService.Infrastructure.Persistant;
//TODO: add models configuration
public class AuthDbContext: DbContext 
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}