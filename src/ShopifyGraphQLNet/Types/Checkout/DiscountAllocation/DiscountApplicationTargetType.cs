namespace ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;

/// <summary>
/// The type of line (i.e. line item or shipping line) on an order that the discount is applicable towards.
/// </summary>
public enum DiscountApplicationTargetType
{
    /// <summary>
    /// The discount applies onto line items.
    /// </summary>
    LINE_ITEM,
    /// <summary>
    /// The discount applies onto shipping lines.
    /// </summary>
    SHIPPING_LINE
}