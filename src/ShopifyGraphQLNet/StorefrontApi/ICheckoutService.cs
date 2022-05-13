using System;
using ShopifyGraphQLNet.Types.Checkout;
using ShopifyGraphQLNet.Types.Checkout.Arguments;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi
{
    public interface ICheckoutService
    {
        /// <summary>
        /// Creates a new checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutCreatePayload>> Create(CheckoutCreateArguments arguments,
            CheckoutCreatePayload? value = default,
            CancellationToken ct = default);

        /// <summary>
        /// Updates the shipping address of an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutShippingAddressUpdateV2Payload>> ShippingAddressUpdate(
            CheckoutShippingAddressUpdateV2Arguments arguments, CheckoutShippingAddressUpdateV2Payload? value = default,
            CancellationToken ct = default);

        /// <summary>
        /// Updates the email on an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutEmailUpdateV2Payload>> EmailUpdate(CheckoutEmailUpdateV2Arguments arguments,
            CheckoutEmailUpdateV2Payload? value = default, CancellationToken ct = default);

        /// <summary>
        /// Updates line items on a checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutLineItemsUpdatePayload>> LineItemsUpdate(CheckoutLineItemsUpdateArguments arguments,
            CheckoutLineItemsUpdatePayload? value = default, CancellationToken ct = default);

        /// <summary>
        /// Sets a list of line items to a checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutLineItemsReplacePayload>> LineItemsReplace(
            CheckoutLineItemsReplaceArguments arguments, CheckoutLineItemsReplacePayload? value = default,
            CancellationToken ct = default);

        /// <summary>
        /// Updates the shipping lines on an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="value"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutShippingLineUpdatePayload>> ShippingLineUpdate(
            CheckoutShippingLineUpdateArguments arguments, CheckoutShippingLineUpdatePayload? value = default,
            CancellationToken ct = default);
    }
}
