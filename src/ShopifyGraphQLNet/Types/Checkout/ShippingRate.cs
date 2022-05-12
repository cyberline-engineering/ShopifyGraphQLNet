namespace ShopifyGraphQLNet.Types.Checkout;

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
}