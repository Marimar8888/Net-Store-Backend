using Microsoft.AspNetCore.Mvc;
using net_store_backend.Application.Dtos;
using net_store_backend.Application.Services;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Infraestructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class CategoriesController:ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = _categoriesService.GetAllCategories();
            return Ok(categories);
        }
        
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult<CategoryDto> GetCategory(long id) {
            try
            {
                CategoryDto categoryDto = _categoriesService.GetCategory(id);
                return Ok(categoryDto);
            }catch (ElementNotFoundException) { 
                return NotFound();
            }
     
        }

    }
}
