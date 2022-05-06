namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Represents a selling method.
/// For example, 'Subscribe and save' is a selling method where customers pay for goods or services per delivery.
/// A selling plan group contains individual selling plans.
/// </summary>
public class SellingPlanGroup
{
    /// <summary>
    /// A display friendly name for the app that created the selling plan group.
    /// </summary>
    public string? AppName { get; set; }
    /// <summary>
    /// The name of the selling plan group.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// Represents the selling plan options available in the drop-down list in the storefront.
    /// For example, 'Delivery every week' or 'Delivery every 2 weeks' specifies the delivery frequency options for the product.
    /// </summary>
    public SellingPlanGroupOption[] Options { get; set; } = default!;
    /// <summary>
    /// A list of selling plans in a selling plan group.
    /// A selling plan is a representation of how products and variants can be sold and purchased.
    /// For example, an individual selling plan could be '6 weeks of prepaid granola, delivered weekly'.
    /// </summary>
    public SellingPlan[] SellingPlans { get; set; } = default!;
}

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
/// Represents an option on a selling plan group that's available in the drop-down list in the storefront.
/// </summary>
public class SellingPlanGroupOption
{
    /// <summary>
    /// The name of the option. For example, 'Delivery every'.
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// The values for the options specified by the selling plans in the selling plan group. For example, '1 week', '2 weeks', '3 weeks'.
    /// </summary>
    public string[] Values { get; set; } = default!;
}