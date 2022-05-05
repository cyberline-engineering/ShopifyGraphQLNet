using ShopifyGraphQLNet.Types;

namespace ShopifyGraphQLNet.StorefrontApi;

public interface IProductService
{
    Task<ProductConnection?> ListProducts(ProductConnectionArguments arguments, CancellationToken ct = default);
}