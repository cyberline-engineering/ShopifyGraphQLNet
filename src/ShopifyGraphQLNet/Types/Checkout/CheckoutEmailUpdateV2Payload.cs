namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Updates the email on an existing checkout result payload.
/// </summary>
public class CheckoutEmailUpdateV2Payload
{
    /// <summary>
    /// The checkout object with the updated email.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The list of errors that occurred from executing the mutation.
    /// </summary>
    public CheckoutUserError[] CheckoutUserErrors { get; set; } = default!;

    public static readonly CheckoutEmailUpdateV2Payload Default = new() { Checkout = Checkout.Default };
}