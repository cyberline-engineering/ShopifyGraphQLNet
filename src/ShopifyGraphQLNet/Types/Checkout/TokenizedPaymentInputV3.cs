namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Specifies the fields required to complete a checkout with a tokenized payment.
/// </summary>
public class TokenizedPaymentInputV3
{
    /// <summary>
    /// The billing address for the payment.
    /// </summary>
    public MailingAddressInput BillingAddress { get; set; } = default!;
    /// <summary>
    /// A unique client generated key used to avoid duplicate charges.
    /// When a duplicate payment is found, the original is returned instead of creating a new one.
    /// For more information, refer to <see href="https://shopify.dev/api/usage/idempotent-requests">Idempotent requests</see>.
    /// </summary>
    public string IdempotencyKey { get; set; } = default!;
    /// <summary>
    /// Public Hash Key used for AndroidPay payments only.
    /// </summary>
    public string? Identifier { get; set; }
    /// <summary>
    /// The amount and currency of the payment.
    /// </summary>
    public MoneyInput PaymentAmount { get; set; } = default!;
    /// <summary>
    /// A simple string or JSON containing the required payment data for the tokenized payment.
    /// </summary>
    public string PaymentData { get; set; } = default!;
    /// <summary>
    /// Whether to execute the payment in test mode, if possible.
    /// Test mode is not supported in production stores. Defaults to false.
    /// </summary>
    public bool? Test { get; set; }
    /// <summary>
    /// The type of payment token.
    /// </summary>
    public PaymentTokenType Type { get; set; }
}