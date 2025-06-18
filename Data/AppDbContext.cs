using Microsoft.EntityFrameworkCore;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Configurations;
using MicroelectronicsWarehouse.Seed;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace MicroelectronicsWarehouse.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
            base.OnModelCreating(modelBuilder);
            AppDbInitializer.Seed(modelBuilder);

        }
    }
}
