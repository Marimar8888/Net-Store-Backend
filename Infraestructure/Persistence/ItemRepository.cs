using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;


namespace net_store_backend.Infraestructure.Persistence
{
    public class ItemRepository:GenericRepository<Item>, IItemRepository
    {
        public ItemRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
