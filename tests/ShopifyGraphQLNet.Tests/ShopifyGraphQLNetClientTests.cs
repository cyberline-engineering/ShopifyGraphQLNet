using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Product;
using Xunit;

namespace ShopifyGraphQLNet.Tests
{
    public class ShopifyGraphQLNetClientTests
    {
        private readonly ShopifyGraphQLNetClient client;

        public ShopifyGraphQLNetClientTests()
        {
            var host = Host
                .CreateDefaultBuilder()
                .UseEnvironment(Environments.Development)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddShopifyGraphQLNetClient(context.Configuration);
                })
                .ConfigureLogging(builder =>
                {
                    builder.AddDebug();
                    builder.SetMinimumLevel(LogLevel.Trace);
                })
                .Build();

            client = host.Services.GetRequiredService<ShopifyGraphQLNetClient>();
        }

        [Fact]
        public async Task ExecuteQueryTest()
        {
            var product = new
            {
                id = "", description = "",
                variants = new
                {
                    nodes = new[] { new { id = "", availableForSale = false, barcode = "" } },
                    _arguments = new { first = 5 }
                },
            };
            var obj = new { nodes = new[] { product } };

            var result = await client.ExecuteQuery(obj, new { first = 2 }, "products");

            result.Assert();

            Assert.NotEmpty(result.Payload!.nodes);
        }

        [Fact]
        public async Task ExecuteCustomQueryTest()
        {
            var id = "gid://shopify/Checkout/736d7f206029fd30cc70e4f592d9657a?key=4c197eaedac8e04283a125612f86664f";
            var query = @"
                        query getCheckout($id: ID!) {
                                node(id: $id) 
                                    {... on Checkout {
                                        id
                                        webUrl                                                                                                                                            
                                        availableShippingRates {
                                            ready
                                            shippingRates {
                                                handle
                                                priceV2 {
                                                    amount
                                                        }
                                                title
                                                    }
                                            }
                                    }
                                }
                            }
                        ";
            var value = new
            {
                Node = new
                {
                    Id = String.Empty, WebUrl = String.Empty,
                    AvailableShippingRates = new
                    {
                        Ready = default(bool),
                        ShippingRates = new
                            { Handle = String.Empty, Title = string.Empty, PriceV2 = new { Amount = default(decimal) } }
                    }
                }
            };

            var result = await client.ExecuteQuery(value, new { id }, "getCheckout", query);

            result.Assert();
        }
    }
}
