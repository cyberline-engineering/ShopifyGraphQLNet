namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Updates the shipping address of an existing checkout result payload
/// </summary>
public class CheckoutShippingAddressUpdateV2Payload
{
    /// <summary>
    /// The new checkout object.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The list of errors that occurred from executing the mutation.
    /// </summary>
    public CheckoutUserError[] CheckoutUserErrors { get; set; } = default!;

    public static readonly CheckoutShippingAddressUpdateV2Payload Default = new() { Checkout = Checkout.Default };
}