using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyGraphQLNet.Types.Product
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
        public string? Id { get; set; }
    }
}
