namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Updates line items on a checkout result payload
/// </summary>
public class CheckoutLineItemsUpdatePayload
{
    /// <summary>
    /// The updated checkout object.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The list of errors that occurred from executing the mutation.
    /// </summary>
    public CheckoutUserError[] CheckoutUserErrors { get; set; } = default!;

    public static readonly CheckoutLineItemsUpdatePayload Default = new() { Checkout = Checkout.Default };
}