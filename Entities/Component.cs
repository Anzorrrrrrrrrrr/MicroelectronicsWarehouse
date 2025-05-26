namespace MicroelectronicsWarehouse.Entities;

public class Component
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; }
    public int Quantity { get; set; }
    public int CategoryId { get; set; }
    public int SupplierId { get; set; }

    public Category Category { get; set; } = null!;
    public Supplier Supplier { get; set; } = null!;
}
