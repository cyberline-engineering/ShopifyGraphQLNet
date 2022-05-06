namespace ShopifyGraphQLNet.Types.Interface;

/// <summary>
/// Represents a media interface.
/// </summary>
public interface IMedia
{
    /// <summary>
    /// A word or phrase to share the nature or contents of a media.
    /// </summary>
    public string? Alt { get; set; }
    /// <summary>
    /// The media content type.
    /// </summary>
    public MediaContentType MediaContentType { get; set; }
    /// <summary>
    /// The preview image for the media.
    /// </summary>
    public Image? PreviewImage { get; set; }
}

/// <summary>
/// The possible content types for a media object.
/// </summary>
public enum MediaContentType
{
    /// <summary>
    /// An externally hosted video.
    /// </summary>
    EXTERNAL_VIDEO,
    /// <summary>
    /// A Shopify hosted image.
    /// </summary>
    IMAGE,
    /// <summary>
    /// A 3d model.
    /// </summary>
    MODEL_3D,
    /// <summary>
    /// A Shopify hosted video.
    /// </summary>
    VIDEO

}