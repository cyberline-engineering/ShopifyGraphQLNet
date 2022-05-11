using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.StorefrontApi.V202204;

namespace ShopifyGraphQLNet.StorefrontApi;

public abstract class ServiceBase
{
    protected ShopifyGraphQLNetClient client;
    protected ILogger<ProductService> logger;

    protected ServiceBase(ShopifyGraphQLNetClient client, ILogger<ProductService> logger)
    {
        this.client = client;
        this.logger = logger;
    }
}