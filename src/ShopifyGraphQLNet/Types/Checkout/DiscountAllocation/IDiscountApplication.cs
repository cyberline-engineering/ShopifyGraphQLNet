namespace ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;

/// <summary>
/// Discount applications capture the intentions of a discount source at the time of application.
/// </summary>
public interface IDiscountApplication
{
    /// <summary>
    /// The method by which the discount's value is allocated to its entitled items.
    /// </summary>
    public DiscountApplicationAllocationMethod AllocationMethod { get; set; }
    /// <summary>
    /// Which lines of targetType that the discount is allocated over.
    /// </summary>
    public DiscountApplicationTargetSelection TargetSelection { get; set; }
    /// <summary>
    /// The type of line that the discount is applicable towards.
    /// </summary>
    public DiscountApplicationTargetType TargetType { get; set; }
    /// <summary>
    /// The value of the discount application.
    /// </summary>
    public object Value { get; set; }
}

/// <summary>
/// The price value (fixed or percentage) for a discount application.
/// </summary>
public class PricingValue
{
}