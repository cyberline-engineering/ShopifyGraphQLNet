namespace ShopifyGraphQLNet.Types.Checkout.DiscountAllocation;

/// <inheritdoc />
public class DiscountApplication: IDiscountApplication
{
    /// <inheritdoc />
    public DiscountApplicationAllocationMethod AllocationMethod { get; set; }
    /// <inheritdoc />
    public DiscountApplicationTargetSelection TargetSelection { get; set; }
    /// <inheritdoc />
    public DiscountApplicationTargetType TargetType { get; set; }
    /// <inheritdoc />
    public object Value { get; set; } = default!;
}