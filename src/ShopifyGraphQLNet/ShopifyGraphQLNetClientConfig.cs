using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace ShopifyGraphQLNet
{
    public class ShopifyGraphQLNetClientConfig: IOptions<ShopifyGraphQLNetClientConfig>
    {
        public string StoreName { get; set; } = default!;
        public string StorefrontApiAccessToken { get; set; } = default!;
        public string AdminApiAccessToken { get; set; } = default!;

        [Required(ErrorMessage = "Not defined ApiVersion. Please provide correct ApiVersion at appsettings.json")]
        public ShopifyApiVersion ApiVersion { get; set; } = ShopifyApiVersionExtensions.V2022_04;

        public ShopifyGraphQLNetClientConfig Value => this;
    }

    public class ShopifyApiVersion
    {
        public string Value { get; set; } = default!;
    }

    public static class ShopifyApiVersionExtensions
    {
        public static readonly ShopifyApiVersion V2022_04 = new() { Value = "2022-04" };
    }
}
