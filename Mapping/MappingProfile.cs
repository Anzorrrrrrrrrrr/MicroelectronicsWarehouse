using AutoMapper;
using MicroelectronicsWarehouse.DTOs;
using MicroelectronicsWarehouse.Entities;

namespace MicroelectronicsWarehouse.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Component, ComponentDto>().ReverseMap();
            CreateMap<Supplier, SupplierDto>().ReverseMap();
        }
    }
}
