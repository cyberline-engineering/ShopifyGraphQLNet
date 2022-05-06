using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Metafields represent custom metadata attached to a resource.
/// Metafields can be sorted into namespaces and are comprised of keys, values, and value types.
/// </summary>
public class Metafield: INode
{
    /// <summary>
    /// The date and time when the storefront metafield was created.
    /// </summary>
    public DateTimeOffset CreatedAt { get; set; }
    /// <summary>
    /// The description of a metafield.
    /// </summary>
    public string? Description { get; set; }
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// The key name for a metafield.
    /// </summary>
    public string Key { get; set; } = default!;
    /// <summary>
    /// The namespace for a metafield.
    /// </summary>
    public string Namespace { get; set; } = default!;
    /// <summary>
    /// The parent object that the metafield belongs to.
    /// Possible types:
    /// <list type="bullet">
    /// <item>Article</item>
    /// <item>Blog</item>
    /// <item>Collection</item>
    /// <item>Customer</item>
    /// <item>Order</item>
    /// <item>Page</item>
    /// <item>Product</item>
    /// <item>ProductVariant</item>
    /// <item>Shop</item>
    /// </list>
    /// </summary>
    public object ParentResource { get; set; }
    /// <summary>
    /// The type name of the metafield. See the list of <see href="https://shopify.dev/apps/metafields/definitions/types">supported types</see>
    /// </summary>
    public string Type { get; set; } = default!;
    /// <summary>
    /// The date and time when the storefront metafield was updated.
    /// </summary>
    public DateTimeOffset UpdatedAt { get; set; }
    /// <summary>
    /// The value of a metafield.
    /// </summary>
    public string Value { get; set; } = default!;
}
