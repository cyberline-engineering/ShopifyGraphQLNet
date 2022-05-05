using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi;

public interface IProductService
{
    Task<QueryResult<ProductConnection>> ListProducts(ProductConnectionArguments arguments,
        CancellationToken ct = default);
}