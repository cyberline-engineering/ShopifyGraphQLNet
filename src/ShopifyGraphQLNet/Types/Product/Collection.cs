using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// A collection represents a grouping of products that a shop owner can create to organize them or make their shops easier to browse.
/// Requires unauthenticated_read_product_listings access scope.
/// </summary>
public class Collection: INode, IHasMetafields
{
    /// <summary>
    /// Stripped description of the collection, single line with HTML tags removed.
    /// </summary>
    public string Description { get; set; } = default!;
    /// <summary>
    /// The description of the collection, complete with HTML formatting.
    /// </summary>
    public string DescriptionHtml { get; set; } = default!;
    /// <summary>
    /// A human-friendly unique string for the collection automatically generated from its title. Limit of 255 characters.
    /// </summary>
    public string Handle { get; set; } = default!;
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// Image associated with the collection.
    /// </summary>
    public Image? Image { get; set; }
    /// <inheritdoc />
    public Metafield? Metafield { get; set; }
    /// <summary>
    /// The URL used for viewing the resource on the shop's Online Store.
    /// Returns null if the resource is currently not published to the Online Store sales channel.
    /// </summary>
    public Uri? OnlineStoreUrl { get; set; }
    /// <summary>
    /// The collection's SEO information.
    /// </summary>
    public Seo Seo { get; set; } = default!;
    /// <summary>
    /// The collection’s name. Limit of 255 characters.
    /// </summary>
    public string Title { get; set; } = default!;
    /// <summary>
    /// The date and time when the collection was last modified.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }

    /// <summary>
    /// List of products in the collection.
    /// </summary>
    public ProductConnection Products { get; set; } = default!;

    public static readonly Collection Default = new()
    {
        Id = String.Empty, Handle = String.Empty, Title = String.Empty, Description = String.Empty,
        Image = Image.Default, OnlineStoreUrl = TypeHelper.DefaultUrl, Seo = Seo.Default, DescriptionHtml = String.Empty
    };
}