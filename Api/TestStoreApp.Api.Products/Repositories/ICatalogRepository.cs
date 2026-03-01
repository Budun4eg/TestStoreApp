using TestStoreApp.Api.Products.Model;

namespace TestStoreApp.Api.Products.Repositories
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<Catalog>> GetCatalogsAsync(PaginationRequest paginationRequest);
    
        Task<Catalog> GetCatalogByIdAsync(long id);
    
        Task<Catalog> AddCatalogAsync(Catalog catalog);
    
        Task UpdateCatalogAsync(long id, Catalog catalog);
    
        Task DeleteCatalogAsync(long id);
    }
}
