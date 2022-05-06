namespace ShopifyGraphQLNet.Types;

/// <summary>
/// An auto-generated type for paginating through multiple objects.
/// </summary>
/// <typeparam name="T"></typeparam>
public class Connection<T>
{
    /// <summary>
    /// A list of edges.
    /// </summary>
    public Edge<T>[] Edges { get; set; } = default!;
    /// <summary>
    /// A list of the nodes.
    /// </summary>
    public T[] Nodes { get; set; } = default!;
    /// <inheritdoc cref="PageInfo"/>
    public PageInfo PageInfo { get; set; } = default!;
}

/// <summary>
/// An auto-generated type which holds one object and a cursor during pagination.
/// </summary>
public class Edge<T>
{
    /// <summary>
    /// A cursor for use in pagination.
    /// </summary>
    public string Cursor { get; set; } = default!;
    /// <summary>
    /// The item at the end of Edge.
    /// </summary>
    public T Node { get; set; } = default!;
}

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