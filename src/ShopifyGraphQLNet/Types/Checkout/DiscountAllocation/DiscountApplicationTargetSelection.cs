namespace ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;

/// <summary>
/// Which lines on the order that the discount is allocated over, of the type defined by the Discount Application's target_type.
/// </summary>
public enum DiscountApplicationTargetSelection
{
    /// <summary>
    /// The discount is allocated onto all the lines.
    /// </summary>
    ALL,
    /// <summary>
    /// The discount is allocated onto only the lines it is entitled for.
    /// </summary>
    ENTITLED,
    /// <summary>
    /// The discount is allocated onto explicitly chosen lines.
    /// </summary>
    EXPLICIT
}