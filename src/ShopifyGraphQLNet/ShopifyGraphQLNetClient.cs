using System.Text.Json;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet
{
    public class ShopifyGraphQLNetClient
    {
        private readonly HttpClient client;
        private readonly ILogger<ShopifyGraphQLNetClient> logger;
        private readonly JsonSerializerOptions serializerOptions;

        public ShopifyGraphQLNetClient(HttpClient client, JsonSerializerOptions serializerOptions, ILogger<ShopifyGraphQLNetClient> logger)
        {
            this.client = client;
            this.serializerOptions = serializerOptions;
            this.logger = logger;
        }

        public async Task<QueryResult<T>> ExecuteQuery<T>(string query, string root, object? variables = default, CancellationToken ct = default)
        {
            var variablesStr = variables != default
                ? $"variables {{{JsonSerializer.Serialize(variables)}}}"
                : String.Empty;

            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent($"query {{{query}}} {variablesStr}", null, "application/graphql")
                //Content = JsonContent.Create(new { query, variables }, new MediaTypeHeaderValue("application/graphql"),
                //    serializerOptions)
            };

            using var response = await client.SendAsync(request, ct).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var content = await logger.LogIfErrorResponse(response).ConfigureAwait(false);
                return QueryResultExtensions.Failed<T>(content);
            }

            var result = await response.ToResult<T>(root, serializerOptions, ct);

            return result;
        }
    }
}