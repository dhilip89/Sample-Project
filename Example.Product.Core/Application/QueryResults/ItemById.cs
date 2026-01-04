using Example.Product.Core.Domain.Models.Items;

namespace Example.Product.Core.Application.QueryResults
{
    public sealed class ItemById
    {
        public required Guid Id { get; set; }

        public Item? Record { get; set; }

        public required bool Found { get; set; }
    }
}
