namespace net_store_backend.Infraestructure.Specs
{
    public interface ISpecificationParser<T>
    {
       Specification<T> ParseSpecification(string filter);

    }
}