namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Create checkout result payload
/// </summary>
public class CheckoutCreatePayload
{
    /// <summary>
    /// The new checkout object.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The list of errors that occurred from executing the mutation.
    /// </summary>
    public CheckoutUserError[] CheckoutUserErrors { get; set; } = default!;
    /// <summary>
    /// The checkout queue token. Available only to selected stores.
    /// </summary>
    public string? QueueToken { get; set; }
}