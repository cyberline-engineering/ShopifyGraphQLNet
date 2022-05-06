using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Types.Product.Arguments
{
    public class ProductGetArguments
    {
        /// <summary>
        /// The handle of the <seealso cref="Product"/>
        /// </summary>
        public string? Handle { get; set; }

        /// <summary>
        /// The handle of the <seealso cref="Product"/>
        /// </summary>
        [IdGraphType]
        public string? Id { get; set; }
    }
}
