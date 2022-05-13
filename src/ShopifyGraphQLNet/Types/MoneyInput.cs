namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Specifies the fields for a monetary value with currency.
/// </summary>
public class MoneyInput
{
    /// <summary>
    /// Decimal money amount.
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Currency of the money.
    /// </summary>
    public CurrencyCode CurrencyCode { get; set; }
}