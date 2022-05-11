namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Specifies the identity of the customer associated with the checkout.
/// </summary>
public class CheckoutBuyerIdentityInput
{
    /// <summary>
    /// The country code of one of the shop's <see href="https://help.shopify.com/en/manual/payments/shopify-payments/multi-currency/setup?shpxid=b1d98727-52C5-466A-234E-FFC958777A24">enabled countries</see>.
    /// For example, CA. Including this field creates a checkout in the specified country's currency.
    /// </summary>
    public CountryCode CountryCode { get; set; }
}