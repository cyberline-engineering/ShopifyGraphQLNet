namespace ShopifyGraphQLNet.Types.Product.Arguments;

public class ProductListArguments: ConnectionArguments
{
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