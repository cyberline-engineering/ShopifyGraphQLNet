namespace ShopifyGraphQLNet.Types;

/// <summary>
/// The availability of a product variant at a particular location.
/// Local pick-up must be enabled in the store's shipping settings, otherwise this will return an empty result.
/// </summary>
public class StoreAvailability
{
    /// <summary>
    /// Whether or not this product variant is in-stock at this location.
    /// </summary>
    public bool Available { get; set; }
    /// <summary>
    /// The location where this product variant is stocked at.
    /// </summary>
    public Location Location { get; set; } = default!;
    /// <summary>
    /// Returns the estimated amount of time it takes for pickup to be ready (Example: Usually ready in 24 hours).
    /// </summary>
    public string PickUpTime { get; set; } = default!;
}