using ShopifyGraphQLNet.Types.Interface;
using ShopifyGraphQLNet.Types.Product;

namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// A single line item in the checkout, grouped by variant and attributes.
/// Requires unauthenticated_read_product_listings access scope.
/// </summary>
public class CheckoutLineItem: INode
{
    /// <summary>
    /// Extra information in the form of an array of Key-Value pairs about the line item.
    /// </summary>
    public AttributeObject[] CustomAttributes { get; set; } = default!;
    /// <summary>
    /// The discounts that have been allocated onto the checkout line item by discount applications.
    /// </summary>
    public DiscountAllocation.DiscountAllocation[] DiscountAllocations { get; set; } = default!;
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// The quantity of the line item.
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// Title of the line item. Defaults to the product's title.
    /// </summary>
    public string Title { get; set; } = default!;
    /// <summary>
    /// Unit price of the line item.
    /// </summary>
    public MoneyV2? UnitPrice { get; set; }
    /// <summary>
    /// Product variant of the line item.
    /// </summary>
    public ProductVariant? Variant { get; set; }

    public static readonly CheckoutLineItem Default = new()
    {
        Id = String.Empty, Title = String.Empty, Quantity = default, Variant = ProductVariant.Default,
        UnitPrice = MoneyV2.Default
    };
}