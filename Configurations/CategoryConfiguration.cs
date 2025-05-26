using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MicroelectronicsWarehouse.Entities;

namespace MicroelectronicsWarehouse.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(c => c.Components)
               .WithOne(comp => comp.Category)
               .HasForeignKey(comp => comp.CategoryId);
    }
}
