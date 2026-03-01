using System.ComponentModel;

namespace TestStoreApp.Api.Products.Model
{
    /// <summary>
    /// Represents a request for paginated results, specifying the number of items per page and the page index.
    /// </summary>
    /// <param name="PageSize">The number of items to return in a single page of results. Must be a positive integer.</param>
    /// <param name="PageIndex">The index of the page of results to return. Must be a non-negative integer.</param>
    public record PaginationRequest(
        [property:DefaultValue(10)] int PageSize = 10,
        [property:DefaultValue(0)] int PageIndex = 0
    );
}
