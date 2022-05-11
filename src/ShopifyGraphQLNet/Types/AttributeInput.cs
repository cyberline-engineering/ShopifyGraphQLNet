namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Specifies the input fields required for an attribute.
/// </summary>
public class AttributeInput
{
    /// <summary>
    /// Key or name of the attribute.
    /// </summary>
    public string Key { get; set; } = default!;
    /// <summary>
    /// Value of the attribute.
    /// </summary>
    public string Value { get; set; } = default!;
}