using ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;
using ShopifyGraphQLNet.Types.Product;

namespace ShopifyGraphQLNet.Types.Order;

/// <summary>
/// Represents a single line in an order. There is one line item for each distinct product variant.
/// Requires unauthenticated_read_product_listings access scope.
/// </summary>
public class OrderLineItem
{
    /// <summary>
    /// The number of entries associated to the line item minus the items that have been removed.
    /// </summary>
    public int CurrentQuantity { get; set; }
    /// <summary>
    /// List of custom attributes associated to the line item.
    /// </summary>
    public AttributeObject[] CustomAttributes { get; set; } = default!;
    /// <summary>
    /// The discounts that have been allocated onto the order line item by discount applications.
    /// </summary>
    public DiscountAllocation[] DiscountAllocations { get; set; } = default!;
    /// <summary>
    /// The total price of the line item, including discounts, and displayed in the presentment currency.
    /// </summary>
    public MoneyV2 DiscountedTotalPrice { get; set; } = default!;
    /// <summary>
    /// The total price of the line item, not including any discounts.
    /// The total price is calculated using the original unit price multiplied by the quantity, and it is displayed in the presentment currency.
    /// </summary>
    public MoneyV2 OriginalTotalPrice { get; set; } = default!;
    /// <summary>
    /// The number of products variants associated to the line item.
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// The title of the product combined with title of the variant.
    /// </summary>
    public string Title { get; set; } = default!;
    /// <summary>
    /// The product variant object associated to the line item.
    /// </summary>
    public ProductVariant? Variant { get; set; } = default!;
}