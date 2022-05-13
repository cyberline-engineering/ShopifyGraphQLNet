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
        private ProductConnection products = default!;
        private CheckoutCreatePayload checkoutPayload = default!;

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

            return checkoutService.ShippingAddressUpdate(arguments);
        }

        private Task<QueryResult<CheckoutShippingLineUpdatePayload>> ShippingLineUpdate(string shippingRateHandle)
        {
            var arguments = new CheckoutShippingLineUpdateArguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                ShippingRateHandle = shippingRateHandle
            };

            return checkoutService.ShippingLineUpdate(arguments);
        }

        private Task<QueryResult<CheckoutEmailUpdateV2Payload>> EmailUpdate(string email)
        {
            var arguments = new CheckoutEmailUpdateV2Arguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                Email = email
            };

            return checkoutService.EmailUpdate(arguments);
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
            result.Assert();
            
            var address = result.Payload?.Checkout.ShippingAddress;
            Assert.NotNull(address);
            Assert.Equal(Extensions.TestAddress2.Address1, address!.Address1);
        }

        [Fact]
        public async Task EmailUpdateTest()
        {
            var arguments = "john@doe.com";
            var result = await EmailUpdate(arguments);
            result.Assert();

            var email = result.Payload?.Checkout.Email;
            Assert.NotNull(email);
            Assert.Equal(arguments, email);
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
            result.Assert();

            var li = result.Payload?.Checkout.LineItems;
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
            result.Assert();

            var li = result.Payload?.Checkout.LineItems;
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
            var result = await ShippingLineUpdate(shippingRate.Handle);

            result.Assert();

            var shippingLine = result.Payload!.Checkout.ShippingLine;
            Assert.NotNull(shippingLine);
            Assert.Equal(shippingRate.Handle, shippingLine!.Handle);
        }

        [Fact]
        public async Task CompleteWithTokenizedPaymentV3Test()
        {
            var checkout = await ShippingAddressUpdate(Extensions.TestAddress2);
            var shippingRate = checkout.Payload!.Checkout.AvailableShippingRates.ShippingRates!.Last();
            var shipping = await ShippingLineUpdate(shippingRate.Handle);
            var email = await EmailUpdate("john@doe.com");

            var payment = new TokenizedPaymentInputV3()
            {
                PaymentAmount = new() {Amount = email.Payload!.Checkout.TotalPriceV2.Amount, CurrencyCode = email.Payload!.Checkout.TotalPriceV2.CurrencyCode},
                BillingAddress = Extensions.TestAddress2,
                IdempotencyKey = Guid.NewGuid().ToString(),
                Test = true,
                Type = PaymentTokenType.SHOPIFY_PAY,
                PaymentData = "tok_1Ejt4eLgiPhRqvr3SQdtLvSW"
            };
            var arguments = new CheckoutCompleteWithTokenizedPaymentV3Arguments()
            {
                CheckoutId = checkoutPayload.Checkout.Id,
                Payment = payment
            };

            var result = await checkoutService.CheckoutCompleteWithTokenizedPaymentV3(arguments);
            result.Assert();

            var pm = result.Payload!.Payment;
            Assert.NotNull(pm);
            Assert.Equal(payment.IdempotencyKey, pm.IdempotencyKey);
            Assert.Equal(payment.PaymentAmount.Amount, pm.AmountV2.Amount);
        }
    }
}
