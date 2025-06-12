using MicroelectronicsWarehouse.DTOs;

namespace MicroelectronicsWarehouse.Services.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<SupplierDto>> GetAllAsync();
        Task<SupplierDto?> GetByIdAsync(int id);
        Task AddAsync(SupplierDto dto);
        Task UpdateAsync(SupplierDto dto);
        Task DeleteAsync(int id);

        Task<IEnumerable<SupplierDto>> GetAllAsync(RequestParams requestParams);

    }
}
