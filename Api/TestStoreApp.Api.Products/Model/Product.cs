using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestStoreApp.Api.Products.Model
{
    /// <summary>
    /// Represents a product available in a catalog, including its identifying information, descriptive details, price,
    /// and catalog association.
    /// </summary>
    [Index(nameof(Name), IsUnique = true)]
    public sealed class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the entity. This property is required and must not exceed 100 characters.
        /// </summary>
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the catalog.
        /// </summary>
        public required long CatalogId { get; set; }

        /// <summary>
        /// Gets or sets the catalog associated with the current instance.
        /// </summary>
        public Catalog Catalog { get; set; } = null!;
    }
}
