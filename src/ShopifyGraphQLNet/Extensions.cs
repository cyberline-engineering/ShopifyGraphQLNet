using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.StorefrontApi;

namespace ShopifyGraphQLNet
{
    public static class Extensions
    {
        public static IServiceCollection AddShopifyGraphQLNetClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            var section = configuration.GetSection(nameof(ShopifyGraphQLNetClientConfig));
            services.AddOptions<ShopifyGraphQLNetClientConfig>()
                .Bind(section)
                .ValidateDataAnnotations();

            var config = section.Get<ShopifyGraphQLNetClientConfig>();

            services
                .AddHttpClient<ShopifyGraphQLNetClient>()
                .ConfigureHttpClient((provider, client) =>
                {
                    var options = config.Value;
                    client.ConfigureShopifyClient(options);

                    if (client.DefaultRequestHeaders.UserAgent.Count == 0)
                    {
                        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(
                            nameof(ShopifyGraphQLNetClient),
                            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3)));
                    }
                });

            services.AddSingleton(_ => new JsonSerializerOptions(JsonSerializerDefaults.Web)
            {
                Converters = { new JsonStringEnumConverter() },
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

            if (config.ApiVersion.Value == ShopifyApiVersionExtensions.V2022_04.Value)
            {
                services.AddTransient<IProductService, StorefrontApi.V202204.ProductService>();
                services.AddTransient<ICheckoutService, StorefrontApi.V202204.CheckoutService>();
            }

            return services;
        }

        public static void ConfigureShopifyClient(this HttpClient client, ShopifyGraphQLNetClientConfig options)
        {
            if (!String.IsNullOrWhiteSpace(options.StoreName))
            {
                client.BaseAddress = options.BuildApiUrl();
            }

            if (!String.IsNullOrWhiteSpace(options.StorefrontApiAccessToken))
            {
                client.DefaultRequestHeaders.Add(ShopifyApiHelper.StorefrontAccessTokenHeaderName,
                    options.StorefrontApiAccessToken);
            }
        }
    }
}
