using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;

namespace net_store_backend.Application.Mappings
{
    public class ItemMapperProfile:Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>();
            CreateMap<PagedList<Item>, PagedList<ItemDto>>()
                .ConvertUsing((src, des, context) =>
                {
                    var items = context.Mapper.Map<List<ItemDto>>(src);
                    return new PagedList<ItemDto>(items, src.TotalCount, src.CurrentPage, src.PageSize);
                });
        }
    }
}
