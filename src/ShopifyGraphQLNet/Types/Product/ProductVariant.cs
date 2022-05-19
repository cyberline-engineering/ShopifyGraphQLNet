using ShopifyGraphQLNet.Types.Interface;
using ShopifyGraphQLNet.Types.SellingPlan;

namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// A product variant represents a different version of a product, such as differing sizes or differing colors.
/// </summary>
public class ProductVariant : INode, IHasMetafields
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

    /// <summary>
    /// Returns a metafield found by namespace and key.
    /// </summary>
    public Metafield? Metafield { get; set; }

    /// <summary>
    /// The product variant’s price.
    /// </summary>
    public MoneyV2 PriceV2 { get; set; } = default!;

    /// <summary>
    /// The product object that the product variant belongs to.
    /// </summary>
    public Product Product { get; set; } = default!;

    /// <summary>
    /// The total sellable quantity of the variant for online sales channels.
    /// </summary>
    public int? QuantityAvailable { get; set; }

    /// <summary>
    /// Whether a customer needs to provide a shipping address when placing an order for the product variant.
    /// </summary>
    public bool RequiresShipping { get; set; }

    /// <summary>
    /// List of product options applied to the variant.
    /// </summary>
    public SelectedOption[] SelectedOptions { get; set; } = default!;

    /// <summary>
    /// The SKU (stock keeping unit) associated with the variant.
    /// </summary>
    public string? Sku { get; set; }

    /// <summary>
    /// The product variant’s title.
    /// </summary>
    public string Title { get; set; } = default!;

    /// <summary>
    /// The unit price value for the variant based on the variant's measurement.
    /// </summary>
    public MoneyV2? UnitPrice { get; set; }

    /// <summary>
    /// The unit price measurement for the variant.
    /// </summary>
    public UnitPriceMeasurement? UnitPriceMeasurement { get; set; }

    /// <summary>
    /// The weight of the product variant in the unit system specified with weight_unit.
    /// </summary>
    public double? Weight { get; set; }

    /// <summary>
    /// Unit of measurement for weight.
    /// </summary>
    public WeightUnit WeightUnit { get; set; }

    ///// <summary>
    ///// Represents an association between a variant and a selling plan.
    ///// Selling plan allocations describe which selling plans are available for each variant, and what their impact is on pricing.
    ///// </summary>
    //public SellingPlanAllocationConnection SellingPlanAllocations { get; set; } = default!;
    ///// <summary>
    ///// The in-store pickup availability of this variant by location.
    ///// </summary>
    //public StoreAvailabilityConnection StoreAvailability { get; set; } = default!;

    public static readonly ProductVariant Default = new()
    {
        Barcode = String.Empty,
        CompareAtPriceV2 = MoneyV2.Default,
        Id = String.Empty,
        Image = Image.Default,
        PriceV2 = MoneyV2.Default,
        QuantityAvailable = default,
        SelectedOptions = new[] { SelectedOption.Default },
        Sku = String.Empty,
        Title = String.Empty,
    };
}

public class StoreAvailabilityConnection: Connection<SellingPlanAllocation>
{ }

public class SellingPlanAllocationConnection: Connection<StoreAvailability>
{ }