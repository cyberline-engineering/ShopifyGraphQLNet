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
                variants = new { nodes = new[] { new { id = "", availableForSale = false, barcode = "" } }, _arguments = new {first = 5} },
            };
            var obj = new { nodes = new[] { product }, _arguments = new {first = 2} };

            var result = await client.ExecuteQuery(obj, "products");
            
            result.Assert();

            Assert.NotEmpty(result.Payload!.nodes);
        }
    }
}
