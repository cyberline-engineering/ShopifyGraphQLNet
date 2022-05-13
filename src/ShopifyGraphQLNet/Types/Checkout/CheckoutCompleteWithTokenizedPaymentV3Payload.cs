namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Completes a checkout with a tokenized payment result payload.
/// </summary>
public class CheckoutCompleteWithTokenizedPaymentV3Payload
{
    /// <summary>
    /// The checkout on which the payment was applied.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The list of errors that occurred from executing the mutation.
    /// </summary>
    public CheckoutUserError[] CheckoutUserErrors { get; set; } = default!;
    /// <summary>
    /// A representation of the attempted payment.
    /// </summary>
    public Payment Payment { get; set; } = default!;

    public static readonly CheckoutCompleteWithTokenizedPaymentV3Payload Default = new()
        { Checkout = Checkout.Default, Payment = Payment.Default };
}