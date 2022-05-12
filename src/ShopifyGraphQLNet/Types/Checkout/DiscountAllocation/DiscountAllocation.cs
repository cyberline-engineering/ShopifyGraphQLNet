namespace ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;

/// <summary>
/// An amount discounting the line that has been allocated by a discount.
/// </summary>
public class DiscountAllocation
{
    /// <summary>
    /// Amount of discount allocated.
    /// </summary>
    public MoneyV2 AllocatedAmount { get; set; } = default!;

    /// <summary>
    /// The discount this allocated amount originated from.
    /// </summary>
    public DiscountApplication DiscountApplication { get; set; } = default!;
}