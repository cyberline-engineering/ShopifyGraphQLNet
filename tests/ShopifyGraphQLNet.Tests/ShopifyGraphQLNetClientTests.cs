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
            var obj = new { nodes = Array.Empty<Product>()};

            var result = await client.ExecuteQuery(obj, "products", new { first = 5 });
            
            result.Assert();
        }
    }
}
