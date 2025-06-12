namespace MicroelectronicsWarehouse.DTOs
{
    public class RequestParams
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string? SearchTerm { get; set; } // для фільтрації
        public string? SortBy { get; set; } // для сортування
    }
}
