namespace ShopifyGraphQLNet.Types;

/// <summary>
/// A filter that is supported on the parent field.
/// </summary>
public class Filter
{
    /// <summary>
    /// A unique identifier.
    /// </summary>
    public string Id { get; set; } = default!;
    /// <summary>
    /// A human-friendly string for this filter.
    /// </summary>
    public string Label { get; set; } = default!;
    /// <summary>
    /// An enumeration that denotes the type of data this filter represents.
    /// </summary>
    public FilterType Type { get; set; } = default!;
    /// <summary>
    /// The list of values for this filter.
    /// </summary>
    public FilterValue[] Values { get; set; } = default!;
}

/// <summary>
/// The type of data that the filter group represents.
/// For more information, refer to <see href="https://shopify.dev/api/examples/filter-products">[Filter products in a collection with the Storefront API]</see> 
/// </summary>
public enum FilterType
{
    /// <summary>
    /// A boolean value.
    /// </summary>
    BOOLEAN,
    /// <summary>
    /// A list of selectable values.
    /// </summary>
    LIST,
    /// <summary>
    /// A range of prices.
    /// </summary>
    PRICE_RANGE
}

/// <summary>
/// A selectable value within a filter.
/// </summary>
public class FilterValue
{
    /// <summary>
    /// The number of results that match this filter value.
    /// </summary>
    public int Count { get; set; }
    /// <summary>
    /// A unique identifier.
    /// </summary>
    public string Id { get; set; } = default!;
    /// <summary>
    /// An input object that can be used to filter by this value on the parent field.
    /// The value is provided as a helper for building dynamic filtering UI.
    /// For example, if you have a list of selected FilterValue objects,
    /// you can combine their respective input values to use in a subsequent query.
    /// </summary>
    public string Input { get; set; } = default!;
    /// <summary>
    /// A human-friendly string for this filter value.
    /// </summary>
    public string Label { get; set; } = default!;
}