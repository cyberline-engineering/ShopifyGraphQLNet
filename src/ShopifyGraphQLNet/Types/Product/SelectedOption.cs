namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// Properties used by customers to select a product variant.
/// Products can have multiple options, like different sizes or colors.
/// Requires unauthenticated_read_product_listings access scope.
/// </summary>
public class SelectedOption
{
    /// <summary>
    /// The product option’s name.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// The product option’s value.
    /// </summary>
    public string Value { get; set; } = default!;

    public static readonly SelectedOption Default = new() { Name = String.Empty, Value = String.Empty };
}