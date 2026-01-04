using Example.Product.Core.Application.Commands;
using Example.Product.Core.Application.Queries;
using Example.Product.Core.Application.QueryResults;
using Example.Product.Core.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Product.Service.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public ItemsController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet]
        public Task<AllItems> Get()
        {
            var query = new GetAllItems();

            return _catalogService.QueryAsync(query);
        }

        [HttpGet("{id}")]
        public Task<ItemById> Get(Guid id)
        {
            var query = new GetItemById() { Id = id };

            return _catalogService.QueryAsync(query);
        }

        [HttpPost]
        public Task Post([FromBody] CreateItem command)
        {
            return _catalogService.ProcessAsync(command);
        }

        [HttpPut("{id}")]
        public Task Put(int id, [FromBody] ChangeItemDetails command)
        {
            return _catalogService.ProcessAsync(command);
        }

        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            var command = new RemoveItem() { Id = id };

            return _catalogService.ProcessAsync(command);
        }
    }
}
