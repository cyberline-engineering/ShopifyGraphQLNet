using System.ComponentModel.DataAnnotations;
using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Updates the email on an existing checkout.
/// </summary>
public class CheckoutEmailUpdateV2Arguments
{
    /// <summary>
    /// The ID of the checkout.
    /// </summary>
    [Required]
    [IdGraphType]
    public string CheckoutId { get; set; } = default!;
    /// <summary>
    /// The email to update the checkout with.
    /// </summary>
    [Required]
    public string Email { get; set; } = default!;
}