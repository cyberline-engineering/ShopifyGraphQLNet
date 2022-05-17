using System;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Types.Product;
using ShopifyGraphQLNet.Types.Product.Arguments;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi.V202204
{
    public class ProductService : ServiceBase, IProductService
    {
        public ProductService(ShopifyGraphQLNetClient client, ILogger<ProductService> logger): base(client, logger)
        { }

        /// <inheritdoc />
        public Task<QueryResult<ProductConnection>> List(ProductListArguments arguments, ProductConnection? value = default, RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace("List. ProductListArguments: {@productConnectionArguments}", arguments);

            value ??= ProductConnection.Default;

            return client.ExecuteQuery(value, arguments, "products", options: options, ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<Product>> Get(ProductGetArguments arguments, Product? value = default, RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace("List. ProductListArguments: {@productConnectionArguments}", arguments);

            value ??= Product.Default;

            return client.ExecuteQuery(value, arguments, "product", options: options, ct: ct);
        } 
    }
}
