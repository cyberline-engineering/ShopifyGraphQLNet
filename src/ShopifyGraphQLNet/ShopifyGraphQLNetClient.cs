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

        public async Task<QueryResult<T>> ExecuteQuery<T>(T value, string root, string? query = default, string? operationName = default, CancellationToken ct = default)
        {
            query ??= QueryBuilder.Build(value, root, operationName);
            var variables = QueryBuilder.GetArguments(value);

            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(new { query, variables }, options: serializerOptions)
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