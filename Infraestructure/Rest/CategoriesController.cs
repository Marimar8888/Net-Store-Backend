using Microsoft.AspNetCore.Mvc;
using net_store_backend.Application.Dtos;
using net_store_backend.Application.Services;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Infraestructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class CategoriesController:GenericCrudController<CategoryDto>
    {
        public CategoriesController(ICategoriesService categoriesService):base(categoriesService)
        {
        }
    }
}

