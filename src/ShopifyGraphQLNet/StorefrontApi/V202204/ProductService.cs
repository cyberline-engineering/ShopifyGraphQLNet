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
        public Task<QueryResult<ProductConnection>> List(ProductListArguments arguments, ProductConnection? value = default, CancellationToken ct = default)
        {
            logger.LogTrace("List. ProductListArguments: {@productConnectionArguments}", arguments);

            value ??= new ProductConnection
            {
                Nodes = new[] { Product.Default }
            };
            value._arguments = arguments;

            return client.ExecuteQuery(value, "products", ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<Product>> Get(ProductGetArguments arguments, Product? value = default, CancellationToken ct = default)
        {
            logger.LogTrace("List. ProductListArguments: {@productConnectionArguments}", arguments);

            value ??= Product.CreateDefault();
            value._arguments = arguments;

            return client.ExecuteQuery(value, "product", ct: ct);
        }
    }
}
