using Microsoft.AspNetCore.Mvc;
using TestStoreApp.Api.Products.Repositories;
using TestStoreApp.Api.Products.Model;
using Asp.Versioning;

namespace TestStoreApp.Api.Products.Controllers
{
    /// <summary>
    /// Provides HTTP endpoints to manage product catalogs.
    /// </summary>
    /// <param name="repository">The repository used to perform catalog data operations.</param>
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class CatalogsController(ICatalogRepository repository) : ControllerBase
    {
        /// <summary>
        /// Retrieves a paginated list of catalogs.
        /// </summary>
        /// <param name="paginationRequest">Pagination parameters (page number, page size, etc.).</param>
        /// <returns>A list of catalogs.</returns>
        /// <response code="200">Returns the list of catalogs.</response>
        /// <response code="400">The pagination parameters are invalid.</response>
        [HttpGet]
        [ProducesResponseType<Catalog[]>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
        [EndpointName("GetCatalogList")]
        public async Task<IActionResult> GetCatalogs([FromQuery] PaginationRequest paginationRequest)
        {
            var catalogs = await repository.GetCatalogsAsync(paginationRequest);
            return Ok(catalogs);
        }

        /// <summary>
        /// Retrieves a single catalog by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the catalog to retrieve.</param>
        /// <returns>A catalog with the specified id.</returns>
        /// <response code="200">Returns the catalog with the specified id.</response>
        /// <response code="400">Invalid request parameters.</response>
        /// <response code="404">No catalog found with the specified id.</response>
        [HttpGet("{id:long}")]
        [ProducesResponseType<Catalog[]>(StatusCodes.Status200OK, "application/json")]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [EndpointName("GetSingleCatalog")]
        public async Task<IActionResult> GetCatalog(long id)
        {
            var catalog = await repository.GetCatalogByIdAsync(id);
            if (catalog is null) return NotFound();

            return Ok(catalog);
        }

        /// <summary>
        /// Creates a new catalog.
        /// </summary>
        /// <param name="catalog">The catalog to create.</param>
        /// <returns>Created catalog.</returns>
        /// <response code="201">Returns the created catalog.</response>
        /// <response code="400">The catalog payload is invalid.</response>
        [HttpPost]
        [ProducesResponseType<Catalog>(StatusCodes.Status201Created, "application/json")]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
        public async Task<IActionResult> CreateCatalog([FromBody] Catalog catalog)
        {
            var created = await repository.AddCatalogAsync(catalog);
            return CreatedAtAction(nameof(GetCatalog), new { id = created.Id }, created);
        }

        /// <summary>
        /// Updates an existing catalog.
        /// </summary>
        /// <param name="id">The identifier of the catalog to update. Must match <paramref name="catalog"/>.Id.</param>
        /// <param name="catalog">The catalog payload containing updated values.</param>
        /// <returns>Update result code.</returns>
        /// <response code="204">The catalog was successfully updated.</response>
        /// <response code="400">The request parameters are invalid or the catalog payload is invalid.</response>
        /// <response code="404">No catalog found with the specified id.</response>
        [HttpPut("{id:long}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCatalog(long id, [FromBody] Catalog catalog)
        {
            if (id != catalog.Id) return BadRequest();

            try
            {
                await repository.UpdateCatalogAsync(id, catalog);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Deletes the catalog with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the catalog to delete.</param>
        /// <returns>Delete result code.</returns>
        /// <response code="204">The catalog was successfully deleted.</response>
        /// <response code="400">The request parameters are invalid.</response>
        /// <response code="404">No catalog found with the specified id.</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ProblemDetails>(StatusCodes.Status400BadRequest, "application/problem+json")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCatalog(int id)
        {
            try
            {
                await repository.DeleteCatalogAsync(id);
                return NoContent();

            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
