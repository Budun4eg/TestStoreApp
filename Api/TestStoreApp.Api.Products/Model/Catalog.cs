using System.ComponentModel.DataAnnotations;

namespace TestStoreApp.Api.Products.Model
{
    /// <summary>
    /// Represents a product catalog that contains a collection of products and associated metadata.
    /// </summary>
    public sealed class Catalog
    {
        /// <summary>
        /// Gets or sets the unique identifier for the entity.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the entity. This property is required and cannot exceed 100 characters.
        /// </summary>
        [MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of products available in the catalog.
        /// </summary>
        public List<Product> Products { get; set; } = [];
    }
}
