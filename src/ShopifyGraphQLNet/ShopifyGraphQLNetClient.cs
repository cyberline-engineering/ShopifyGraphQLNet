using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet
{
    public class ShopifyGraphQLNetClient
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<ShopifyGraphQLNetClient> logger;
        private readonly JsonSerializerOptions serializerOptions;

        public HttpClient HttpClient => httpClient;

        public ShopifyGraphQLNetClient(HttpClient httpClient, JsonSerializerOptions serializerOptions,
            ILogger<ShopifyGraphQLNetClient> logger)
        {
            this.httpClient = httpClient;
            this.serializerOptions = serializerOptions;
            this.logger = logger;
        }

        public async Task<QueryResult<T>> ExecuteQuery<T>(T value, string operationName, string? query = default, CancellationToken ct = default)
        {
            var variables = QueryBuilder.GetArguments(value);
            query ??= QueryBuilder.Build(value, operationName, variables);

            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(new { query = $"query {query}", variables, operationName }, options: serializerOptions)
            };

            using var response = await httpClient.SendAsync(request, ct).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var content = await logger.LogIfErrorResponse(response).ConfigureAwait(false);
                return QueryResultExtensions.Failed<T>(content);
            }

            var result = await response.ToResult<T>(operationName, serializerOptions, ct);

            return result;
        }

        public async Task<QueryResult<T>> ExecuteMutation<T>(T value, object variables, string operationName, string? mutation = default, CancellationToken ct = default)
        {
            mutation ??= QueryBuilder.Build(value, operationName, variables);

            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(new { query = $"mutation {mutation}", variables, operationName }, options: serializerOptions)
            };

            using var response = await httpClient.SendAsync(request, ct).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                var content = await logger.LogIfErrorResponse(response).ConfigureAwait(false);
                return QueryResultExtensions.Failed<T>(content);
            }

            var result = await response.ToResult<T>(operationName, serializerOptions, ct);

            return result;
        }
    }
}