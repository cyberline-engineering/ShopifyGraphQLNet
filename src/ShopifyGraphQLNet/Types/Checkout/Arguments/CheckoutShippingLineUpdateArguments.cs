using System.ComponentModel.DataAnnotations;
using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Updates the shipping lines on an existing checkout.
/// </summary>
public class CheckoutShippingLineUpdateArguments
{
    /// <summary>
    /// The ID of the checkout.
    /// </summary>
    [Required]
    [IdGraphType]
    public string CheckoutId { get; set; } = default!;
    /// <summary>
    /// A unique identifier to a Checkout’s shipping provider, price, and title combination, enabling the customer to select the availableShippingRates.
    /// </summary>
    [Required]
    public string ShippingRateHandle { get; set; } = default!;
}