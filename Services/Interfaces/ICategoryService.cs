using MicroelectronicsWarehouse.DTOs;

namespace MicroelectronicsWarehouse.Services.Interfaces
{
    public interface ICategoryService
    {
     
            Task<IEnumerable<CategoryDto>> GetAllAsync();
            Task<CategoryDto?> GetByIdAsync(int id);
            Task AddAsync(CategoryDto dto);
            Task UpdateAsync(CategoryDto dto);
            Task DeleteAsync(int id);
            Task<IEnumerable<CategoryDto>> GetAllAsync(RequestParams requestParams);
     }
}
