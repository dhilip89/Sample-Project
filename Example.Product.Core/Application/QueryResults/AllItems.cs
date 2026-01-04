using Example.Product.Core.Domain.Models.Items;

namespace Example.Product.Core.Application.QueryResults
{
    public sealed class AllItems
    {
        public required IEnumerable<Item> Records { get; set; }
    }
}
