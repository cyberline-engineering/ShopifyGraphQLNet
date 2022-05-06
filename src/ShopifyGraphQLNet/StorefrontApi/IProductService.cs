using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Product;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi;

public interface IProductService
{
    Task<QueryResult<ProductConnection>> List(ProductListArguments arguments,
        CancellationToken ct = default);

    /// <summary>
    /// Fetch a specific Product by one of its unique attributes.
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<QueryResult<Product>> Get(ProductGetArguments arguments, CancellationToken ct = default);
}