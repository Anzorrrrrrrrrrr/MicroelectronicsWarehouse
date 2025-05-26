namespace MicroelectronicsWarehouse.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Component> Components { get; set; } = new List<Component>();
}
