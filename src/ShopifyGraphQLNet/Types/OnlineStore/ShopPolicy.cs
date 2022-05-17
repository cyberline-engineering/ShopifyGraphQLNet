using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types.OnlineStore;

/// <summary>
/// Policy that a merchant has configured for their store, such as their refund or privacy policy.
/// </summary>
public class ShopPolicy: INode
{
    /// <summary>
    /// Policy text, maximum size of 64kb.
    /// </summary>
    public string Body { get; set; } = default!;
    /// <summary>
    /// Policy’s handle.
    /// </summary>
    public string Handle { get; set; } = default!;
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// Policy’s title.
    /// </summary>
    public string Title { get; set; } = default!;
    /// <summary>
    /// Public URL to the policy.
    /// </summary>
    public Uri Url { get; set; } = default!;
}