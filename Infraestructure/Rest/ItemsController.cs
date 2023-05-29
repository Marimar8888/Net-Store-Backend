using Microsoft.AspNetCore.Mvc;
using net_store_backend.Application;
using net_store_backend.Application.Dtos;
using net_store_backend.Application.Services;
using net_store_backend.Domain.Services;



namespace net_store_backend.Infraestructure.Rest
{

    [Route("store/[controller]")]
    [ApiController]
    public class ItemsController : GenericCrudController<ItemDto>
    {
        private readonly ILogger<ItemsController> _logger;

        private IItemService _itemService;

        public ItemsController(IItemService service, ILogger<ItemsController> logger) : base(service)
        {
            _itemService = service;
            _logger = logger;
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
        public override ActionResult<ItemDto> Insert(ItemDto dto)
        {
            try
            {
                return base.Insert(dto);
            }
            catch (InvalidImageException)
            {
                _logger.LogInformation("Invalid image inserting item with {dto.Name} name", dto.Name);
                return BadRequest();
            }
        }

        public override ActionResult<ItemDto> Update(ItemDto dto)
        {
            _logger.LogInformation("Invalid image updating item with {dto.Id} Id", dto.Id);
            return BadRequest();
        }
    }
}
