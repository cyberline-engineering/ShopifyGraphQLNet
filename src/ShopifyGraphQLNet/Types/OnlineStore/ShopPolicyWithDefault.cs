namespace ShopifyGraphQLNet.Types.OnlineStore;

/// <summary>
/// A policy for the store that comes with a default value, such as a subscription policy.
/// If the merchant hasn't configured a policy for their store, then the policy will return the default value.
/// Otherwise, the policy will return the merchant-configured value.
/// </summary>
public class ShopPolicyWithDefault
{
    /// <summary>
    /// Policy text, maximum size of 64kb.
    /// </summary>
    public string Body { get; set; } = default!;
    /// <summary>
    /// Policy’s handle.
    /// </summary>
    public string Handle { get; set; } = default!;
    /// <summary>
    /// The unique identifier of the policy. A default policy doesn't have an ID.
    /// </summary>
    public string? Id { get; set; }
    /// <summary>
    /// Policy’s title.
    /// </summary>
    public string Title { get; set; } = default!;
    /// <summary>
    /// Public URL to the policy.
    /// </summary>
    public Uri Url { get; set; } = default!;
}