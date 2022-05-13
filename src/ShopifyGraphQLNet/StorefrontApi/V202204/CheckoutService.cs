using System;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Types.Checkout;
using ShopifyGraphQLNet.Types.Checkout.Arguments;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi.V202204
{
    public class CheckoutService: ServiceBase, ICheckoutService
    {
        public CheckoutService(ShopifyGraphQLNetClient client, ILogger<ProductService> logger) : base(client, logger)
        { }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutCreatePayload>> Create(CheckoutCreateArguments arguments,
            CheckoutCreatePayload? value = default, CancellationToken ct = default)
        {
            logger.LogTrace("Create. CheckoutCreateArguments: {@checkoutCreateArguments}", arguments);

            return client.ExecuteMutation(value ?? CheckoutCreatePayload.Default, arguments, "checkoutCreate", ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutShippingAddressUpdateV2Payload>> ShippingAddressUpdate(
            CheckoutShippingAddressUpdateV2Arguments arguments, CheckoutShippingAddressUpdateV2Payload? value = default,
            CancellationToken ct = default)
        {
            logger.LogTrace(
                "ShippingAddressUpdate. CheckoutShippingAddressUpdateV2Arguments: {@checkoutShippingAddressUpdateV2Arguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutShippingAddressUpdateV2Payload.Default, arguments,
                "checkoutShippingAddressUpdateV2", ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutEmailUpdateV2Payload>> EmailUpdate(CheckoutEmailUpdateV2Arguments arguments,
            CheckoutEmailUpdateV2Payload? value = default, CancellationToken ct = default)
        {
            logger.LogTrace("EmailUpdate. CheckoutEmailUpdateV2Arguments: {@checkoutEmailUpdateV2Arguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutEmailUpdateV2Payload.Default, arguments,
                "checkoutEmailUpdateV2", ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutLineItemsUpdatePayload>> LineItemsUpdate(
            CheckoutLineItemsUpdateArguments arguments, CheckoutLineItemsUpdatePayload? value = default,
            CancellationToken ct = default)
        {
            logger.LogTrace("LineItemsUpdate. CheckoutLineItemsUpdateArguments: {@checkoutLineItemsUpdateArguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutLineItemsUpdatePayload.Default, arguments,
                "checkoutLineItemsUpdate", ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutLineItemsReplacePayload>> LineItemsReplace(
            CheckoutLineItemsReplaceArguments arguments, CheckoutLineItemsReplacePayload? value = default,
            CancellationToken ct = default)
        {
            logger.LogTrace("LineItemsReplace. CheckoutLineItemsUpdateArguments: {@checkoutLineItemsUpdateArguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutLineItemsReplacePayload.Default, arguments,
                "checkoutLineItemsReplace", ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutShippingLineUpdatePayload>> ShippingLineUpdate(
            CheckoutShippingLineUpdateArguments arguments, CheckoutShippingLineUpdatePayload? value = default,
            CancellationToken ct = default)
        {
            logger.LogTrace("ShippingLineUpdate. CheckoutShippingLineUpdateArguments: {@checkoutShippingLineUpdateArguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutShippingLineUpdatePayload.Default, arguments,
                "checkoutShippingLineUpdate", ct: ct);
        }
    }
}
