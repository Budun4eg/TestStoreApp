using Microsoft.EntityFrameworkCore;
using TestStoreApp.Api.Products.Infrastructure;
using TestStoreApp.Api.Products.Model;

namespace TestStoreApp.Api.Products.Repositories.Implementation
{
    /// <summary>
    /// Provides methods for managing catalogs, including retrieval, addition, deletion, and updates.
    /// </summary>
    /// <param name="context">The database context used to interact with the catalog data.</param>
    internal class CatalogRepository(ProductsContext context) : ICatalogRepository
    {
        /// <inheritdoc/>
        public async Task<IEnumerable<Catalog>> GetCatalogsAsync(PaginationRequest paginationRequest)
        {
            var items = await context.Catalogs
                .OrderBy(c => c.Id)
                .Skip(paginationRequest.PageIndex * paginationRequest.PageSize)
                .Take(paginationRequest.PageSize)
                .ToListAsync();

            return items;
        }

        /// <inheritdoc/>
        public async Task<Catalog> AddCatalogAsync(Catalog catalog)
        {
            await context.Catalogs.AddAsync(catalog);
            await context.SaveChangesAsync();

            return catalog;
        }

        /// <inheritdoc/>
        public async Task DeleteCatalogAsync(long id)
        {
            var item = await context.Catalogs.SingleOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Catalog with id {id} not found.");

            context.Catalogs.Remove(item);
            await context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task<Catalog?> GetCatalogByIdAsync(long id)
        {
            return await context.Catalogs.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task UpdateCatalogAsync(long id, Catalog catalog)
        {
            var item = await context.Catalogs.SingleOrDefaultAsync(x => x.Id == id) ?? throw new KeyNotFoundException($"Catalog with id {id} not found.");

            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(catalog);

            await context.SaveChangesAsync();
        }
    }
}
