namespace Example.Product.Core.Domain.Models.Items
{
    public sealed class ItemDetailsChanged : DomainEvent
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }
    }
}
