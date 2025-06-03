using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Repositories.Interfaces;
using MicroelectronicsWarehouse.Services.Interfaces;



namespace MicroelectronicsWarehouse.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _unitOfWork.Suppliers.GetAllAsync();
            return suppliers.Select(s => new SupplierDto
            {
                Id = s.Id,
                Name = s.Name,
                ContactEmail = s.ContactEmail
            });
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
            if (supplier == null) return null;

            return new SupplierDto
            {
                Id = supplier.Id,
                Name = supplier.Name,
                ContactEmail = supplier.ContactEmail
            };
        }

        public async Task AddAsync(SupplierDto dto)
        {
            var supplier = new Supplier
            {
                Name = dto.Name,
                ContactEmail = dto.ContactEmail
            };

            await _unitOfWork.Suppliers.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(SupplierDto dto)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(dto.Id);
            if (supplier == null) return;

            supplier.Name = dto.Name;
            supplier.ContactEmail = dto.ContactEmail;

            _unitOfWork.Suppliers.Update(supplier);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Suppliers.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
