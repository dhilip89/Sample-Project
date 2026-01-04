namespace Example.Product.Core.Domain.Models.Items
{
    public sealed class ItemRemoved : DomainEvent
    {
        public required Guid Id { get; set; }
    }
}
