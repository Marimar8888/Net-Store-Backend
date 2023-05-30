namespace net_store_backend.Domain.Persistence
{
    public interface IUnitOfWork
    {
        IWork Init();
    }
}
