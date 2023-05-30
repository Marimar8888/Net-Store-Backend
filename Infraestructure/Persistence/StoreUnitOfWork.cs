using Microsoft.EntityFrameworkCore;
using net_store_backend.Domain.Persistence;

namespace net_store_backend.Infraestructure.Persistence
{
    public class StoreUnitOfWork : UnitOfWork, IStoreUnitOfWork
    {
        public StoreUnitOfWork(StoreContext dbContext) : base(dbContext)
        {
        }
    }
}
