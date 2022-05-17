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

    public static readonly ProductConnection Default = new()
        { Nodes = new[] { Product.Default }, _arguments = ConnectionArguments.Default };
}