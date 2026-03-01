using Microsoft.EntityFrameworkCore;
using TestStoreApp.Api.Products.Infrastructure;
using TestStoreApp.Api.Products.Model;

namespace TestStoreApp.Api.Products.Repositories.Implementation
{
    public class CatalogRepository(ProductsContext context) : ICatalogRepository
    {
        public async Task<IEnumerable<Catalog>> GetCatalogsAsync(PaginationRequest paginationRequest)
        {
            var items = await context.Catalogs
                .OrderBy(c => c.Id)
                .Skip(paginationRequest.PageIndex * paginationRequest.PageSize)
                .Take(paginationRequest.PageSize)
                .ToListAsync();

            return items;
        }

        public async Task<Catalog> AddCatalogAsync(Catalog catalog)
        {
            await context.Catalogs.AddAsync(catalog);
            await context.SaveChangesAsync();

            return catalog;
        }

        public async Task DeleteCatalogAsync(long id)
        {
            var item = await context.Catalogs.SingleOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Catalog with id {id} not found.");

            context.Catalogs.Remove(item);
            await context.SaveChangesAsync();
        }

        public async Task<Catalog> GetCatalogByIdAsync(long id)
        {
            return await context.Catalogs.SingleOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Catalog with id {id} not found.");
        }

        public async Task UpdateCatalogAsync(long id, Catalog catalog)
        {
            var item = await context.Catalogs.SingleOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Catalog with id {id} not found.");

            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(catalog);

            await context.SaveChangesAsync();
        }
    }
}
