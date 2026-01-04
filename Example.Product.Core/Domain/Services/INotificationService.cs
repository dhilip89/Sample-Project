namespace Example.Product.Core.Domain.Services
{
    public interface INotificationService
    {
        Task NotifyAsync(DomainEvent domainEvent);
    }
}
