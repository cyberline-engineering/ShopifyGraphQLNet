namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// Product property names like "Size", "Color", and "Material" that the customers can select. Variants are selected based on permutations of these options. 255 characters limit each.
/// </summary>
public class ProductOption: INode
{
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// The product option’s name.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// The corresponding value to the product option name.
    /// </summary>
    public string[] Values { get; set; } = default!;
}