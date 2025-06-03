using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Repositories.Interfaces;
using MicroelectronicsWarehouse.Services.Interfaces;

namespace MicroelectronicsWarehouse.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ComponentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ComponentDto>> GetAllAsync()
        {
            var components = await _unitOfWork.Components.GetAllAsync();
            return components.Select(c => new ComponentDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Quantity = c.Quantity,
                CategoryId = c.CategoryId,
                SupplierId = c.SupplierId
            });
        }

        public async Task<ComponentDto?> GetByIdAsync(int id)
        {
            var c = await _unitOfWork.Components.GetByIdAsync(id);
            if (c == null) return null;

            return new ComponentDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Quantity = c.Quantity,
                CategoryId = c.CategoryId,
                SupplierId = c.SupplierId
            };
        }

        public async Task AddAsync(ComponentDto dto)
        {
            var component = new Component
            {
                Name = dto.Name,
                Description = dto.Description,
                Quantity = dto.Quantity,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId
            };

            await _unitOfWork.Components.AddAsync(component);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(ComponentDto dto)
        {
            var component = await _unitOfWork.Components.GetByIdAsync(dto.Id);
            if (component == null) return;

            component.Name = dto.Name;
            component.Description = dto.Description;
            component.Quantity = dto.Quantity;
            component.CategoryId = dto.CategoryId;
            component.SupplierId = dto.SupplierId;

            _unitOfWork.Components.Update(component);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var component = await _unitOfWork.Components.GetByIdAsync(id);
            if (component == null) return;

            _unitOfWork.Components.Remove(component);
            await _unitOfWork.CompleteAsync();
        }
    }
}
