using System;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi.V202204
{
    public class ProductService: IProductService
    {
        private readonly ShopifyGraphQLNetClient client;
        private readonly ILogger<ProductService> logger;

        public ProductService(ShopifyGraphQLNetClient client, ILogger<ProductService> logger)
        {
            this.client = client;
            this.logger = logger;
        }

        public Task<QueryResult<ProductConnection>> ListProducts(ProductConnectionArguments arguments, CancellationToken ct = default)
        {
            logger.LogTrace("ListProducts. ProductConnectionArguments: {@productConnectionArguments}", arguments);

            var root = "products";

            return client.ExecuteQuery<ProductConnection>(ProductConnection.Default, root, arguments, ct);
        }
    }
}
