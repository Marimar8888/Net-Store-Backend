﻿using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Application.Services
{
    public class ItemService:GenericService<Item, ItemDto>, IItemService
    {
        public ItemService(IItemRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
