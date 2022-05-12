using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Interface;
using ShopifyGraphQLNet.Types.Order;

namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// A container for all the information required to checkout items and pay.
/// Requires unauthenticated_read_checkouts access scope.
/// </summary>
public class Checkout: INode
{
    /// <summary>
    /// The gift cards used on the checkout.
    /// </summary>
    public AppliedGiftCard[] AppliedGiftCards { get; set; } = default!;
    /// <summary>
    /// The available shipping rates for this Checkout.
    /// Should only be used when checkout requiresShipping is true and the shipping address is valid.
    /// </summary>
    public AvailableShippingRates AvailableShippingRates { get; set; } = default!;
    /// <summary>
    /// The identity of the customer associated with the checkout.
    /// </summary>
    public CheckoutBuyerIdentity BuyerIdentity { get; set; } = default!;
    /// <summary>
    /// The date and time when the checkout was completed.
    /// </summary>
    public DateTimeOffset? CompletedAt { get; set; }
    /// <summary>
    /// The date and time when the checkout was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    /// <summary>
    /// The currency code for the checkout.
    /// </summary>
    public CurrencyCode CurrencyCode { get; set; }
    /// <summary>
    /// A list of extra information that is added to the checkout.
    /// </summary>
    public AttributeObject[] CustomAttributes { get; set; } = default!;
    /// <summary>
    /// The email attached to this checkout.
    /// </summary>
    public string? Email { get; set; }
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// The sum of all the prices of all the items in the checkout. Duties, taxes, shipping and discounts excluded.
    /// </summary>
    public MoneyV2 LineItemsSubtotalPrice { get; set; } = default!;
    /// <summary>
    /// The note associated with the checkout.
    /// </summary>
    public string? Note { get; set; }
    /// <summary>
    /// The resulting order from a paid checkout.
    /// </summary>
    public Order.Order Order { get; set; } = default!;
    /// <summary>
    /// The Order Status Page for this Checkout, null when checkout is not completed.
    /// </summary>
    public Uri OrderStatusUrl { get; set; } = default!;
    /// <summary>
    /// The amount left to be paid. This is equal to the cost of the line items, duties, taxes and shipping minus discounts and gift cards.
    /// </summary>
    public MoneyV2 PaymentDueV2 { get; set; } = default!;
    /// <summary>
    /// Whether or not the Checkout is ready and can be completed.
    /// Checkouts may have asynchronous operations that can take time to finish.
    /// If you want to complete a checkout or ensure all the fields are populated and up to date, polling is required until the value is true.
    /// </summary>
    public bool Ready { get; set; }
    /// <summary>
    /// States whether or not the fulfillment requires shipping.
    /// </summary>
    public bool RequiresShipping { get; set; }
    /// <summary>
    /// The shipping address to where the line items will be shipped.
    /// </summary>
    public MailingAddress ShippingAddress { get; set; } = default!;
    /// <summary>
    /// The discounts that have been allocated onto the shipping line by discount applications.
    /// </summary>
    public DiscountAllocation.DiscountAllocation[] ShippingDiscountAllocations { get; set; } = default!;
    /// <summary>
    /// Once a shipping rate is selected by the customer it is transitioned to a shipping_line object.
    /// </summary>
    public ShippingRate? ShippingLine { get; set; }
    /// <summary>
    /// Price of the checkout before duties, shipping and taxes.
    /// </summary>
    public MoneyV2 SubtotalPriceV2 { get; set; } = default!;
    /// <summary>
    /// Whether the checkout is tax exempt.
    /// </summary>
    public bool TaxExempt { get; set; }
    /// <summary>
    /// Whether taxes are included in the line item and shipping line prices.
    /// </summary>
    public bool TaxesIncluded { get; set; }
    /// <summary>
    /// The sum of all the duties applied to the line items in the checkout.
    /// </summary>
    public MoneyV2? TotalDuties { get; set; }
    /// <summary>
    /// The sum of all the prices of all the items in the checkout, duties, taxes and discounts included.
    /// </summary>
    public MoneyV2 TotalPriceV2 { get; set; } = default!;
    /// <summary>
    /// The sum of all the taxes applied to the line items and shipping lines in the checkout.
    /// </summary>
    public MoneyV2 TotalTaxV2 { get; set; } = default!;
    /// <summary>
    /// The date and time when the checkout was last updated.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
    /// <summary>
    /// The url pointing to the checkout accessible from the web.
    /// </summary>
    public Uri WebUrl { get; set; } = default!;

    /// <summary>
    /// Discounts that have been applied on the checkout.
    /// </summary>
    public DiscountApplicationConnection DiscountApplicationConnection { get; set; } = default!;
    /// <summary>
    /// A list of line item objects, each one containing information about an item in the checkout.
    /// </summary>
    public CheckoutLineItemConnection LineItems { get; set; } = default!;

    public static readonly Checkout Default = new()
    {
        WebUrl = TypeHelper.DefaultUrl,
        LineItems = CheckoutLineItemConnection.Default,
        Id = String.Empty,
        AvailableShippingRates = AvailableShippingRates.Default,
        ShippingAddress = MailingAddress.Default,
        ShippingLine = ShippingRate.Default,
        Email = String.Empty,
    };
}

/// <inheritdoc />
public class CheckoutLineItemConnection : Connection<CheckoutLineItem>
{
    public static readonly CheckoutLineItemConnection Default = new()
        { Nodes = Array.Empty<CheckoutLineItem>(), _arguments = ConnectionArguments.Default };
}
