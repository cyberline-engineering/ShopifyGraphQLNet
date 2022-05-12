using ShopifyGraphQLNet.Types.Checkout.Arguments;
using ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;
using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types.Order;

/// <summary>
/// An order is a customer’s completed request to purchase one or more products from a shop.
/// An order is created when a customer completes the checkout process,
/// during which time they provides an email address, billing address and payment information.
/// Requires unauthenticated_read_customers access scope.
/// </summary>
public class Order: INode, IHasMetafields
{
    /// <summary>
    /// The reason for the order's cancellation.
    /// Returns null if the order wasn't canceled.
    /// </summary>
    public OrderCancelReason CancelReason { get; set; }
    /// <summary>
    /// The date and time when the order was canceled.
    /// Returns null if the order wasn't canceled.
    /// </summary>
    public DateTimeOffset? CanceledAt { get; set; }
    /// <summary>
    /// The code of the currency used for the payment.
    /// </summary>
    public CurrencyCode CurrencyCode { get; set; }
    /// <summary>
    /// The subtotal of line items and their discounts, excluding line items that have been removed.
    /// Does not contain order-level discounts, duties, shipping costs, or shipping discounts.
    /// Taxes are not included unless the order is a taxes-included order.
    /// </summary>
    public MoneyV2 CurrentSubtotalPrice { get; set; } = default!;
    /// <summary>
    /// The total cost of duties for the order, including refunds.
    /// </summary>
    public MoneyV2? CurrentTotalDuties { get; set; }
    /// <summary>
    /// The total amount of the order, including duties, taxes and discounts, minus amounts for line items that have been removed.
    /// </summary>
    public MoneyV2 CurrentTotalPrice { get; set; } = default!;
    /// <summary>
    /// The total of all taxes applied to the order, excluding taxes for returned line items.
    /// </summary>
    public MoneyV2 CurrentTotalTax { get; set; } = default!;
    /// <summary>
    /// The locale code in which this specific order happened.
    /// </summary>
    public string? CustomerLocale { get; set; }
    /// <summary>
    /// The unique URL that the customer can use to access the order.
    /// </summary>
    public Uri? CustomerUrl { get; set; }
    /// <summary>
    /// Whether the order has had any edits applied or not.
    /// </summary>
    public bool Edited { get; set; }
    /// <summary>
    /// The customer's email address.
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// The financial status of the order.
    /// </summary>
    public OrderFinancialStatus? FinancialStatus { get; set; }
    /// <summary>
    /// The fulfillment status for the order.
    /// </summary>
    public OrderFulfillmentStatus FulfillmentStatus { get; set; }
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <inheritdoc />
    public Metafield? Metafield { get; set; }
    /// <summary>
    /// Unique identifier for the order that appears on the order.
    /// For example, #1000 or _Store1001.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// A unique numeric identifier for the order for use by shop owner and customer.
    /// </summary>
    public long OrderNumber { get; set; }
    /// <summary>
    /// The total cost of duties charged at checkout.
    /// </summary>
    public MoneyV2? OriginalTotalDuties { get; set; }
    /// <summary>
    /// The total price of the order before any applied edits.
    /// </summary>
    public MoneyV2 OriginalTotalPrice { get; set; } = default!;
    /// <summary>
    /// The customer's phone number for receiving SMS notifications.
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// The date and time when the order was imported.
    /// This value can be set to dates in the past when importing from other systems.
    /// If no value is provided, it will be auto-generated based on current date and time.
    /// </summary>
    public DateTimeOffset ProcessedAt { get; set; }
    /// <summary>
    /// The address to where the order will be shipped.
    /// </summary>
    public MailingAddress? ShippingAddress { get; set; }
    /// <summary>
    /// The discounts that have been allocated onto the shipping line by discount applications.
    /// </summary>
    public DiscountAllocation[] ShippingDiscountAllocations { get; set; } = default!;
    /// <summary>
    /// The unique URL for the order's status page.
    /// </summary>
    public Uri StatusUrl { get; set; } = default!;
    /// <summary>
    /// Price of the order before duties, shipping and taxes.
    /// </summary>
    public MoneyV2? SubtotalPriceV2 { get; set; }
    /// <summary>
    /// List of the order’s successful fulfillments.
    /// </summary>
    public SuccessfulFulfillments SuccessfulFulfillments { get; set; } = default!;
    /// <summary>
    /// The sum of all the prices of all the items in the order, duties, taxes and discounts included (must be positive).
    /// </summary>
    public MoneyV2 TotalPriceV2 { get; set; } = default!;
    /// <summary>
    /// The total amount that has been refunded.
    /// </summary>
    public MoneyV2 TotalRefundedV2 { get; set; } = default!;
    /// <summary>
    /// The total cost of shipping.
    /// </summary>
    public MoneyV2 TotalShippingPriceV2 { get; set; } = default!;
    /// <summary>
    /// The total cost of taxes.
    /// </summary>
    public MoneyV2? TotalTaxV2 { get; set; }
    /// <summary>
    /// Discounts that have been applied on the order.
    /// </summary>
    public DiscountApplicationConnection DiscountApplications { get; set; } = default!;
    /// <summary>
    /// List of the order’s line items.
    /// </summary>
    public OrderLineItemConnection LineItems { get; set; } = default!;
}

/// <inheritdoc />
public class OrderLineItemConnection : Connection<OrderLineItem>
{
    public static readonly OrderLineItemConnection Default = new()
        { Nodes = Array.Empty<OrderLineItem>(), _arguments = ConnectionArguments.Default };
}

/// <inheritdoc />
public class DiscountApplicationConnection : Connection<DiscountApplication>
{
    public static readonly DiscountApplicationConnection Default = new()
        { Nodes = Array.Empty<DiscountApplication>(), _arguments = ConnectionArguments.Default };
}