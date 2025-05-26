using Microsoft.EntityFrameworkCore;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Configurations;
using MicroelectronicsWarehouse.Seed;

namespace MicroelectronicsWarehouse.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Component> Components { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ComponentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            AppDbInitializer.Seed(modelBuilder);

        }
    }
}
