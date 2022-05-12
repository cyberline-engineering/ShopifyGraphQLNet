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
using ShopifyGraphQLNet.StorefrontApi;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Checkout.Arguments;
using Xunit;

namespace ShopifyGraphQLNet.Tests
{
    public class CheckoutTests
    {
        private readonly ICheckoutService checkoutService;
        private readonly IProductService productService;

        public CheckoutTests()
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

            checkoutService = host.Services.GetRequiredService<ICheckoutService>();
            productService = host.Services.GetRequiredService<IProductService>();
        }

        [Fact]
        public async Task CreateCheckoutTest()
        {
            var products = await productService.List(new() { First = 2 });
            products.Assert();

            var lineItems = products.Payload!.Nodes.Select(x => new CheckoutLineItemInput()
                { VariantId = x.Variants.Nodes.First().Id, Quantity = 1 }).ToArray();

            var checkoutInput = new CheckoutCreateArguments()
            {
                Input = new()
                {
                    BuyerIdentity = new() { CountryCode = CountryCode.US },
                    CustomAttributes = Array.Empty<AttributeInput>(),
                    LineItems = lineItems,
                    ShippingAddress = Extensions.TestAddress,
                }
            };

            var result = await checkoutService.Create(checkoutInput);

            result.Assert();
            Assert.Null(result.Payload!.CheckoutUserErrors);
            Assert.NotNull(result.Payload.Checkout);
        }
    }
}
