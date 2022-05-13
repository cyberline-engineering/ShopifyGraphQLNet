namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// The price range of the product.
/// </summary>
public class ProductPriceRange
{
    /// <summary>
    /// The highest variant's price.
    /// </summary>
    public MoneyV2 MaxVariantPrice { get; set; } = default!;

    /// <summary>
    /// The lowest variant's price.
    /// </summary>
    public MoneyV2 MinVariantPrice { get; set; } = default!;

    public static readonly ProductPriceRange Default = new()
        { MinVariantPrice = MoneyV2.Default, MaxVariantPrice = MoneyV2.Default };
}