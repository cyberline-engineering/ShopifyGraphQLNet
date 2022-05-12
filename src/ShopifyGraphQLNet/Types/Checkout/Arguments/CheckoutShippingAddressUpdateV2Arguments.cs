using System.ComponentModel.DataAnnotations;
using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Updates the shipping address of an existing checkout.
/// </summary>
public class CheckoutShippingAddressUpdateV2Arguments
{
    /// <summary>
    /// The ID of the checkout.
    /// </summary>
    [Required]
    [IdGraphType]
    public string CheckoutId { get; set; } = default!;
    /// <summary>
    /// The shipping address to where the line items will be shipped.
    /// </summary>
    [Required]
    public MailingAddressInput ShippingAddress { get; set; } = default!;
}