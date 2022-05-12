namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// A shipping rate to be applied to a checkout.
/// </summary>
public class ShippingRate
{
    /// <summary>
    /// Human-readable unique identifier for this shipping rate.
    /// </summary>
    public string Handle { get; set; } = default!;
    /// <summary>
    /// Price of this shipping rate.
    /// </summary>
    public MoneyV2 PriceV2 { get; set; } = default!;
    /// <summary>
    /// Title of this shipping rate.
    /// </summary>
    public string Title { get; set; } = default!;

    public static readonly ShippingRate Default = new()
        { Handle = String.Empty, Title = String.Empty, PriceV2 = MoneyV2.Default };
}