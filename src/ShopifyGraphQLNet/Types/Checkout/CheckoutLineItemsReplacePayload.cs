namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Sets a list of line items to a checkout result payload.
/// </summary>
public class CheckoutLineItemsReplacePayload
{
    /// <summary>
    /// The updated checkout object.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The list of errors that occurred from executing the mutation.
    /// </summary>
    public CheckoutUserError[] UserErrors { get; set; } = default!;

    public static readonly CheckoutLineItemsReplacePayload Default = new() { Checkout = Checkout.Default };
}