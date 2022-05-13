namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Updates the shipping lines on an existing checkout result payload
/// </summary>
public class CheckoutShippingLineUpdatePayload
{
    /// <summary>
    /// The updated checkout object.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The list of errors that occurred from executing the mutation.
    /// </summary>
    public CheckoutUserError[] CheckoutUserErrors { get; set; } = default!;

    public static readonly CheckoutShippingLineUpdatePayload Default = new() { Checkout = Checkout.Default };
}