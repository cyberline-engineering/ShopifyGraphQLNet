namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// The valid values for the types of payment token.
/// </summary>
public enum PaymentTokenType
{
    /// <summary>
    /// Apple Pay token type.
    /// </summary>
    APPLE_PAY,
    /// <summary>
    /// Google Pay token type.
    /// </summary>
    GOOGLE_PAY,
    /// <summary>
    /// Shopify Pay token type.
    /// </summary>
    SHOPIFY_PAY,
    /// <summary>
    /// Stripe token type.
    /// </summary>
    STRIPE_VAULT_TOKEN,
    /// <summary>
    /// Vault payment token type.
    /// </summary>
    VAULT
}