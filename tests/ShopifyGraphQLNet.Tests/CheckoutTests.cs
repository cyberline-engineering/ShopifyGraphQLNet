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
using ShopifyGraphQLNet.Types.Checkout;
using ShopifyGraphQLNet.Types.Checkout.Arguments;
using ShopifyGraphQLNet.Types.Product;
using ShopifyGraphQLNet.Types.Product.Arguments;
using ShopifyGraphQLNet.Types.Query;
using Xunit;

namespace ShopifyGraphQLNet.Tests
{
    public class CheckoutTests: IAsyncLifetime
    {
        private readonly ICheckoutService checkoutService;
        private readonly IProductService productService;
        private ProductConnection products;
        private CheckoutCreatePayload checkoutPayload;

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

        public async Task InitializeAsync()
        {
            var productsResult = await productService.List(ProductListArguments.Default);
            products = productsResult.Payload!;

            var lineItems = products.Nodes.Take(10).Select(x => new CheckoutLineItemInput()
                { VariantId = x.Variants.Nodes.First().Id, Quantity = 1 }).ToArray();

            var checkoutInput = new CheckoutCreateArguments()
            {
                Input = new()
                {
                    LineItems = lineItems,
                    ShippingAddress = Extensions.TestAddress
                }
            };

            var checkoutResult = await checkoutService.Create(checkoutInput);
            checkoutPayload = checkoutResult.Payload!;
        }

        public Task DisposeAsync()
        {
            //remove checkout

            return Task.CompletedTask;
        }

        private Task<QueryResult<CheckoutShippingAddressUpdateV2Payload>> ShippingAddressUpdate(
            MailingAddressInput shippingAddress)
        {
            var arguments = new CheckoutShippingAddressUpdateV2Arguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                ShippingAddress = shippingAddress,
            };

            var result = checkoutService.ShippingAddressUpdate(arguments);
            return result;
        }

        [Fact]
        public async Task CreateCheckoutTest()
        {
            var lineItems = products.Nodes.Take(2).Select(x => new CheckoutLineItemInput()
                { VariantId = x.Variants.Nodes.First().Id, Quantity = 1 }).ToArray();

            var checkoutInput = new CheckoutCreateArguments()
            {
                Input = new()
                {
                    LineItems = lineItems,
                    ShippingAddress = Extensions.TestAddress,
                }
            };

            var result = await checkoutService.Create(checkoutInput);

            result.Assert();
            Assert.Null(result.Payload!.CheckoutUserErrors);
            Assert.NotNull(result.Payload.Checkout);
        }

        [Fact]
        public async Task ShippingAddressUpdateTest()
        {
            var result = await ShippingAddressUpdate(Extensions.TestAddress2);
            var address = result.Payload?.Checkout.ShippingAddress;

            result.Assert();
            Assert.NotNull(address);
            Assert.Equal(Extensions.TestAddress2.Address1, address!.Address1);
        }

        [Fact]
        public async Task EmailUpdateTest()
        {
            var arguments = new CheckoutEmailUpdateV2Arguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                Email = "john@doe.com"
            };

            var result = await checkoutService.EmailUpdate(arguments);
            var email = result.Payload?.Checkout.Email;

            result.Assert();
            Assert.NotNull(email);
            Assert.Equal(arguments.Email, email);
        }

        [Fact]
        public async Task LineItemsUpdateTest()
        {
            var lineItems = checkoutPayload.Checkout.LineItems.Nodes.Select(x => new CheckoutLineItemUpdateInput()
            {
                Id = x.Id,
                Quantity = 2
            }).ToArray();

            var arguments = new CheckoutLineItemsUpdateArguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                LineItems = lineItems
            };

            var result = await checkoutService.LineItemsUpdate(arguments);
            var li = result.Payload?.Checkout.LineItems;

            result.Assert();
            Assert.NotEmpty(li!.Nodes);
            var source = lineItems.First();
            var dest = li.Nodes.First();

            Assert.Equal(source.Quantity, dest.Quantity);
        }

        [Fact]
        public async Task LineItemsReplaceTest()
        {
            var lineItems = checkoutPayload.Checkout.LineItems.Nodes.Take(1).Select(x => new CheckoutLineItemInput()
            {
                VariantId = x.Variant!.Id,
                Quantity = 2
            }).ToArray();

            var arguments = new CheckoutLineItemsReplaceArguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                LineItems = lineItems
            };

            var result = await checkoutService.LineItemsReplace(arguments);
            var li = result.Payload?.Checkout.LineItems;

            result.Assert();
            Assert.NotEmpty(li!.Nodes);
            var source = lineItems.First();
            var dest = li.Nodes.First();

            Assert.Equal(source.Quantity, dest.Quantity);
        }

        [Fact]
        public async Task ShippingLineUpdateTest()
        {
            var checkout = await ShippingAddressUpdate(Extensions.TestAddress2);

            var shippingRate = checkout.Payload!.Checkout.AvailableShippingRates.ShippingRates!.Last();

            var arguments = new CheckoutShippingLineUpdateArguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                ShippingRateHandle = shippingRate.Handle
            };

            var result = await checkoutService.ShippingLineUpdate(arguments);
            var shippingLine = result.Payload!.Checkout.ShippingLine;

            result.Assert();
            Assert.NotNull(shippingLine);
            Assert.Equal(shippingRate.Handle, shippingLine!.Handle);
        }
    }
}
