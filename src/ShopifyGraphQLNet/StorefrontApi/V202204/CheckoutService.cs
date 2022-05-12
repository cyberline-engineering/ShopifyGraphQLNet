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

        /// <summary>
        /// Creates a new checkout.
        /// Requires unauthenticated_write_checkouts access scope.
        /// </summary>
        /// <param name="arguments"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public Task<QueryResult<CheckoutCreatePayload>> Create(CheckoutCreateArguments arguments,
            CancellationToken ct = default)
        {
            logger.LogTrace("Create. CheckoutCreateArguments: {@checkoutCreateArguments}", arguments);

            return client.ExecuteMutation(CheckoutCreatePayload.Default, arguments, "checkoutCreate", ct: ct);
        }
    }
}
