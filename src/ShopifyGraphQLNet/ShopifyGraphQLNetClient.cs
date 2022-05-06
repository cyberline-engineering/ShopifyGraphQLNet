using System.Net.Http.Json;
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

        public async Task<QueryResult<TValue>> ExecuteQuery<TValue, TArguments>(string query, string root, TArguments? variables = default, CancellationToken ct = default)
        {
            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(new { query, variables }, options: serializerOptions)
            };

            using var response = await client.SendAsync(request, ct).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var content = await logger.LogIfErrorResponse(response).ConfigureAwait(false);
                return QueryResultExtensions.Failed<TValue>(content);
            }

            var result = await response.ToResult<TValue>(root, serializerOptions, ct);

            return result;
        }

        public Task<QueryResult<TValue>> ExecuteQuery<TValue, TArguments>(TValue value, string root,
            string? operationName = default, TArguments? variables = default, CancellationToken ct = default)
        {
            var query = QueryBuilder.Build(value, root, operationName, variables);

            return ExecuteQuery<TValue, TArguments>(query, root, variables, ct);
        }
    }
}