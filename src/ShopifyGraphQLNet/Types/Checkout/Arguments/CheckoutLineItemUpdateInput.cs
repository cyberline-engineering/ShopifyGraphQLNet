namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Specifies the input fields to update a line item on the checkout.
/// </summary>
public class CheckoutLineItemUpdateInput
{
    /// <summary>
    /// Extra information in the form of an array of Key-Value pairs about the line item.
    /// </summary>
    public AttributeInput[]? CustomAttributes { get; set; }
    /// <summary>
    /// The identifier of the line item.
    /// </summary>
    public string? Id { get; set; }
    /// <summary>
    /// The quantity of the line item.
    /// </summary>
    public int? Quantity { get; set; }
    /// <summary>
    /// The variant identifier of the line item.
    /// </summary>
    public string? VariantId { get; set; }
}