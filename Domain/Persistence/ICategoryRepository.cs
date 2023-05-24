

using net_store_backend.Domain.Entities;

namespace net_store_backend.Domain.Persistence
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(long id);
        Category Insert(Category category);
    }
}