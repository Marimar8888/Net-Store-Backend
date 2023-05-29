namespace net_store_backend.Infraestructure.Specs
{
    public class Criterion
    {
        public string Field { get; internal set; }
        public string Operator { get; internal set; }
        public string Value { get; internal set; }
    }
}