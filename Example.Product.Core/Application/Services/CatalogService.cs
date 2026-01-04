using Example.Product.Core.Application.Commands;
using Example.Product.Core.Application.Queries;
using Example.Product.Core.Application.QueryResults;
using Example.Product.Core.Domain.Models.Items;
using Example.Product.Core.Domain.Services;

namespace Example.Product.Core.Application.Services
{
    public sealed class CatalogService : ICatalogService
    {
        private readonly IItemRepository _itemRepository;
        private readonly INotificationService _notificationService;

        public CatalogService(IItemRepository itemRepository, INotificationService notificationService)
        {
            _itemRepository = itemRepository;
            _notificationService = notificationService;
        }

        public async Task ProcessAsync(CreateItem command)
        {
            var newItem = new Item()
            {
                Id = Guid.NewGuid(),
                Name = command.Name,
                Description = command.Description,
                Price = command.Price,
            };

            await _itemRepository.AddOrUpdateAsync(newItem);

            var itemCreatedEvent = new ItemCreated()
            {
                Id = newItem.Id,
                Name = newItem.Name,
                Description = newItem.Description,
                Price = newItem.Price
            };

            await _notificationService.NotifyAsync(itemCreatedEvent);
        }

        public async Task ProcessAsync(ChangeItemDetails command)
        {
            var (item, found) = await _itemRepository.GetByIdAsync(command.Id);

            if (!found)
            {
                return;
            }

            item.Name = command.Name;
            item.Description = command.Description;
            item.Price = command.Price;

            await _itemRepository.AddOrUpdateAsync(item);

            var itemDetailsChangedEvent = new ItemDetailsChanged()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Price = item.Price
            };

            await _notificationService.NotifyAsync(itemDetailsChangedEvent);
        }

        public async Task ProcessAsync(RemoveItem command)
        {
            await _itemRepository.RemoveAsync(command.Id);
        }

        public async Task<AllItems> QueryAsync(GetAllItems query)
        {
            var items = await _itemRepository.GetAllAsync();

            var queryResult = new AllItems()
            {
                Records = items
            };

            return queryResult;
        }

        public async Task<ItemById> QueryAsync(GetItemById query)
        {;
            var (item, found) = await _itemRepository.GetByIdAsync(query.Id);

            var queryResult = new ItemById()
            {
                Id = query.Id,
                Record = item,
                Found = found
            };

            return queryResult;
        }
    }
}
