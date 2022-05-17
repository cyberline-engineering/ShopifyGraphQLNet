using ShopifyGraphQLNet.Helper;

namespace ShopifyGraphQLNet.Types.OnlineStore;

public class PaymentSettings
{
    /// <summary>
    /// List of the card brands which the shop accepts.
    /// </summary>
    public CardBrand[] AcceptedCardBrands { get; set; } = default!;
    /// <summary>
    /// The url pointing to the endpoint to vault credit cards.
    /// </summary>
    public Uri CardVaultUrl { get; set; } = default!;
    /// <summary>
    /// The country where the shop is located.
    /// </summary>
    public CountryCode CountryCode { get; set; }
    /// <summary>
    /// The three-letter code for the shop's primary currency.
    /// </summary>
    public CurrencyCode CurrencyCode { get; set; }
    /// <summary>
    /// A list of enabled currencies (ISO 4217 format) that the shop accepts.
    /// Merchants can enable currencies from their Shopify Payments settings in the Shopify admin.
    /// </summary>
    public CurrencyCode[] EnabledPresentmentCurrencies { get; set; } = default!;
    /// <summary>
    /// The shop’s Shopify Payments account id.
    /// </summary>
    public string? ShopifyPaymentsAccountId { get; set; }
    /// <summary>
    /// List of the digital wallets which the shop supports.
    /// </summary>
    public DigitalWallet[] SupportedDigitalWallets { get; set; } = default!;

    public static readonly PaymentSettings Default = new()
    {
        AcceptedCardBrands = Array.Empty<CardBrand>(), CardVaultUrl = TypeHelper.DefaultUrl,
        EnabledPresentmentCurrencies = Array.Empty<CurrencyCode>(), ShopifyPaymentsAccountId = String.Empty,
        SupportedDigitalWallets = Array.Empty<DigitalWallet>(),
    };
}

/// <summary>
/// Digital wallet, such as Apple Pay, which can be used for accelerated checkouts.
/// </summary>
public enum DigitalWallet
{
    /// <summary>
    /// Android Pay.
    /// </summary>
    ANDROID_PAY,
    /// <summary>
    /// Apple Pay.
    /// </summary>
    APPLE_PAY,
    /// <summary>
    /// Google Pay.
    /// </summary>
    GOOGLE_PAY,
    /// <summary>
    /// Shopify Pay.
    /// </summary>
    SHOPIFY_PAY
}

/// <summary>
/// Card brand, such as Visa or Mastercard, which can be used for payments.
/// </summary>
public enum CardBrand
{
    /// <summary>
    /// American Express.
    /// </summary>
    AMERICAN_EXPRESS,
    /// <summary>
    /// Diners Club.
    /// </summary>
    DINERS_CLUB,
    /// <summary>
    /// Discover.
    /// </summary>
    DISCOVER,
    /// <summary>
    /// JCB.
    /// </summary>
    JCB,
    /// <summary>
    /// Mastercard.
    /// </summary>
    MASTERCARD,
    /// <summary>
    /// Visa.
    /// </summary>
    VISA
}