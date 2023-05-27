using net_store_backend.Application.Dtos;
using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;
using Microsoft.EntityFrameworkCore;


namespace net_store_backend.Infraestructure.Persistence
{
    public class ItemRepository : GenericRepository<Item>, IItemRepository
    {
        private StoreContext _storeContext;
       
        public ItemRepository(StoreContext storeContext) : base(storeContext)
        {
            _storeContext = storeContext;
         
        }

        public override Item GetById(long id)
           {
               var item = _storeContext.Items.Include(i => i.Category).SingleOrDefault(i => i.Id == id);
               if (item == null)
               {
                   throw new ElementNotFoundException();
               }
               return item;
           }

        public override Item Insert(Item item)
        {
            _storeContext.Items.Add(item);
            _storeContext.SaveChanges();
            _storeContext.Entry(item).Reference(i => i.Category).Load();
            return item;
        }

        public override Item Update(Item item)
        {
            _storeContext.Items.Update(item);
            _storeContext.SaveChanges();
            _storeContext.Entry(item).Reference(i  => i.Category).Load();
            return item;
        }

        public List<ItemDto> GetByCategoryId(long categoryId)
        {  
            var items = _dbSet.Where(i => i.CategoryId == categoryId)
                .Select(i => new ItemDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    Price = i.Price,
                    Image = i.Image,
                    CategoryId = categoryId,
                    CategoryName = i.Category.Name
                }).ToList();
            if (items == null) {
                return new List<ItemDto>();
            }
            return items.ToList();
        }

    }
}
