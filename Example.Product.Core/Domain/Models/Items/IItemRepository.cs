namespace Example.Product.Core.Domain.Models.Items
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();

        Task<(Item, bool)> GetByIdAsync(Guid id);

        Task<bool> RemoveAsync(Guid id);

        Task<bool> AddOrUpdateAsync(Item item);
    }
}
