using Example.Product.Core.Domain.Models.Items;
using System.Collections.Concurrent;

namespace Example.Product.Infrastructure.Domain.Repositories
{
    public class InMemoryItemRepository : IItemRepository
    {
        private readonly ConcurrentDictionary<Guid, Item> _db = new();

        public async Task<bool> AddOrUpdateAsync(Item item)
        {
            _db[item.Id] = item;

            return true;
        }

        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return _db.Values;
        }

        public async Task<(Item, bool)> GetByIdAsync(Guid id)
        {
            var item = _db[id];

            return (item, item == null);
        }

        public async Task<bool> RemoveAsync(Guid id)
        {
            return _db.TryRemove(id, out _);
        }
    }
}
