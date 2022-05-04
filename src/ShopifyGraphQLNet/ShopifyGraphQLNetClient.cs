using Microsoft.Extensions.Logging;

namespace ShopifyGraphQLNet
{
    public class ShopifyGraphQLNetClient
    {
        private readonly HttpClient client;
        private readonly ILogger<ShopifyGraphQLNetClient> logger;

        public ShopifyGraphQLNetClient(HttpClient client, ILogger<ShopifyGraphQLNetClient> logger)
        {
            this.client = client;
            this.logger = logger;
        }
    }
}