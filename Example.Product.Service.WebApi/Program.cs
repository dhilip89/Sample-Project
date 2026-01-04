using Example.Product.Core.Application.Services;
using Example.Product.Core.Domain.Models.Items;
using Example.Product.Core.Domain.Services;
using Example.Product.Infrastructure.Domain.Repositories;
using Example.Product.Infrastructure.Domain.Services;

namespace Example.Product.Service.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddSingleton<IItemRepository, InMemoryItemRepository>();
            builder.Services.AddSingleton<INotificationService, DummyNotificationService>();
            builder.Services.AddSingleton<ICatalogService, CatalogService>();

            builder.Services.AddControllers();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
