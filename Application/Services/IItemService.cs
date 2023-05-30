using net_store_backend.Application.Dtos;

namespace net_store_backend.Application.Services
{
    public interface IItemService : IGenericService<ItemDto>
    {
        List<ItemDto> GetAllByCategoryId(long categoryId);
        PagedList<ItemDto> GetItemByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
        List<ItemDto> postNewItemsFromCategory(long categoryId, List<ItemDto> items);
    }
}
