using System;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Types;

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

        public Task<ProductConnection?> ListProducts(ProductConnectionArguments arguments, CancellationToken ct = default)
        {
            var query = String.Empty;
            return client.ExecuteQuery<ProductConnection>(query, arguments, ct);
        }
    }
}
