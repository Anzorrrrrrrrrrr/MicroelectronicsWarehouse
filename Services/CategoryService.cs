using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Repositories.Interfaces;
using MicroelectronicsWarehouse.Services.Interfaces;



namespace MicroelectronicsWarehouse.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name
            });
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);
            if (category == null) return null;

            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task AddAsync(CategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            await _unitOfWork.Categories.AddAsync(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(CategoryDto dto)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(dto.Id);
            if (category == null) return;

            category.Name = dto.Name;

            _unitOfWork.Categories.Update(category);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Categories.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }
    }
}
