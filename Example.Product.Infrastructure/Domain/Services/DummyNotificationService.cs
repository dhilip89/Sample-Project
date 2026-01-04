using Example.Product.Core.Domain;
using Example.Product.Core.Domain.Models.Items;
using Example.Product.Core.Domain.Services;

namespace Example.Product.Infrastructure.Domain.Services
{
    public sealed class DummyNotificationService : INotificationService
    {
        public async Task NotifyAsync(DomainEvent domainEvent)
        {
            if (domainEvent == null)
            {
                return;
            }

            if (domainEvent is ItemCreated)
            {
                var e = (ItemCreated)domainEvent;

                Console.WriteLine(
                    "[{0}] Item Created:\n  Id = {1}\n  Name = {2}\n  Description = {3}\n  Price = {4}\n\n",
                    e.OccuredTime,
                    e.Id,
                    e.Name,
                    e.Description,
                    e.Price
                 );
            }

            if (domainEvent is ItemDetailsChanged)
            {
                var e = (ItemDetailsChanged)domainEvent;

                Console.WriteLine(
                    "[{0}] Item Details Changed:\n  Id = {1}\n  Name = {2}\n  Description = {3}\n  Price = {4}\n\n",
                    e.OccuredTime,
                    e.Id,
                    e.Name,
                    e.Description,
                    e.Price
                 );
            }

            if (domainEvent is ItemRemoved)
            {
                var e = (ItemRemoved)domainEvent;

                Console.WriteLine(
                    "[{0}] Item Removed:\n  Id = {1}\n\n",
                    e.OccuredTime,
                    e.Id
                 );
            }
        }
    }
}
