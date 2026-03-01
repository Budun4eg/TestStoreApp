using TestStoreApp.Api.Products.Infrastructure;
using TestStoreApp.Api.Products.Repositories;
using TestStoreApp.Api.Products.Repositories.Implementation;

namespace TestStoreApp.Api.Products
{
    /// <summary>
    /// Provides extension methods for configuring application services in the host application builder.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Configures application services.
        /// </summary>
        /// <param name="builder">The <see cref="IHostApplicationBuilder"/> used to configure the application's services.</param>
        public static void AddApplicationServices(this IHostApplicationBuilder builder)
        {
            builder.Services.AddNpgsql<ProductsContext>(builder.Configuration.GetConnectionString("ProductDB"));
            builder.Services.AddScoped<ICatalogRepository, CatalogRepository>();
        }
    }
}
