using AutoMapper;
using net_store_backend.Application.Dtos;
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

       
    }
}
