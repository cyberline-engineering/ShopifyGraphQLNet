using ShopifyGraphQLNet.Types.Product;
using ShopifyGraphQLNet.Types.Product.Arguments;
using ShopifyGraphQLNet.Types.Query;

namespace ShopifyGraphQLNet.StorefrontApi;

public interface IProductService: IShopifyService
{
    /// <summary>
    /// List of the shop’s products.
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="value"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<QueryResult<ProductConnection>> List(ProductListArguments arguments, ProductConnection? value = default, CancellationToken ct = default);

    /// <summary>
    /// Fetch a specific Product by one of its unique attributes.
    /// </summary>
    /// <param name="arguments"></param>
    /// <param name="value"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    Task<QueryResult<Product>> Get(ProductGetArguments arguments, Product? value = default, CancellationToken ct = default);
}