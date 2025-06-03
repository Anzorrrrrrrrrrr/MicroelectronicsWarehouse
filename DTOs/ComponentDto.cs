namespace MicroelectronicsWarehouse.DTOs
{
    public class ComponentDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}
