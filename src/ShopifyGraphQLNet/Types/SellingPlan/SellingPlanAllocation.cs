namespace ShopifyGraphQLNet.Types.SellingPlan;

/// <summary>
/// Represents an association between a variant and a selling plan.
/// Selling plan allocations describe the options offered for each variant, and the price of the variant when purchased with a selling plan.
/// </summary>
public class SellingPlanAllocation
{
    /// <summary>
    /// A list of price adjustments, with a maximum of two.
    /// When there are two, the first price adjustment goes into effect at the time of purchase, while the second one starts after a certain number of orders.
    /// A price adjustment represents how a selling plan affects pricing when a variant is purchased with a selling plan.
    /// Prices display in the customer's currency if the shop is configured for it.
    /// </summary>
    public SellingPlanAllocationPriceAdjustment[] PriceAdjustments { get; set; } = default!;
    /// <summary>
    /// A representation of how products and variants can be sold and purchased. For example, an individual selling plan could be '6 weeks of prepaid granola, delivered weekly'.
    /// </summary>
    public SellingPlan SellingPlan { get; set; } = default!;
}