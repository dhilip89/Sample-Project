namespace Example.Product.Core.Application.Commands
{
    public sealed class CreateItem : Command
    {
        public required string Name { get; set; }

        public required string Description { get; set; }

        public required decimal Price { get; set; }
    }
}
