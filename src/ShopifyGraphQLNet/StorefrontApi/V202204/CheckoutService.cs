using System;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Types.Checkout;
using ShopifyGraphQLNet.Types.Checkout.Arguments;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi.V202204
{
    public class CheckoutService : ServiceBase, ICheckoutService
    {
        public CheckoutService(ShopifyGraphQLNetClient client, ILogger<ProductService> logger) : base(client, logger)
        {
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutCreatePayload>> Create(CheckoutCreateArguments arguments,
            CheckoutCreatePayload? value = default, RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace("Create. CheckoutCreateArguments: {@checkoutCreateArguments}", arguments);

            return client.ExecuteMutation(value ?? CheckoutCreatePayload.Default, arguments, "checkoutCreate",
                options: options, ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutShippingAddressUpdateV2Payload>> ShippingAddressUpdate(
            CheckoutShippingAddressUpdateV2Arguments arguments, CheckoutShippingAddressUpdateV2Payload? value = default,
            RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace(
                "ShippingAddressUpdate. CheckoutShippingAddressUpdateV2Arguments: {@checkoutShippingAddressUpdateV2Arguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutShippingAddressUpdateV2Payload.Default, arguments,
                "checkoutShippingAddressUpdateV2", options: options, ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutEmailUpdateV2Payload>> EmailUpdate(CheckoutEmailUpdateV2Arguments arguments,
            CheckoutEmailUpdateV2Payload? value = default, RequestOptions? options = default,
            CancellationToken ct = default)
        {
            logger.LogTrace("EmailUpdate. CheckoutEmailUpdateV2Arguments: {@checkoutEmailUpdateV2Arguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutEmailUpdateV2Payload.Default, arguments,
                "checkoutEmailUpdateV2", options: options, ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutLineItemsUpdatePayload>> LineItemsUpdate(
            CheckoutLineItemsUpdateArguments arguments, CheckoutLineItemsUpdatePayload? value = default,
            RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace("LineItemsUpdate. CheckoutLineItemsUpdateArguments: {@checkoutLineItemsUpdateArguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutLineItemsUpdatePayload.Default, arguments,
                "checkoutLineItemsUpdate", options: options, ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutLineItemsReplacePayload>> LineItemsReplace(
            CheckoutLineItemsReplaceArguments arguments, CheckoutLineItemsReplacePayload? value = default,
            RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace("LineItemsReplace. CheckoutLineItemsUpdateArguments: {@checkoutLineItemsUpdateArguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutLineItemsReplacePayload.Default, arguments,
                "checkoutLineItemsReplace", options: options, ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutShippingLineUpdatePayload>> ShippingLineUpdate(
            CheckoutShippingLineUpdateArguments arguments, CheckoutShippingLineUpdatePayload? value = default,
            RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace(
                "ShippingLineUpdate. CheckoutShippingLineUpdateArguments: {@checkoutShippingLineUpdateArguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutShippingLineUpdatePayload.Default, arguments,
                "checkoutShippingLineUpdate", options: options, ct: ct);
        }

        /// <inheritdoc />
        public Task<QueryResult<CheckoutCompleteWithTokenizedPaymentV3Payload>> CompleteWithTokenizedPaymentV3(
            CheckoutCompleteWithTokenizedPaymentV3Arguments arguments,
            CheckoutCompleteWithTokenizedPaymentV3Payload? value = default,
            RequestOptions? options = default, CancellationToken ct = default)
        {
            logger.LogTrace(
                "CompleteWithTokenizedPaymentV3. CheckoutCompleteWithTokenizedPaymentV3Arguments: {@checkoutCompleteWithTokenizedPaymentV3Arguments}",
                arguments);

            return client.ExecuteMutation(value ?? CheckoutCompleteWithTokenizedPaymentV3Payload.Default, arguments,
                "checkoutCompleteWithTokenizedPaymentV3", options: options, ct: ct);
        }
    }
}
