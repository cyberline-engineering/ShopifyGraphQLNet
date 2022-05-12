namespace ShopifyGraphQLNet.Types.Checkout;

public class AvailableShippingRates
{
    /// <summary>
    /// Whether or not the shipping rates are ready.
    /// The shippingRates field is null when this value is false.
    /// This field should be polled until its value becomes true.
    /// </summary>
    public bool Ready { get; set; }

    /// <summary>
    /// The fetched shipping rates. null until the ready field is true.
    /// </summary>
    public ShippingRate[]? ShippingRates { get; set; }
}