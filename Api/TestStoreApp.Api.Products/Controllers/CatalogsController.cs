using Microsoft.AspNetCore.Mvc;
using TestStoreApp.Api.Products.Repositories;
using TestStoreApp.Api.Products.Model;
using Asp.Versioning;

namespace TestStoreApp.Api.Products.Controllers
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public sealed class CatalogsController(ICatalogRepository repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCatalogs([FromQuery] PaginationRequest paginationRequest)
        {
            var catalogs = await repository.GetCatalogsAsync(paginationRequest);
            return Ok(catalogs);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetCatalog(long id)
        {
            var catalog = await repository.GetCatalogByIdAsync(id);
            if (catalog is null) return NotFound();

            return Ok(catalog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCatalog([FromBody] Catalog catalog)
        {
            var created = await repository.AddCatalogAsync(catalog);
            return CreatedAtAction(nameof(GetCatalog), new { id = created.Id }, created);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateCatalog(long id, [FromBody] Catalog catalog)
        {
            if (id != catalog.Id) return BadRequest();

            await repository.UpdateCatalogAsync(id, catalog);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCatalog(int id)
        {
            await repository.DeleteCatalogAsync(id);
            return NoContent();
        }
    }
}
