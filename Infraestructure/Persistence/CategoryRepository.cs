using net_store_backend.Domain.Entities;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Infraestructure.Persistence
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly StoreContext _storeContext;

        public CategoryRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public List<Category> GetAll()
        {
            return _storeContext.Categories.ToList<Category>();
        }

        public Category GetById(long id)
        {
            var category = _storeContext.Categories.Find(id);
            if (category == null)
            {
                throw new ElementNotFoundException();
            }
            return category;
        }
    }
}
