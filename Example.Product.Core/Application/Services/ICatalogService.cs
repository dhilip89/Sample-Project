using Example.Product.Core.Application.Commands;
using Example.Product.Core.Application.Queries;
using Example.Product.Core.Application.QueryResults;

namespace Example.Product.Core.Application.Services
{
    public interface ICatalogService
    {
        Task ProcessAsync(CreateItem command);

        Task ProcessAsync(ChangeItemDetails command);

        Task ProcessAsync(RemoveItem command);

        Task<AllItems> QueryAsync(GetAllItems query);

        Task<ItemById> QueryAsync(GetItemById query);
    }
}
