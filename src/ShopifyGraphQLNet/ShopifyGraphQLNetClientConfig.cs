using System;
using Microsoft.Extensions.Options;

namespace ShopifyGraphQLNet
{
    public class ShopifyGraphQLNetClientConfig : IOptions<ShopifyGraphQLNetClientConfig>
    {
        public string? StoreName { get; set; }
        public string? StorefrontApiAccessToken { get; set; }
        public string? AdminApiAccessToken { get; set; }
        public ShopifyApiVersion? ApiVersion { get; set; }

        public ShopifyGraphQLNetClientConfig Value => this;

        public static readonly ShopifyGraphQLNetClientConfig Default = new()
            { ApiVersion = ShopifyApiVersionExtensions.V2022_04 };
    }

    public class ShopifyApiVersion
    {
        public string? Value { get; set; }
    }

    public static class ShopifyApiVersionExtensions
    {
        public static readonly ShopifyApiVersion V2022_04 = new() { Value = "2022-04" };
    }
}
