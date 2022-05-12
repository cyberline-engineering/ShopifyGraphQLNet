using ShopifyGraphQLNet.Helper;

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

    public static readonly CheckoutCreatePayload Default = new()
        { Checkout = new() { WebUrl = TypeHelper.DefaultUrl, LineItems = CheckoutLineItemConnection.Default, Id = String.Empty} };
}