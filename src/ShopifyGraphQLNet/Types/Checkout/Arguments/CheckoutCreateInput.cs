using System.Globalization;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Specifies the fields required to create a checkout.
/// </summary>
public class CheckoutCreateInput
{
    /// <summary>
    /// Allows setting partial addresses on a Checkout, skipping the full validation of attributes.
    /// The required attributes are city, province, and country.
    /// Full validation of addresses is still done at completion time. Defaults to null.
    /// </summary>
    public bool? AllowPartialAddresses { get; set; }
    /// <summary>
    /// The identity of the customer associated with the checkout.
    /// </summary>
    public CheckoutBuyerIdentityInput? BuyerIdentity { get; set; }
    /// <summary>
    /// A list of extra information that is added to the checkout.
    /// </summary>
    public AttributeInput[]? CustomAttributes { get; set; }
    /// <summary>
    /// The email with which the customer wants to checkout.
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// A list of line item objects, each one containing information about an item in the checkout.
    /// </summary>
    public CheckoutLineItemInput[]? LineItems { get; set; }
    /// <summary>
    /// The text of an optional note that a shop owner can attach to the checkout.
    /// </summary>
    public string? Note { get; set; }
    /// <summary>
    /// The three-letter currency code of one of the shop's enabled presentment currencies.
    /// Including this field creates a checkout in the specified currency.
    /// By default, new checkouts are created in the shop's primary currency.
    /// This argument is deprecated: Use <see cref="CountryCode">country</see> field instead.
    /// </summary>
    public CurrencyCode? PresentmentCurrencyCode { get; set; }
    /// <summary>
    /// The shipping address to where the line items will be shipped.
    /// </summary>
    public MailingAddressInput? ShippingAddress { get; set; }
}