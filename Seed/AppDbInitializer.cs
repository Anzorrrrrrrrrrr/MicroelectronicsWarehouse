using MicroelectronicsWarehouse.Entities;
using Microsoft.EntityFrameworkCore;

namespace MicroelectronicsWarehouse.Seed
{
    public static class AppDbInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Passive Components" },
                new Category { Id = 2, Name = "Active Components" },
                new Category { Id = 3, Name = "Electromechanical Components" }
            );

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Name = "ElectroParts Ltd.", ContactEmail = "info@ElectroParts.com" },
                new Supplier { Id = 2, Name = "MicroSupply", ContactEmail = "contact@chipmaker.com" },
                new Supplier { Id = 3, Name = "NanoChip Co.", ContactEmail = "info@nanoparts.com" }
            );

            modelBuilder.Entity<Component>().HasData(
                new Component
                {
                    Id = 1,
                    Name = "Resistor 10kΩ",
                    Quantity = 100,
                    Description = "Standard 10k ohm resistor used in various circuits.",
                    CategoryId = 1,
                    SupplierId = 1
                },
                new Component
                {
                    Id = 2,
                    Name = "Capacitor 100uF",
                    Quantity = 50,
                    Description = "Electrolytic capacitor with 100 microfarads capacity.",
                    CategoryId = 1,
                    SupplierId = 2
                },
                new Component
                {
                    Id = 3,
                    Name = "NPN Transistor BC547",
                    Quantity = 200,
                    Description = "General purpose NPN transistor for signal amplification.",
                    CategoryId = 2,
                    SupplierId = 3
                },
                new Component
                {
                    Id = 4,
                    Name = "Relay 5V",
                    Quantity = 75,
                    Description = "Electromechanical relay operating at 5 volts.",
                    CategoryId = 3,
                    SupplierId = 1
                }
            );
        }
    }
}
