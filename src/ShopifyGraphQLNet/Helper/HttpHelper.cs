namespace ShopifyGraphQLNet.Helper
{
    internal static class HttpResponseExtensions
    {
        public static bool IsErrorStatusCode(this HttpResponseMessage response)
        {
            var sc = (int) response.StatusCode;
            return sc is > 399 and < 600;
        }
    }
}
