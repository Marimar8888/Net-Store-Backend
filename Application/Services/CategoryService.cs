﻿using AutoMapper;
using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Application.Services
{
    public class CategoryService : GenericService<Category, CategoryDto>, ICategoriesService
    {


        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper): base(categoryRepository, mapper)
        {

        }
    }
}
