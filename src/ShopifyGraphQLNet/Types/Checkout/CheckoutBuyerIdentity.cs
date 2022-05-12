namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// The identity of the customer associated with the checkout.
/// Requires unauthenticated_read_checkouts access scope.
/// </summary>
public class CheckoutBuyerIdentity
{
    /// <summary>
    /// The country code for the checkout. For example, CA.
    /// </summary>
    public CountryCode? CountryCode { get; set; }
}