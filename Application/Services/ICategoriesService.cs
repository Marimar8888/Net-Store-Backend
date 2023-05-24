using net_store_backend.Application.Dtos;

namespace net_store_backend.Application.Services
{
    public interface ICategoriesService
    {
        void DeleteCategory(long id);
        List<CategoryDto> GetAllCategories();
        CategoryDto GetCategory(long id);
        CategoryDto InsertCategory(CategoryDto categoryDto);
        CategoryDto UpdateCategory(CategoryDto categoryDto);
    }
}