using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types.Product
{
    /// <summary>
    /// A product represents an individual item for sale in a Shopify store.
    /// Products are often physical, but they don't have to be.
    /// For example, a digital download (such as a movie, music or ebook file) also qualifies as a product,
    /// as do services (such as equipment rental, work for hire, customization of another product or an extended warranty).
    /// </summary>
    public class Product: INode, IOnlineStorePublishable
    {
        /// <inheritdoc />
        public string Id { get; set; } = default!;
        /// <inheritdoc />
        public Uri? OnlineStoreUrl { get; set; }
        /// <summary>
        /// A human-friendly unique string for the Product automatically generated from its title.
        /// They are used by the Liquid templating language to refer to objects.
        /// </summary>
        public string Handle { get; set; } = default!;
        /// <summary>
        /// Stripped description of the product, single line with HTML tags removed.
        /// </summary>
        public string Description { get; set; } = default!;
        /// <summary>
        /// The description of the product, complete with HTML formatting.
        /// </summary>
        public string DescriptionHtml { get; set; } = default!;
        /// <summary>
        /// Indicates if at least one product variant is available for sale.
        /// </summary>
        public bool AvailableForSale { get; set; }
        /// <summary>
        /// The compare at price of the product across all variants.
        /// </summary>
        public ProductPriceRange CompareAtPriceRange { get; set; } = default!;
        /// <summary>
        /// The date and time when the product was created.
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }
        /// <summary>
        /// The featured image for the product.
        /// This field is functionally equivalent to images(first: 1).
        /// </summary>
        public Image? FeaturedImage { get; set; }
        /// <summary>
        /// List of product options.
        /// </summary>
        public ProductOption[] Options { get; set; } = default!;
        /// <summary>
        /// The price range.
        /// </summary>
        public ProductPriceRange PriceRange { get; set; } = default!;
        /// <summary>
        /// A categorization that a product can be tagged with, commonly used for filtering and searching.
        /// </summary>
        public string ProductType { get; set; } = default!;
        /// <summary>
        /// The date and time when the product was published to the channel.
        /// </summary>
        public DateTimeOffset PublishedAt { get; set; }
        /// <summary>
        /// Whether the product can only be purchased with a selling plan.
        /// </summary>
        public bool RequiresSellingPlan { get; set; }
        /// <summary>
        /// The product's SEO information.
        /// </summary>
        public Seo Seo { get; set; } = default!;
        /// <summary>
        /// A comma separated list of tags that have been added to the product.
        /// Additional access scope required for private apps: unauthenticated_read_product_tags.
        /// </summary>
        public string[] Tags { get; set; } = default!;
        /// <summary>
        /// The product’s title.
        /// </summary>
        public string Title { get; set; } = default!;
        /// <summary>
        /// The total quantity of inventory in stock for this Product.
        /// </summary>
        public int? TotalInventory { get; set; }
        /// <summary>
        /// The date and time when the product was last modified.
        /// A product's updatedAt value can change for different reasons.
        /// For example, if an order is placed for a product that has inventory tracking set up,
        /// then the inventory adjustment is counted as an update.
        /// </summary>
        public DateTimeOffset UpdatedAt { get; set; }
        ///// <summary>
        ///// Find a product’s variant based on its selected options.
        ///// This is useful for converting a user’s selection of product options into a single matching variant.
        ///// If there is not a variant for the selected options, null will be returned.
        ///// </summary>
        //public ProductVariant? VariantBySelectedOptions { get; set; }
        /// <summary>
        /// The product’s vendor name.
        /// </summary>
        public string Vendor { get; set; } = default!;

        ///// <summary>
        ///// List of collections a product belongs to.
        ///// </summary>
        //public Connection<Collection> Collections { get; set; } = default!;
        ///// <summary>
        ///// List of images associated with the product.
        ///// </summary>
        //public Connection<Image> Images { get; set; } = default!;
        ///// <summary>
        ///// The media associated with the product.
        ///// </summary>
        //public Connection<IMedia> Media { get; set; } = default!;
        ///// <summary>
        ///// A list of a product's available selling plan groups.
        ///// A selling plan group represents a selling method.
        ///// For example, 'Subscribe and save' is a selling method where customers pay for goods or services per delivery.
        ///// A selling plan group contains individual selling plans.
        ///// </summary>
        //public Connection<SellingPlanGroup> SellingPlanGroups { get; set; } = default!;
        ///// <summary>
        ///// List of the product’s variants.
        ///// </summary>
        //public Connection<ProductVariant> Variants { get; set; } = default!;

        public static readonly Product Default = new();
    }
}
