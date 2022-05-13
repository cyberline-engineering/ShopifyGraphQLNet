namespace ShopifyGraphQLNet.Types.SellingPlan;

/// <summary>
/// Represents how products and variants can be sold and purchased.
/// </summary>
public class SellingPlan
{
    /// <summary>
    /// The description of the selling plan.
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// A globally-unique identifier.
    /// </summary>
    public string Id { get; set; } = default!;
    /// <summary>
    /// The name of the selling plan. For example, '6 weeks of prepaid granola, delivered weekly'.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// The selling plan options available in the drop-down list in the storefront.
    /// For example, 'Delivery every week' or 'Delivery every 2 weeks' specifies the delivery frequency options for the product.
    /// </summary>
    public SellingPlanOption[] Options { get; set; } = default!;
    /// <summary>
    /// The price adjustments that a selling plan makes when a variant is purchased with a selling plan.
    /// </summary>
    public SellingPlanPriceAdjustment[] PriceAdjustments { get; set; } = default!;
    /// <summary>
    /// Whether purchasing the selling plan will result in multiple deliveries.
    /// </summary>
    public bool RecurringDeliveries { get; set; }

    public static readonly SellingPlan Default = new()
    {
        Id = String.Empty,
        Name = String.Empty,
        Description = String.Empty,
        Options = Array.Empty<SellingPlanOption>(),
        PriceAdjustments = Array.Empty<SellingPlanPriceAdjustment>()
    };
}

/// <summary>
/// An option provided by a Selling Plan.
/// </summary>
public class SellingPlanOption
{
    /// <summary>
    /// The name of the option (ie "Delivery every").
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// The value of the option (ie "Month").
    /// </summary>
    public string? Value { get; set; }
}

/// <summary>
/// Represents by how much the price of a variant associated with a selling plan is adjusted.
/// Each variant can have up to two price adjustments.
/// </summary>
public class SellingPlanPriceAdjustment
{
    /// <summary>
    /// The type of price adjustment. An adjustment value can have one of three types: percentage, amount off, or a new price.
    /// </summary>
    public object AdjustmentValue { get; set; } = default!;
    /// <summary>
    /// The number of orders that the price adjustment applies to If the price adjustment always applies, then this field is null.
    /// </summary>
    public int? OrderCount { get; set; }
}