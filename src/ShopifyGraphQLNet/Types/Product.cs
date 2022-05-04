using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyGraphQLNet.Types
{
    /// <summary>
    /// A product represents an individual item for sale in a Shopify store.
    /// Products are often physical, but they don't have to be.
    /// For example, a digital download (such as a movie, music or ebook file) also qualifies as a product,
    /// as do services (such as equipment rental, work for hire, customization of another product or an extended warranty).
    /// </summary>
    public class Product: INode, IOnlineStorePublishable, IHasMetafields
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
        /// <inheritdoc />
        public Metafield? Metafield { get; set; }
    }

    /// <summary>
    /// An auto-generated type which holds one Product and a cursor during pagination.
    /// </summary>
    public class ProductEdge
    {
        /// <summary>
        /// A cursor for use in pagination.
        /// </summary>
        public string Cursor { get; set; } = default!;
        /// <summary>
        /// The item at the end of ProductEdge.
        /// </summary>
        public Product Node { get; set; } = default!;
    }

    /// <summary>
    /// An auto-generated type for paginating through multiple Products.
    /// </summary>
    public class ProductConnection
    {
        /// <summary>
        /// A list of edges.
        /// </summary>
        public ProductEdge[] Edges { get; set; } = default!;
        /// <summary>
        /// A list of available filters.
        /// </summary>
        public Filter[] Filters { get; set; } = default!;
        /// <summary>
        /// A list of the nodes contained in ProductEdge.
        /// </summary>
        public Product[] Nodes { get; set; } = default!;
        /// <inheritdoc cref="PageInfo"/>
        public PageInfo PageInfo { get; set; } = default!;

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
