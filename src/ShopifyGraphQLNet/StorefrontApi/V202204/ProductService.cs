using System;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Product;
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

        /// <summary>
        /// List of the shop’s products.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<QueryResult<ProductConnection>> List(ProductListArguments arguments, CancellationToken ct = default)
        {
            logger.LogTrace("List. ProductListArguments: {@productConnectionArguments}", arguments);

            var root = "products";

            return client.ExecuteQuery<ProductConnection>(ProductConnection.Default, root, arguments, ct);
        }

        /// <summary>
        /// Fetch a specific Product by one of its unique attributes.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<QueryResult<Product>> Get(ProductGetArguments arguments, CancellationToken ct = default)
        {
            logger.LogTrace("List. ProductListArguments: {@productConnectionArguments}", arguments);

            var root = "product";

            return client.ExecuteQuery<Product>(Product.Default, root, arguments, ct);
        }
    }
}
