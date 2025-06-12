using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Entities;
using MicroelectronicsWarehouse.Repositories.Interfaces;
using MicroelectronicsWarehouse.Services.Interfaces;

namespace MicroelectronicsWarehouse.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SupplierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SupplierDto>> GetAllAsync()
        {
            var suppliers = await _unitOfWork.Suppliers.GetAllAsync();
            return _mapper.Map<IEnumerable<SupplierDto>>(suppliers);
        }

        public async Task<SupplierDto?> GetByIdAsync(int id)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(id);
            return supplier == null ? null : _mapper.Map<SupplierDto>(supplier);
        }

        public async Task AddAsync(SupplierDto dto)
        {
            var supplier = _mapper.Map<Supplier>(dto);
            await _unitOfWork.Suppliers.AddAsync(supplier);
            await _unitOfWork.CompleteAsync();
        }

        public async Task UpdateAsync(SupplierDto dto)
        {
            var supplier = await _unitOfWork.Suppliers.GetByIdAsync(dto.Id);
            if (supplier == null) return;

            _mapper.Map(dto, supplier);
            _unitOfWork.Suppliers.Update(supplier);
            await _unitOfWork.CompleteAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Suppliers.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
        }

       
        public async Task<IEnumerable<SupplierDto>> GetAllAsync(RequestParams requestParams)
        {
            var query = _unitOfWork.Suppliers.GetAll(); // IQueryable<Supplier>

            // Фільтрація
            if (!string.IsNullOrWhiteSpace(requestParams.SearchTerm))
                query = query.Where(s => s.Name.Contains(requestParams.SearchTerm));

            // Сортування
            if (requestParams.SortBy?.ToLower() == "name")
                query = query.OrderBy(s => s.Name);
            else if (requestParams.SortBy?.ToLower() == "email")
                query = query.OrderBy(s => s.ContactEmail);

            // Пагінація
            var paged = await query
                .Skip((requestParams.PageNumber - 1) * requestParams.PageSize)
                .Take(requestParams.PageSize)
                .ToListAsync();

            return _mapper.Map<IEnumerable<SupplierDto>>(paged);
        }
    }
}
