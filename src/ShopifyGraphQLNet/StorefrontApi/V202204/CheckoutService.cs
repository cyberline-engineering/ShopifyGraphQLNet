using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return Task.FromResult(new QueryResult<CheckoutCreatePayload>());
        }
    }
}
