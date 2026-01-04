namespace Example.Product.Core.Application.Commands
{
    public sealed class RemoveItem : Command
    {
        public required Guid Id { get; set; }
    }
}
