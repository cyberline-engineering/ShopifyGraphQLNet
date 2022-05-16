using System;
using ShopifyGraphQLNet.Types.Checkout;
using ShopifyGraphQLNet.Types.Checkout.Arguments;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi
{
    public interface ICheckoutService: IShopifyService
    {
        /// <summary>
        /// Creates a new checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutCreatePayload>> Create(CheckoutCreateArguments arguments,
            CheckoutCreatePayload? value = default, RequestOptions? options = default, 
            CancellationToken ct = default);

        /// <summary>
        /// Updates the shipping address of an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutShippingAddressUpdateV2Payload>> ShippingAddressUpdate(
            CheckoutShippingAddressUpdateV2Arguments arguments, CheckoutShippingAddressUpdateV2Payload? value = default,
            RequestOptions? options = default, CancellationToken ct = default);

        /// <summary>
        /// Updates the email on an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutEmailUpdateV2Payload>> EmailUpdate(CheckoutEmailUpdateV2Arguments arguments,
            CheckoutEmailUpdateV2Payload? value = default, RequestOptions? options = default, CancellationToken ct = default);

        /// <summary>
        /// Updates line items on a checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutLineItemsUpdatePayload>> LineItemsUpdate(CheckoutLineItemsUpdateArguments arguments,
            CheckoutLineItemsUpdatePayload? value = default, RequestOptions? options = default, CancellationToken ct = default);

        /// <summary>
        /// Sets a list of line items to a checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutLineItemsReplacePayload>> LineItemsReplace(
            CheckoutLineItemsReplaceArguments arguments, CheckoutLineItemsReplacePayload? value = default,
            RequestOptions? options = default, CancellationToken ct = default);

        /// <summary>
        /// Updates the shipping lines on an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutShippingLineUpdatePayload>> ShippingLineUpdate(
            CheckoutShippingLineUpdateArguments arguments, CheckoutShippingLineUpdatePayload? value = default,
            RequestOptions? options = default, CancellationToken ct = default);

        /// <summary>
        /// Completes a checkout with a tokenized payment.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="options"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutCompleteWithTokenizedPaymentV3Payload>> CompleteWithTokenizedPaymentV3(
            CheckoutCompleteWithTokenizedPaymentV3Arguments arguments, CheckoutCompleteWithTokenizedPaymentV3Payload? value = default,
            RequestOptions? options = default, CancellationToken ct = default);
    }
}
