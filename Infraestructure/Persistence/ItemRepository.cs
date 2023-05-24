using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Infraestructure.Persistence
{
    public class ItemRepository:GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(StoreContext storeContext) : base(storeContext)
        {
        }

        public List<Item> GetByCategoryId(long categoryId)
        {
            var items = _dbSet.Where(i => i.CategoryId == categoryId);
            if (items == null) {
                return new List<Item>();
            }
            return items.ToList();
        }
    }
}
