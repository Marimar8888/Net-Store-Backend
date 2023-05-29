using Microsoft.AspNetCore.Mvc;
using net_store_backend.Application;
using net_store_backend.Application.Dtos;
using net_store_backend.Application.Services;


namespace net_store_backend.Infraestructure.Rest
{
    [Route("store/[controller]")]
    [ApiController]
    public class ItemsController : GenericCrudController<ItemDto>
    {
        private IItemService _itemService;

        public ItemsController(IItemService service) : base(service)
        {
            _itemService = service;
        }

        [NonAction]
        public override ActionResult<IEnumerable<ItemDto>> Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("/store/categories/{categoryId}/items")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<ItemDto>> GetAllFromCategory(long categoryId) {
            var categoriesDto = ((IItemService)_service).GetAllByCategoryId(categoryId);
            return Ok(categoriesDto);
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<PagedResponse<ItemDto>> Get([FromQuery] string? filter, [FromQuery] PaginationParameters paginationParameters)
        {
            try
            {   
                PagedList<ItemDto> page = _itemService.GetItemByCriteriaPaged(filter, paginationParameters);
                var response = new PagedResponse<ItemDto>
                {
                    CurrentPage = page.CurrentPage,
                    TotalPages = page.TotalPages,
                    PageSize = page.PageSize,
                    TotalCount = page.TotalCount,
                    Data = page 
                };
                return Ok(response);

            }catch (MalformedFilterException) 
            {
                return BadRequest();
            }
        }
    }
}
