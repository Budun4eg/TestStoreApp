using System.ComponentModel.DataAnnotations;

namespace TestStoreApp.Api.Products.Model
{
    public sealed class Catalog
    {
        public long Id { get; set; }

        [MaxLength(100)]
        public required string Name { get; set; }

        public List<Product> Products { get; set; } = [];
    }
}
