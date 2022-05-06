using System.ComponentModel;

namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// An auto-generated type for paginating through multiple Products.
/// </summary>
public class ProductConnection: Connection<Product>
{
    /// <summary>
    /// A list of available filters.
    /// </summary>
    public Filter[] Filters { get; set; } = default!;
}