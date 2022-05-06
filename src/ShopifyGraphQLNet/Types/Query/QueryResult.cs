using System;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace ShopifyGraphQLNet.Types.Query
{
    public class QueryResult<T>
    {
        public bool Result { get; set; }
        public int StatusCode { get; set; }
        public T? Payload { get; set; }

        /// <summary>
        /// A list of all errors returned.
        /// </summary>
        public Error[]? Errors { get; set; }

        public static implicit operator T?(QueryResult<T> source)
        {
            return source.Payload;
        }

        public static implicit operator bool(QueryResult<T> source)
        {
            return source.Result;
        }
    }

    internal static class QueryResultExtensions
    {

        public static async Task<QueryResult<T>> ToResult<T>(this HttpResponseMessage response, string root,
            JsonSerializerOptions serializerOptions, CancellationToken ct = default)
        {
            try
            {
                var data = await response.Content.ReadFromJsonAsync<QueryResponse>(serializerOptions, ct)
                    .ConfigureAwait(false);

                if (data == default) return Failed<T>("Response return empty result");

                if (data.Data == default)
                    return new QueryResult<T>()
                        { Result = false, Errors = data.Errors, StatusCode = (int)response.StatusCode };

                var result = data.Data[root].Deserialize<T>(serializerOptions);
                return new QueryResult<T>()
                {
                    Result = !(data.Errors?.Length > 0), Payload = result, Errors = data.Errors,
                    StatusCode = (int)response.StatusCode
                };
            }
            catch (Exception ex)
            {
                return Failed<T>(ex);
            }
        }

        public static QueryResult<T> Failed<T>(string message)
        {
            return new QueryResult<T>()
            {
                Result = false, Errors = new[] { new Error() { Message = message } },
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }

        public static QueryResult<T> Failed<T>(Exception ex)
        {
            return new QueryResult<T>()
            {
                Result = false, Errors = new[] { new Error() { Message = ex.ToString() } },
                StatusCode = (int)HttpStatusCode.InternalServerError
            };
        }
    }
}
