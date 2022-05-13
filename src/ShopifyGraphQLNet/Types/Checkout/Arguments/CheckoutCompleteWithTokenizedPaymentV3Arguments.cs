using System.ComponentModel.DataAnnotations;
using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Completes a checkout with a tokenized payment.
/// </summary>
public class CheckoutCompleteWithTokenizedPaymentV3Arguments
{
    /// <summary>
    /// The ID of the checkout.
    /// </summary>
    [Required]
    [IdGraphType]
    public string CheckoutId { get; set; } = default!;
    /// <summary>
    /// The info to apply as a tokenized payment.
    /// </summary>
    [Required]
    public TokenizedPaymentInputV3 Payment { get; set; } = default!;
}