using Microsoft.EntityFrameworkCore;
using TestStoreApp.Api.Products.Model;

namespace TestStoreApp.Api.Products.Infrastructure
{
    public sealed class ProductsContext(DbContextOptions<ProductsContext> options) : DbContext(options)
    {
        public required DbSet<Product> Products { get; set; }

        public required DbSet<Catalog> Catalogs { get; set; }
    }
}
