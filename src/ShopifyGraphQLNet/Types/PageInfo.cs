namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Returns information about pagination in a connection,
/// in accordance with the <see href="https://relay.dev/graphql/connections.htm#sec-undefined.PageInfo">Relay specification</see>
/// </summary>
public class PageInfo
{
    /// <summary>
    /// Whether there are more pages to fetch following the current page.
    /// </summary>
    public bool HasNextPage { get; set; }
    /// <summary>
    /// Whether there are any pages prior to the current page.
    /// </summary>
    public bool HasPreviousPage { get; set; }
    /// <summary>
    /// The cursor corresponding to the first node in edges.
    /// </summary>
    public string? StartCursor { get; set; }
    /// <summary>
    /// The cursor corresponding to the last node in edges.
    /// </summary>
    public string? EndCursor { get; set; }
}