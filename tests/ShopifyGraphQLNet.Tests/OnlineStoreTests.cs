using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.StorefrontApi;
using Xunit;

namespace ShopifyGraphQLNet.Tests
{
    public class OnlineStoreTests
    {
        private readonly IOnlineStoreService onlineStoreService;

        public OnlineStoreTests()
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

            onlineStoreService = host.Services.GetRequiredService<IOnlineStoreService>();
        }

        [Fact]
        public async Task GetShopTest()
        {
            var res = await onlineStoreService.GetShop();
            
            res.Assert();
        }
    }
}
