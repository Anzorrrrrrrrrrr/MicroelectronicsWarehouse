using AutoMapper;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Repositories.Interfaces;
using MicroelectronicsWarehouse.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MicroelectronicsWarehouse.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ComponentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ComponentDto>> GetAllAsync()
        {
            var components = await _unitOfWork.Components.GetAllAsync();
            return _mapper.Map<IEnumerable<ComponentDto>>(components);
        }

        public async Task<ComponentDto?> GetByIdAsync(int id)
        {
            var c = await _unitOfWork.Components.GetByIdAsync(id);
            return c == null ? null : _mapper.Map<ComponentDto>(c);
        }

        public async Task AddAsync(ComponentDto dto)
        {
            var component = _mapper.Map<Component>(dto);
            await _unitOfWork.Components.AddAsync(component);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(ComponentDto dto)
        {
            var component = await _unitOfWork.Components.GetByIdAsync(dto.Id);
            if (component == null) return;

            _mapper.Map(dto, component);
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

        public async Task<IEnumerable<ComponentDto>> GetAllAsync(RequestParams requestParams)
        {
            var query = _unitOfWork.Components.GetAll(); // IQueryable<Component>

            // 14. Фільтрація
            if (!string.IsNullOrWhiteSpace(requestParams.SearchTerm))
                query = query.Where(c => c.Name.Contains(requestParams.SearchTerm));

            // 15. Сортування
            if (requestParams.SortBy?.ToLower() == "name")
                query = query.OrderBy(c => c.Name);
            else if (requestParams.SortBy?.ToLower() == "quantity")
                query = query.OrderByDescending(c => c.Quantity);

            // 13. Пагінація
            var paged = await query
                .Skip((requestParams.PageNumber - 1) * requestParams.PageSize)
                .Take(requestParams.PageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ComponentDto>>(paged);
        }
    }
}
