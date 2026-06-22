using Core.Models;
using Infrastructure.Extensions.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistant
{
    public class PlantAIDbContext : DbContext
    {

        public DbSet<ControlElement> ControlElement { get; set; }
        public DbSet<Fnn> Fnn { get; set; }
        public DbSet<FnnAnswer> FnnAnswer { get; set; }

        public PlantAIDbContext(DbContextOptions<PlantAIDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ControlElementEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FnnEntityConfiguration());
            modelBuilder.ApplyConfiguration(new FnnAnswerEntityConfiguration());
        }

    }
}
