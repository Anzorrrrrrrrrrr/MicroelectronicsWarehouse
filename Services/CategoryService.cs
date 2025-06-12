using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Repositories.Interfaces;
using MicroelectronicsWarehouse.Services.Interfaces;

namespace MicroelectronicsWarehouse.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            return category == null ? null : _mapper.Map<CategoryDto>(category);
        }

        public async Task AddAsync(CategoryDto dto)
        {
            var category = _mapper.Map<Category>(dto);
            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(CategoryDto dto)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(dto.Id);
            if (category == null) return;

            _mapper.Map(dto, category);
            _unitOfWork.Categories.Update(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Categories.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync(RequestParams requestParams)
        {
            var query = _unitOfWork.Categories.GetAll(); // IQueryable<Category>

            // 14. Фільтрація
            if (!string.IsNullOrWhiteSpace(requestParams.SearchTerm))
                query = query.Where(c => c.Name.Contains(requestParams.SearchTerm));

            // 15. Сортування
            if (requestParams.SortBy?.ToLower() == "name")
                query = query.OrderBy(c => c.Name);

            // 13. Пагінація
            var paged = await query
                .Skip((requestParams.PageNumber - 1) * requestParams.PageSize)
                .Take(requestParams.PageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(paged);
        }
    }
}
