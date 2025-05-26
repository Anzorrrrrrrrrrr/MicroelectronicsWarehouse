namespace MicroelectronicsWarehouse.Entities;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string ContactEmail { get; set; }

    public ICollection<Component> Components { get; set; } = new List<Component>();
}
