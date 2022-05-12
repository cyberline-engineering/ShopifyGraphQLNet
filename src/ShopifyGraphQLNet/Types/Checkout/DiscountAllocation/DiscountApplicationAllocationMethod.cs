namespace ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;

/// <summary>
/// The method by which the discount's value is allocated onto its entitled lines.
/// </summary>
public enum DiscountApplicationAllocationMethod
{
    /// <summary>
    /// The value is spread across all entitled lines.
    /// </summary>
    ACROSS,
    /// <summary>
    /// The value is applied onto every entitled line.
    /// </summary>
    EACH,
    /// <summary>
    /// deprecated
    /// The value is specifically applied onto a particular line.
    /// Use ACROSS instead.
    /// </summary>
    [Obsolete("Use ACROSS instead.")]
    ONE
}