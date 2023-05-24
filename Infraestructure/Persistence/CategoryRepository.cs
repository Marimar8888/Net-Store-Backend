using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Infraestructure.Persistence
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(StoreContext storeContext) : base(storeContext)
        {
        }
    }
}
