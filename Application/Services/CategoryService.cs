using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;
using net_store_backend.Domain.Services;

namespace net_store_backend.Application.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IImageVerifier _imageVerifier;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, IImageVerifier imageVerifier) : base(categoryRepository, mapper)
        {
            _categoryRepository = categoryRepository;
            _imageVerifier = imageVerifier;
        }

        public override CategoryDto Insert(CategoryDto dto)
        {
            if(!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Insert(dto);
            
        }
        public override CategoryDto Update(CategoryDto dto)
        {
            if (!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Update(dto);
        }
    }
}
