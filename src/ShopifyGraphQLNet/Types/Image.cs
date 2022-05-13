using ShopifyGraphQLNet.Helper;

namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Represents an image resource.
/// </summary>
public class Image
{
    /// <summary>
    /// A word or phrase to share the nature or contents of an image.
    /// </summary>
    public string? AltText { get; set; }

    /// <summary>
    /// The original height of the image in pixels. Returns null if the image is not hosted by Shopify.
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// A unique identifier for the image.
    /// </summary>
    public string? Id { get; set; } = default!;

    /// <summary>
    /// The location of the image as a URL.
    /// </summary>
    public Uri Url { get; set; } = default!;
    /// <summary>
    /// The original width of the image in pixels. Returns null if the image is not hosted by Shopify.
    /// </summary>
    public int? Width { get; set; }

    public static readonly Image Default = new()
        { Id = String.Empty, AltText = String.Empty, Height = 0, Width = 0, Url = TypeHelper.DefaultUrl };
}