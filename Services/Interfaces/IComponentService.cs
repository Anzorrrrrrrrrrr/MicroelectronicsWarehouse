using MicroelectronicsWarehouse.DTOs;

namespace MicroelectronicsWarehouse.Services.Interfaces
{
    public interface IComponentService
    {
        Task<IEnumerable<ComponentDto>> GetAllAsync();
        Task<ComponentDto?> GetByIdAsync(int id);
        Task AddAsync(ComponentDto dto);
        Task UpdateAsync(ComponentDto dto);
        Task DeleteAsync(int id);
    }
}
