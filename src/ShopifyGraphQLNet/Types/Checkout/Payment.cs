using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// A payment applied to a checkout.
/// Requires unauthenticated_read_checkouts access scope.
/// </summary>
public class Payment: INode
{
    /// <summary>
    /// The amount of the payment.
    /// </summary>
    public MoneyV2 AmountV2 { get; set; } = default!;
    /// <summary>
    /// The billing address for the payment.
    /// </summary>
    public MailingAddress? BillingAddress { get; set; }
    /// <summary>
    /// The checkout to which the payment belongs.
    /// </summary>
    public Checkout Checkout { get; set; } = default!;
    /// <summary>
    /// The credit card used for the payment in the case of direct payments.
    /// </summary>
    public CreditCard? CreditCard { get; set; }
    /// <summary>
    /// A message describing a processing error during asynchronous processing.
    /// </summary>
    public string? ErrorMessage { get; set; }
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// A client-side generated token to identify a payment and perform idempotent operations. For more information,
    /// refer to <see href="https://shopify.dev/api/usage/idempotent-requests">Idempotent requests</see>.
    /// </summary>
    public string? IdempotencyKey { get; set; }
    /// <summary>
    /// The URL where the customer needs to be redirected so they can complete the 3D Secure payment flow.
    /// </summary>
    public string? NextActionUrl { get; set; }
    /// <summary>
    /// Whether or not the payment is still processing asynchronously.
    /// </summary>
    public bool Ready { get; set; }
    /// <summary>
    /// A flag to indicate if the payment is to be done in test mode for gateways that support it.
    /// </summary>
    public bool Test { get; set; }

    /// <summary>
    /// The actual transaction recorded by Shopify after having processed the payment with the gateway.
    /// </summary>
    public Transaction Transaction { get; set; } = default!;

    public static readonly Payment Default = new()
    {
        AmountV2 = MoneyV2.Default, Id = String.Empty, CreditCard = CreditCard.Default,
        BillingAddress = MailingAddress.Default, ErrorMessage = String.Empty, IdempotencyKey = String.Empty,
        NextActionUrl = String.Empty, Transaction = Transaction.Default
    };
}