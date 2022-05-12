using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutCreatePayload>> Create(CheckoutCreateArguments arguments,
            CancellationToken ct = default);

        /// <summary>
        /// Updates the shipping address of an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutShippingAddressUpdateV2Payload>> ShippingAddressUpdate(CheckoutShippingAddressUpdateV2Arguments arguments, CancellationToken ct = default);

        /// <summary>
        /// Updates the email on an existing checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<QueryResult<CheckoutEmailUpdateV2Payload>> EmailUpdate(CheckoutEmailUpdateV2Arguments arguments, CancellationToken ct = default);
    }
}
