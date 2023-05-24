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
        }
    }
}
