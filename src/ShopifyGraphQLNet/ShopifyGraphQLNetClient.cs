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

        public ShopifyGraphQLNetClient(HttpClient client, JsonSerializerOptions serializerOptions,
            ILogger<ShopifyGraphQLNetClient> logger)
        {
            this.client = client;
            this.serializerOptions = serializerOptions;
            this.logger = logger;
        }

        public async Task<QueryResult<T>> ExecuteQuery<T>(string query, string root, CancellationToken ct = default)
        {
            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = new StringContent(query, null, "application/graphql")
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

        public Task<QueryResult<T>> ExecuteQuery<T>(T value, string root, object? variables = default,
            CancellationToken ct = default)
        {
            var query = QueryBuilder.Build(value, root, variables);

            return ExecuteQuery<T>(query, root, ct);
        }
    }
}