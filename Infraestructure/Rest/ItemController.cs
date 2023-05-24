using Microsoft.AspNetCore.Mvc;
using net_store_backend.Application.Dtos;
using net_store_backend.Application.Services;

namespace net_store_backend.Infraestructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class ItemController : GenericCrudController<ItemDto>
    {
        public ItemController(IItemService service) : base(service)
        {
        }

        [NonAction]
        public override ActionResult<IEnumerable<ItemDto>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/store/categories/{categoryId}/items")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<ItemDto>> GetAllFromCategory(long categoryId) {
            var categories = ((IItemService)_service).GetAllByCategory(categoryId);
            return Ok(categories);
        }


    }
}
