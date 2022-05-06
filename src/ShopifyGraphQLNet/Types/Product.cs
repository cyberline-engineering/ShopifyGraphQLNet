using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace ShopifyGraphQLNet.Types
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
    }

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

    /// <summary>
    /// Product property names like "Size", "Color", and "Material" that the customers can select. Variants are selected based on permutations of these options. 255 characters limit each.
    /// </summary>
    public class ProductOption: INode
    {
        /// <inheritdoc />
        public string Id { get; set; } = default!;
        /// <summary>
        /// The product option’s name.
        /// </summary>
        public string Name { get; set; } = default!;
        /// <summary>
        /// The corresponding value to the product option name.
        /// </summary>
        public string[] Values { get; set; } = default!;
    }

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

    /// <summary>
    /// An auto-generated type for paginating through multiple Products.
    /// </summary>
    public class ProductConnection: Connection<Product>
    {
        /// <summary>
        /// A list of available filters.
        /// </summary>
        public Filter[] Filters { get; set; } = default!;

        public static readonly ProductConnection Default = new();
    }

    public class ProductConnectionArguments
    {
        /// <summary>
        /// Returns the elements that come after the specified cursor.
        /// </summary>
        public string? After { get; set; }
        /// <summary>
        /// Returns the elements that come before the specified cursor.
        /// </summary>
        public string? Before { get; set; }
        /// <summary>
        /// Returns up to the first n elements from the list.
        /// </summary>
        public int? First { get; set; }
        /// <summary>
        /// Returns up to the last n elements from the list.
        /// </summary>
        public int? Last { get; set; }
        /// <summary>
        /// See the detailed <see href="https://shopify.dev/api/usage/search-syntax">search syntax</see> for more information about using filters.
        /// Supported filter parameters:
        /// <list type="bullet">
        /// <item>available_for_sale</item>
        /// <item>created_at</item>
        /// <item>product_type</item>
        /// <item>tag</item>
        /// <item>tag_not</item>
        /// <item>title</item>
        /// <item>updated_at</item>
        /// <item>variants.price</item>
        /// <item>vendor</item>
        /// </list>
        /// </summary>
        public string? Query { get; set; }
        /// <summary>
        /// Reverse the order of the underlying list.
        /// </summary>
        public bool? Reverse { get; set; }
        /// <summary>
        /// Sort the underlying list by the given key.
        /// </summary>
        public ProductSortKey? SortKey { get; set; }
    }

    /// <summary>
    /// The set of valid sort keys for the Product query.
    /// </summary>
    public enum ProductSortKey
    {
        /// <summary>
        /// Sort by the best_selling value.
        /// </summary>
        BEST_SELLING,
        /// <summary>
        /// Sort by the created_at value.
        /// </summary>
        CREATED_AT,
        /// <summary>
        /// Sort by the id value.
        /// </summary>
        ID,
        /// <summary>
        /// Sort by the price value.
        /// </summary>
        PRICE,
        /// <summary>
        /// Sort by the product_type value.
        /// </summary>
        PRODUCT_TYPE,
        /// <summary>
        /// Sort by relevance to the search terms when the query parameter is specified on the connection.
        /// Don't use this sort key when no search query is specified.
        /// </summary>
        RELEVANCE,
        /// <summary>
        /// Sort by the title value.
        /// </summary>
        TITLE,
        /// <summary>
        /// Sort by the updated_at value.
        /// </summary>
        UPDATED_AT,
        /// <summary>
        /// Sort by the vendor value.
        /// </summary>
        VENDOR,
    }
}
