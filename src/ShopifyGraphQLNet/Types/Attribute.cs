namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Represents a generic custom attribute.
/// </summary>
public class AttributeObject
{
    /// <summary>
    /// Key or name of the attribute.
    /// </summary>
    public string Key { get; set; } = default!;
    /// <summary>
    /// Value of the attribute.
    /// </summary>
    public string? Value { get; set; }
}