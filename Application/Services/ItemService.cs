using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Application.Services
{
    public class ItemService:GenericService<Item,ItemDto>, IItemService
    {
        private IItemRepository _itemRepository;

        public ItemService(IItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _itemRepository = repository;
        }

        public List<ItemDto> GetAllByCategoryId(long categoryId)
        {
            var items = _itemRepository.GetByCategoryId(categoryId);
            return items;
           
        }

        public PagedList<ItemDto> GetItemByCriteriaPaged(string? filter, PaginationParameters paginationParameters)
        {
            var items = _itemRepository.GetItemsByCriteriaPaged(filter, paginationParameters);
            return items;
        }
    }
}
