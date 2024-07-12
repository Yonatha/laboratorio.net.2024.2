using LaboratorioDev.Entity;
using Microsoft.EntityFrameworkCore;

namespace LaboratorioDev.Data
{
    public class ErpDbContext : DbContext
    {
        public ErpDbContext(DbContextOptions<ErpDbContext> options) : base(options) =>
            Database.EnsureCreated();
        
        public DbSet<OrdemServico?> OrdemServico { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connection = configuration.GetConnectionString("DefaultConnection");
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql(connection, serverVersion);
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}