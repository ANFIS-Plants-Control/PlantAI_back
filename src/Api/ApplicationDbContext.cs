using Microsoft.EntityFrameworkCore;
using PlantAI.Configurations;
using PlantAI.Models;

namespace PlantAI
{
    public class ApplicationDbContext : DbContext 
    {
        string _connectionString;

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SensorType> SensorTypes { get; set; }
        public virtual DbSet<SensorsData> SensorsData { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

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

            if (string.IsNullOrEmpty(_connectionString))
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("dbConfig.json").Build();

                _connectionString = configuration.GetSection("ConnectionStrings").GetValue(typeof(string), "DefaultConnection").ToString();
            }

            optionsBuilder.UseNpgsql(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AnswerEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReportEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SensorTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SensorsDataEntityConfiguration());
            modelBuilder.ApplyConfiguration(new StatisticsEntityConfiguration());
            modelBuilder.ApplyConfiguration(new UserEnitytConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleEntityConfiguration());
        }
    }
}
