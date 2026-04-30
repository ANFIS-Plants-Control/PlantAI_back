
using Microsoft.EntityFrameworkCore;

namespace TelemetryService.Infrastructure.Persistant;
//TODO: add configuration for models
public class TelemetryDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder){
        base.OnModelCreating(builder);

        
    }

}