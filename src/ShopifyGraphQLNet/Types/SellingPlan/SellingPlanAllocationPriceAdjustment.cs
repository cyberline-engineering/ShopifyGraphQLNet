namespace ShopifyGraphQLNet.Types.SellingPlan;

/// <summary>
/// The resulting prices for variants when they're purchased with a specific selling plan.
/// Requires unauthenticated_read_selling_plans access scope.
/// </summary>
public class SellingPlanAllocationPriceAdjustment
{
    /// <summary>
    /// The price of the variant when it's purchased without a selling plan for the same number of deliveries.
    /// For example, if a customer purchases 6 deliveries of $10.00 granola separately, then the price is 6 x $10.00 = $60.00.
    /// </summary>
    public MoneyV2 CompareAtPrice { get; set; } = default!;
    /// <summary>
    /// The effective price for a single delivery.
    /// For example, for a prepaid subscription plan that includes 6 deliveries at the price of $48.00, the per delivery price is $8.00.
    /// </summary>
    public MoneyV2 PerDeliveryPrice { get; set; } = default!;
    /// <summary>
    /// The price of the variant when it's purchased with a selling plan.
    /// For example, for a prepaid subscription plan that includes 6 deliveries of $10.00 granola, where the customer gets 20% off, the price is 6 x $10.00 x 0.80 = $48.00.
    /// </summary>
    public MoneyV2 Price { get; set; } = default!;
    /// <summary>
    /// The resulting price per unit for the variant associated with the selling plan.
    /// If the variant isn't sold by quantity or measurement, then this field returns null.
    /// </summary>
    public MoneyV2? UnitPrice { get; set; }
}