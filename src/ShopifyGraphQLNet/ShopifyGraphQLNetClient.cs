using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;

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

        public async Task<TOut?> ExecuteQuery<TOut>(string query, object? variables = default, CancellationToken ct = default)
        {
            using var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                Content = JsonContent.Create(new { query, variables }, new MediaTypeHeaderValue("application/graphql"),
                    serializerOptions)
            };

            using var response = await client.SendAsync(request, ct).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                return default;
            }

            var data = await response.Content.ReadFromJsonAsync<TOut>(serializerOptions, ct).ConfigureAwait(false);

            return data;
        }
    }
}