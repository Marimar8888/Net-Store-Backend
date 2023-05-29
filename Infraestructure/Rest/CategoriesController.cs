using Microsoft.AspNetCore.Mvc;
using net_store_backend.Application.Dtos;
using net_store_backend.Application.Services;
using net_store_backend.Domain.Services;

namespace net_store_backend.Infraestructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class CategoriesController:GenericCrudController<CategoryDto>
    {
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger) : base(categoryService)
        {
            _logger = logger;
        }

        public override ActionResult<CategoryDto> Insert(CategoryDto categoryDto)
        {
            try {
                return base.Insert(categoryDto);
            }catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image inserting category with {categoryDto.Name} name", categoryDto.Name);
                return BadRequest();
            }
        }

        public override ActionResult<CategoryDto> Update(CategoryDto categoryDto)
        {
            _logger.LogInformation("Invalid image updating category with {categoryDto.Id} Id", categoryDto.Id);
            return BadRequest();
        }
    }
}

