using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Details about the gift card used on the checkout.
/// </summary>
public class AppliedGiftCard: INode
{
    /// <summary>
    /// The amount that was taken from the gift card by applying it.
    /// </summary>
    public MoneyV2 AmountUsedV2 { get; set; } = default!;
    /// <summary>
    /// The amount left on the gift card.
    /// </summary>
    public MoneyV2 BalanceV2 { get; set; } = default!;
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// The last characters of the gift card.
    /// </summary>
    public string LastCharacters { get; set; } = default!;
    /// <summary>
    /// The amount that was applied to the checkout in its currency.
    /// </summary>
    public MoneyV2 PresentmentAmountUsed { get; set; } = default!;
}