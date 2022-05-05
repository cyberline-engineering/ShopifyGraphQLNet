using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace ShopifyGraphQLNet.Helper
{
    internal static class LogHelper
    {
        public static async Task<string> LogIfErrorResponse(this ILogger logger, HttpResponseMessage message,
            [CallerMemberName] string memberName = "",
            [CallerFilePath] string sourceFilePath = "",
            [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (message.IsSuccessStatusCode) return String.Empty;

            logger.Log(message.IsErrorStatusCode() ? LogLevel.Error : LogLevel.Debug,
                $"Fail request at {sourceFilePath} method {memberName} line {sourceLineNumber}. Url {message.RequestMessage?.RequestUri}. Status: {message.StatusCode}. Reason: {message.ReasonPhrase}");

            var content = await message.Content.ReadAsStringAsync().ConfigureAwait(false);
            logger.LogTrace("Content: {content}", content);

            return content;
        }
    }
}
