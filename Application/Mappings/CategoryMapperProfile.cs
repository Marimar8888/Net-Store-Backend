using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;

namespace net_store_backend.Application.Mappings
{
    public class CategoryMapperProfile:Profile
    {
        public CategoryMapperProfile() {
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
        }
    }
}
