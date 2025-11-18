using Microsoft.EntityFrameworkCore;
using PlantAI.Models;

namespace PlantAI
{
    public class ApplicationDbContext : DbContext 
    {
        string _connectionString;
        public DbSet<Users> Users { get; set; }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationDbContext(string ConnectionString)
        {
            Database.EnsureCreated();
            _connectionString = ConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;User Id=postgres;Password=12345;options=-c search_path=dbo");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}
