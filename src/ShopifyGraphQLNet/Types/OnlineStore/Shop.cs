using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types.OnlineStore;

/// <summary>
/// Shop represents a collection of the general settings and information about the shop.
/// Requires unauthenticated_read_product_listings access scope.
/// </summary>
public class Shop: INode, IHasMetafields
{
    /// <summary>
    /// A description of the shop.
    /// </summary>
    public string? Description { get; set; }
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <inheritdoc />
    public Metafield? Metafield { get; set; }
    /// <summary>
    /// A string representing the way currency is formatted when the currency isn’t specified.
    /// </summary>
    public string MoneyFormat { get; set; } = default!;
    /// <summary>
    /// The shop’s name.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// Settings related to payments.
    /// </summary>
    public PaymentSettings PaymentSettings { get; set; } = default!;
    /// <summary>
    /// The shop’s primary domain.
    /// </summary>
    public Domain PrimaryDomain { get; set; } = default!;
    /// <summary>
    /// The shop’s privacy policy.
    /// </summary>
    public ShopPolicy? PrivacyPolicy { get; set; }
    /// <summary>
    /// The shop’s refund policy.
    /// </summary>
    public ShopPolicy? RefundPolicy { get; set; }
    /// <summary>
    /// The shop’s shipping policy.
    /// </summary>
    public ShopPolicy? ShippingPolicy { get; set; }
    /// <summary>
    /// Countries that the shop ships to.
    /// </summary>
    public CountryCode[] ShipsToCountries { get; set; } = default!;
    /// <summary>
    /// The shop’s subscription policy.
    /// </summary>
    public ShopPolicyWithDefault? SubscriptionPolicy { get; set; }
    /// <summary>
    /// The shop’s terms of service.
    /// </summary>
    public ShopPolicy? TermsOfService { get; set; }

    public static readonly Shop Default = new()
    {
        Id = String.Empty, Name = String.Empty, Description = String.Empty, MoneyFormat = String.Empty,
        PaymentSettings = PaymentSettings.Default, PrimaryDomain = Domain.Default,
        ShipsToCountries = Array.Empty<CountryCode>()
    };
}