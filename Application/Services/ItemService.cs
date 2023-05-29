using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;
using net_store_backend.Domain.Services;

namespace net_store_backend.Application.Services
{
    public class ItemService:GenericService<Item,ItemDto>, IItemService
    {
        private IItemRepository _itemRepository;
        private readonly IImageVerifier _imageVerifier;

        public ItemService(IItemRepository repository, IMapper mapper, IImageVerifier imageVerifier) : base(repository, mapper)
        {
            _itemRepository = repository;
            _imageVerifier = imageVerifier;
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
        public override ItemDto Insert(ItemDto dto)
        {
            if (!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Insert(dto);

        }
        public override ItemDto Update(ItemDto dto)
        {
            if (!_imageVerifier.IsImage(dto.Image))
                throw new InvalidImageException();
            return base.Update(dto);
        }
    }
}
