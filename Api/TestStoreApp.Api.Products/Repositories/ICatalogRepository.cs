using TestStoreApp.Api.Products.Model;

namespace TestStoreApp.Api.Products.Repositories
{
    /// <summary>
    /// Defines a contract for managing catalog entities, including operations to retrieve, add, update, and delete
    /// catalogs.
    public interface ICatalogRepository
    {
        /// <summary>
        /// Retrieves a collection of catalogs based on the specified pagination parameters.
        /// </summary>
        /// <param name="paginationRequest">An object that specifies the page number and page size to determine which subset of catalogs to retrieve.
        /// Must not be null.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains an enumerable collection of
        /// Catalog objects for the requested page. The collection is empty if no catalogs are found for the specified
        /// parameters.</returns>
        Task<IEnumerable<Catalog>> GetCatalogsAsync(PaginationRequest paginationRequest);
    
        /// <summary>
        /// Retrieves the catalog that matches the specified unique identifier.
        /// </summary>
        /// <remarks>This method performs an asynchronous operation to fetch the catalog. Ensure that the
        /// provided identifier is valid and corresponds to an existing catalog.</remarks>
        /// <param name="id">The unique identifier of the catalog to retrieve. Must be a positive value.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the catalog associated with the
        /// specified identifier, or null if no catalog is found.</returns>
        Task<Catalog?> GetCatalogByIdAsync(long id);
    
        /// <summary>
        /// Adds a new catalog to the data store.
        /// </summary>
        /// <remarks>Ensure that the provided catalog meets all required validation criteria before
        /// calling this method. The method may throw exceptions if the catalog is invalid or if an error occurs during
        /// the addition process.</remarks>
        /// <param name="catalog">The catalog to add. This parameter cannot be null and must contain valid catalog data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the newly created Catalog
        /// instance.</returns>
        Task<Catalog> AddCatalogAsync(Catalog catalog);

        /// <summary>
        /// Updates the catalog identified by the specified ID with the provided catalog details.
        /// </summary>
        /// <remarks>Ensure that the catalog object contains all required fields for a successful update.
        /// The operation does not return a value upon completion.</remarks>
        /// <param name="id">The unique identifier of the catalog to update.</param>
        /// <param name="catalog">The catalog object containing the updated information. Cannot be null.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when no catalog with the specified ID is found.</exception>
        Task UpdateCatalogAsync(long id, Catalog catalog);

        /// <summary>
        /// Deletes the catalog identified by the specified ID.
        /// </summary>
        /// <param name="id">The unique identifier of the catalog to be deleted. Must be a positive value.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when no catalog with the specified ID is found.</exception>
        Task DeleteCatalogAsync(long id);
    }
}
