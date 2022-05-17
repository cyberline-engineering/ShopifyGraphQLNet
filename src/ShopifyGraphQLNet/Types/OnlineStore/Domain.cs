using ShopifyGraphQLNet.Helper;

namespace ShopifyGraphQLNet.Types.OnlineStore;

/// <summary>
/// Represents a web address.
/// </summary>
public class Domain
{
    /// <summary>
    /// The host name of the domain (eg: example.com).
    /// </summary>
    public string Host { get; set; } = default!;
    /// <summary>
    /// Whether SSL is enabled or not.
    /// </summary>
    public bool SslEnabled { get; set; }
    /// <summary>
    /// The URL of the domain (eg: https://example.com).
    /// </summary>
    public Uri Url { get; set; } = default!;

    public static readonly Domain Default = new() { Url = TypeHelper.DefaultUrl, Host = String.Empty };
}