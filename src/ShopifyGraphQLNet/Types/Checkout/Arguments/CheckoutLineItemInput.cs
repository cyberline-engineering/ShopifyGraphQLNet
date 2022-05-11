namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Specifies the input fields to create a line item on a checkout.
/// </summary>
public class CheckoutLineItemInput
{
    /// <summary>
    /// Extra information in the form of an array of Key-Value pairs about the line item.
    /// </summary>
    public AttributeInput[]? CustomAttributes { get; set; }
    /// <summary>
    /// The quantity of the line item.
    /// </summary>
    public int Quantity { get; set; }
    /// <summary>
    /// The identifier of the product variant for the line item.
    /// </summary>
    public string VariantId { get; set; } = default!;
}