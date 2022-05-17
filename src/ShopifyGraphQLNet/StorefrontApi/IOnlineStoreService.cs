using ShopifyGraphQLNet.Types.OnlineStore;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi;

public interface IOnlineStoreService
{
    /// <summary>
    /// The shop associated with the storefront access token.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<QueryResult<Shop>> GetShop(Shop? value = default, RequestOptions? options = default, CancellationToken ct = default);
}