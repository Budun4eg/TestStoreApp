using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestStoreApp.Api.Products.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public sealed class Product
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public required long CatalogId { get; set; }

        public Catalog Catalog { get; set; } = null!;
    }
}
