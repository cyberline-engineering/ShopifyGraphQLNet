using System.ComponentModel.DataAnnotations;
using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Updates line items on a checkout arguments.
/// </summary>
public class CheckoutLineItemsUpdateArguments
{
    /// <summary>
    /// The checkout on which to update line items.
    /// </summary>
    [Required]
    [IdGraphType]
    public string CheckoutId { get; set; } = default!;
    /// <summary>
    /// Line items to update.
    /// </summary>
    [Required]
    public CheckoutLineItemUpdateInput[] LineItems { get; set; } = default!;
}