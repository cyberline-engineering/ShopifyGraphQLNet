namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// A product variant represents a different version of a product, such as differing sizes or differing colors.
/// </summary>
public class ProductVariant: INode
{
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// Indicates if the product variant is available for sale.
    /// </summary>
    public bool AvailableForSale { get; set; }
    /// <summary>
    /// The barcode (for example, ISBN, UPC, or GTIN) associated with the variant.
    /// </summary>
    public string? Barcode { get; set; }
    /// <summary>
    /// The compare at price of the variant.
    /// This can be used to mark a variant as on sale, when compareAtPriceV2 is higher than priceV2.
    /// </summary>
    public MoneyV2? CompareAtPriceV2 { get; set; }
    /// <summary>
    /// Whether a product is out of stock but still available for purchase (used for backorders).
    /// </summary>
    public bool CurrentlyNotInStock { get; set; }
    /// <summary>
    /// Image associated with the product variant. This field falls back to the product image if no image is available.
    /// </summary>
    public Image? Image { get; set; }
}