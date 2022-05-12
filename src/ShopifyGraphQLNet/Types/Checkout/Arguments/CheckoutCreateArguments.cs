using System.ComponentModel.DataAnnotations;

namespace ShopifyGraphQLNet.Types.Checkout.Arguments;

/// <summary>
/// Creates a new checkout.
/// </summary>
public class CheckoutCreateArguments
{
    /// <summary>
    /// The fields used to create a checkout.
    /// </summary>
    [Required]
    public CheckoutCreateInput Input { get; set; } = default!;
    /// <summary>
    /// The checkout queue token. Available only to selected stores.
    /// </summary>
    public string? QueueToken { get; set; }
}