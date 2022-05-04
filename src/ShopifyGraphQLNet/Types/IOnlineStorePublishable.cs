namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Represents a resource that can be published to the Online Store sales channel.
/// </summary>
public interface IOnlineStorePublishable
{
    /// <summary>
    /// The URL used for viewing the resource on the shop's Online Store.
    /// Returns null if the resource is currently not published to the Online Store sales channel.
    /// </summary>
    public Uri? OnlineStoreUrl { get; set; }
}