using System.Text;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi;

public abstract class ServiceBase: IShopifyService
{
    protected ShopifyGraphQLNetClient client;
    protected ILogger logger;

    public ShopifyGraphQLNetClient Client => client;

    protected ServiceBase(ShopifyGraphQLNetClient client, ILogger logger)
    {
        this.client = client;
        this.logger = logger;
    }

    /// <inheritdoc />
    public Task<QueryResult<T>> GetNode<T>(string id, T value, string? fragment = default,
        RequestOptions? options = default, CancellationToken ct = default)
    {
        logger.LogTrace("GetNode<T>: {type}", typeof(T));

        var sb = new StringBuilder();
        var level = 0;
        var queryOptions = QueryBuildOptions.Default;

        sb.AppendValue("query getNode($id: ID!) {", queryOptions.PrettyPrint, level++);
        sb.AppendValue("node(id: $id)", queryOptions.PrettyPrint, level++);
        sb.AppendValue($"{{... on {fragment ?? typeof(T).Name} {{", queryOptions.PrettyPrint, level++);
        QueryBuilder.BuildType(value, queryOptions, sb, ref level);
        sb.AppendValue("}", queryOptions.PrettyPrint, --level);
        sb.AppendValue("}", queryOptions.PrettyPrint, --level);
        sb.AppendValue("}", queryOptions.PrettyPrint, --level);

        var query = sb.ToString();

        logger.LogTrace("Query: {query}", query);

        return client.ExecuteQuery(value, new { id }, "getNode", query, options: options, ct: ct);
    }

    /// <inheritdoc />
    public Task<QueryResult<T[]>> GetNodes<T>(string[] ids, T value, string? fragment = default,
        RequestOptions? options = default, CancellationToken ct = default)
    {
        logger.LogTrace("GetNodes<T>: {type}", typeof(T));

        var sb = new StringBuilder();
        var level = 0;
        var queryOptions = QueryBuildOptions.Default;

        sb.AppendValue("query getNodes($ids: [ID!]!) {", queryOptions.PrettyPrint, level++);
        sb.AppendValue("nodes(ids: $ids)", queryOptions.PrettyPrint, level++);
        sb.AppendValue($"{{... on {fragment ?? typeof(T).Name} {{", queryOptions.PrettyPrint, level++);
        QueryBuilder.BuildType(value, queryOptions, sb, ref level);
        sb.AppendValue("}", queryOptions.PrettyPrint, --level);
        sb.AppendValue("}", queryOptions.PrettyPrint, --level);
        sb.AppendValue("}", queryOptions.PrettyPrint, --level);

        var query = sb.ToString();

        logger.LogTrace("Query: {query}", query);

        return client.ExecuteQuery(new[] { value }, new { ids }, "getNodes", query, options: options, ct: ct);
    }
}