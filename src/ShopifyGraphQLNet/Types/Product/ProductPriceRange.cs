namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// The price range of the product.
/// </summary>
public class ProductPriceRange
{
    /// <summary>
    /// The highest variant's price.
    /// </summary>
    public MoneyV2 MaxVariantPrice { get; set; }
    /// <summary>
    /// The lowest variant's price.
    /// </summary>
    public MoneyV2 MinVariantPrice { get; set; }
}