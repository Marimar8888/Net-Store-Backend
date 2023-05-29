using net_store_backend.Application;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;

namespace net_store_backend.Domain.Persistence
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        List<ItemDto> GetByCategoryId(long categoryId);
        PagedList<Item> GetItemsByCriteriaPaged(string? filter, PaginationParameters paginationParameters);
    }
}
