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
}

/// <summary>
/// The three-letter currency codes that represent the world currencies used in stores. These include standard ISO 4217 codes, legacy codes, and non-standard codes.
/// </summary>
public enum CurrencyCode
{
    /// <summary>
    /// United States Dollars (USD).
    /// </summary>
    USD
}