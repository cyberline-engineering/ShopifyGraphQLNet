using System.Text.Json.Nodes;

namespace ShopifyGraphQLNet.Types.Query
{
    public class QueryResponse
    {
        public JsonNode? Data { get; set; }
        /// <summary>
        /// A list of all errors returned.
        /// </summary>
        public Error[]? Errors { get; set; }
    }

    public class Error
    {
        /// <summary>
        /// Contains details about the error(s).
        /// </summary>
        public string Message { get; set; } = default!;
        /// <summary>
        /// Provides more information about the error(s) including properties and metadata.
        /// </summary>
        public ErrorExtensions? Extensions { get; set; }
        public ErrorLocation[]? Locations { get; set; }
    }

    public class ErrorExtensions
    {
        /// <summary>
        /// Shows error codes common to Shopify. Additional error codes may also be shown.
        /// </summary>
        public string Code { get; set; } = default!;
        public string? ArgumentName { get; set; }
        public string? ErrorMessage { get; set; }
        public string? TypeName { get; set; }
        public string? VariableName { get; set; }
    }

    //public enum ErrorExtensionsCode
    //{
    //    /// <summary>
    //    /// The client has exceeded the <see href="https://shopify.dev/api/storefront#rate-limits">rate limit</see>.
    //    /// Similar to 429 Too Many Requests.
    //    /// </summary>
    //    THROTTLED,
    //    /// <summary>
    //    /// The client doesn’t have correct <see href="https://shopify.dev/api/storefront#authentication">authentication credentials</see>.
    //    /// Similar to 401 Unauthorized.
    //    /// </summary>
    //    ACCESS_DENIED,
    //    /// <summary>
    //    /// The shop is not active. This can happen when stores repeatedly exceed API rate limits or due to fraud risk.
    //    /// </summary>
    //    SHOP_INACTIVE,
    //    /// <summary>
    //    /// Shopify experienced an internal error while processing the request. This error is returned instead of 500 Internal Server Error in most circumstances.
    //    /// </summary>
    //    INTERNAL_SERVER_ERROR
    //}

    public class ErrorLocation
    {
        public long Line { get; set; }
        public long Column { get; set; }
    }
}
