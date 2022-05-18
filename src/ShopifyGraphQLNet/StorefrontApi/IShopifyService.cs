using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi;

public interface IShopifyService
{
    ShopifyGraphQLNetClient Client { get; }

    /// <summary>
    /// Returns a specific node (any object that implements the <see href="https://shopify.dev/api/admin-graphql/latest/interfaces/Node">Node</see> interface) by ID,
    /// in accordance with the <see href="https://relay.dev/docs/guides/graphql-server-specification/#object-identification">Relay specification.</see>
    /// This field is commonly used for refetching an object.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <param name="fragment"></param>
    /// <param name="options"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<QueryResult<T>> GetNode<T>(string id, T value, string? fragment = default, RequestOptions? options = default, CancellationToken ct = default);

    /// <summary>
    /// Returns the list of nodes (any objects that implement the <see href="https://shopify.dev/api/admin-graphql/latest/interfaces/Node">Node</see> interface)
    /// with the given IDs, in accordance with the <see href="https://relay.dev/docs/guides/graphql-server-specification/#object-identification">Relay specification.</see>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="ids"></param>
    /// <param name="value"></param>
    /// <param name="fragment"></param>
    /// <param name="options"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<QueryResult<T[]>> GetNodes<T>(string[] ids, T value, string? fragment = default,
        RequestOptions? options = default, CancellationToken ct = default);
}