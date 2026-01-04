namespace Example.Product.Core.Application.Queries
{
    public sealed class GetItemById : Query
    {
        public required Guid Id { get; set; }
    }
}
