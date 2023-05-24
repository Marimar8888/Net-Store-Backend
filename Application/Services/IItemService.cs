﻿using net_store_backend.Application.Dtos;

namespace net_store_backend.Application.Services
{
    public interface IItemService : IGenericService<ItemDto>
    {
        List<ItemDto> GetAllByCategory(long categoryId);
    }
}
