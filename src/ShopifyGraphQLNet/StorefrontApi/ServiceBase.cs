using Microsoft.Extensions.Logging;

namespace ShopifyGraphQLNet.StorefrontApi;

public abstract class ServiceBase: IShopifyService
{
    protected ShopifyGraphQLNetClient client;
    protected ILogger logger;

    protected ServiceBase(ShopifyGraphQLNetClient client, ILogger logger)
    {
        this.client = client;
        this.logger = logger;
    }

    public void ConfigureShopifyClient(ShopifyGraphQLNetClientConfig config)
    {
        client.HttpClient.ConfigureShopifyClient(config);
    }
}