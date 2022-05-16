namespace ShopifyGraphQLNet.Helper
{
    internal static class HttpResponseExtensions
    {
        public static bool IsErrorStatusCode(this HttpResponseMessage response)
        {
            var sc = (int) response.StatusCode;
            return sc is > 399 and < 600;
        }

        public static HttpRequestMessage PrepareRequest(this HttpRequestMessage request, RequestOptions? options)
        {
            if (options == default) return request;

            if (!String.IsNullOrWhiteSpace(options.Url))
            {
                request.RequestUri = new Uri(options.Url);
            }

            if (options.Headers?.Length > 0)
            {
                foreach (var header in options.Headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            return request;
        }
    }
}
