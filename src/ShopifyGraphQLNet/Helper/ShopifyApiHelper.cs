using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyGraphQLNet.Helper
{
    public static class ShopifyApiHelper
    {
        public const string StorefrontAccessTokenHeaderName = "X-Shopify-Storefront-Access-Token";

        public static Uri BuildApiUrl(string storeName, ShopifyApiVersion apiVersion)
        {
            return new Uri($"https://{storeName}.myshopify.com/api/{apiVersion.Value}/graphql.json");
        }

        public static Uri BuildApiUrl(this ShopifyGraphQLNetClientConfig config)
        {
            return BuildApiUrl(config.StoreName, config.ApiVersion);
        }
    }
}
