using System;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types.OnlineStore;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi.V202204
{
    public class OnlineStoreService : ServiceBase, IOnlineStoreService
    {
        public OnlineStoreService(ShopifyGraphQLNetClient client, ILogger<ProductService> logger): base(client, logger)
        { }

        /// <inheritdoc />
        public Task<QueryResult<Shop>> GetShop(Shop? value = default, RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace("GetShop.");

            value ??= Shop.Default;

            return client.ExecuteQuery(value, TypeHelper.EmptyArgs, "shop", options: options, ct: ct);
        } 
    }
}
