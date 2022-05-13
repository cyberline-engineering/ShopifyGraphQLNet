namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// Units of measurement for weight.
/// </summary>
public enum WeightUnit
{
    /// <summary>
    /// Metric system unit of mass.
    /// </summary>
    GRAMS,
    /// <summary>
    /// 1 kilogram equals 1000 grams.
    /// </summary>
    KILOGRAMS,
    /// <summary>
    /// Imperial system unit of mass.
    /// </summary>
    OUNCES,
    /// <summary>
    /// 1 pound equals 16 ounces.
    /// </summary>
    POUNDS
}