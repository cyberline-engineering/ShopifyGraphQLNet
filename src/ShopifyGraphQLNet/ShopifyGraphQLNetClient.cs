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

        public async Task<QueryResult<T>> ExecuteQuery<T, TArg>(T value, TArg variables, string operationName,  string? query = default,
            RequestOptions? options = default, CancellationToken ct = default)
        {
            query ??= $"query {QueryBuilder.Build(value, operationName, variables)}";            

            using var request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Post,
                    Content = JsonContent.Create(new { query, variables, operationName },
                        options: serializerOptions)
                }
                .PrepareRequest(options);

            using var response = await httpClient.SendAsync(request, ct).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var content = await logger.LogIfErrorResponse(response).ConfigureAwait(false);
                return QueryResultExtensions.Failed<T>(content);
            }

            var result = await response.ToResult<T>(operationName, serializerOptions, ct);

            return result;
        }

        public Task<QueryResult<T>> ExecuteMutation<T, TArg>(T value, TArg variables, string operationName,
            string? query = default, RequestOptions? options = default, CancellationToken ct = default)
        {
            query ??= $"mutation {QueryBuilder.Build(value, operationName, variables)}";

            return ExecuteQuery(value, variables, operationName, query, options, ct);
        }
    }
}