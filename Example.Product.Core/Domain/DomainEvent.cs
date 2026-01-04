namespace Example.Product.Core.Domain
{
    public abstract class DomainEvent
    {
        public DateTime OccuredTime { get; set; } = DateTime.UtcNow;
    }
}
