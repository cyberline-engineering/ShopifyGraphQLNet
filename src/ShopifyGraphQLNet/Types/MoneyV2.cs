namespace ShopifyGraphQLNet.Types;

/// <summary>
/// A monetary value with currency.
/// </summary>
public class MoneyV2
{
    /// <summary>
    /// Decimal money amount.
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Currency of the money.
    /// </summary>
    public CurrencyCode CurrencyCode { get; set; }

    public static readonly MoneyV2 Default = new();
}