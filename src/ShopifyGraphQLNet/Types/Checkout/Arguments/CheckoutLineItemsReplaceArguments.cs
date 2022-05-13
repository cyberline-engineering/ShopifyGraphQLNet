using System.ComponentModel.DataAnnotations;
using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Sets a list of line items to a checkout.
/// </summary>
public class CheckoutLineItemsReplaceArguments
{
    /// <summary>
    /// The checkout on which to update line items.
    /// </summary>
    [Required]
    [IdGraphType]
    public string CheckoutId { get; set; } = default!;
    /// <summary>
    /// A list of line item objects to set on the checkout.
    /// </summary>
    [Required]
    public CheckoutLineItemInput[] LineItems { get; set; } = default!;
}