using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Application.Services
{
    public class CategoryService : ICategoriesService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<CategoryDto> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDto  = _mapper.Map<List<CategoryDto>>(categories);
            return categoriesDto;
        }

        public CategoryDto GetCategory(long id)
        {
            var category = _categoryRepository.GetById(id);
            return _mapper.Map<CategoryDto>(category);
        }

        public CategoryDto InsertCategory(CategoryDto categoryDto)
        {
            Category category = _mapper.Map<Category>(categoryDto);
            category = _categoryRepository.Insert(category);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
