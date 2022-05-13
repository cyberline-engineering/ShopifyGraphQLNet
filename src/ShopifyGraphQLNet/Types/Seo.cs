namespace ShopifyGraphQLNet.Types;

/// <summary>
/// SEO information.
/// </summary>
public class Seo
{
    /// <summary>
    /// The meta description.
    /// </summary>
    public string? Description { get; set; }
    /// <summary>
    /// The SEO title.
    /// </summary>
    public string? Title { get; set; }

    public static readonly Seo Default = new() { Description = String.Empty, Title = String.Empty };
}