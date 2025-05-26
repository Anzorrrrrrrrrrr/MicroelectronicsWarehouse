using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroelectronicsWarehouse.Entities;

namespace MicroelectronicsWarehouse.Configurations;

public class ComponentConfiguration : IEntityTypeConfiguration<Component>
{
    public void Configure(EntityTypeBuilder<Component> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Property(c => c.Quantity).HasDefaultValue(0);

        builder.HasOne(c => c.Category)
               .WithMany(cat => cat.Components)
               .HasForeignKey(c => c.CategoryId);

        builder.HasOne(c => c.Supplier)
               .WithMany(s => s.Components)
               .HasForeignKey(c => c.SupplierId);
    }
}
