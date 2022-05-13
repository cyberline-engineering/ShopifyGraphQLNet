namespace ShopifyGraphQLNet.Types.SellingPlan;

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
    public SellingPlanConnection SellingPlans { get; set; } = default!;

    public static readonly SellingPlanGroup Default = new()
    {
        Name = String.Empty, 
        AppName = String.Empty, 
        Options = Array.Empty<SellingPlanGroupOption>(),

        SellingPlans = SellingPlanConnection.Default
    };
}

public class SellingPlanConnection: Connection<SellingPlan>
{
    internal static readonly SellingPlanConnection Default = new()
        { _arguments = ConnectionArguments.Default, Nodes = new[] { SellingPlan.Default } };
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