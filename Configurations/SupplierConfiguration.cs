using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroelectronicsWarehouse.Entities;

namespace MicroelectronicsWarehouse.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Property(s => s.ContactEmail).HasMaxLength(100);

        builder.HasMany(s => s.Components)
               .WithOne(comp => comp.Supplier)
               .HasForeignKey(comp => comp.SupplierId);
    }
}
