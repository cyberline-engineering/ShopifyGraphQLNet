using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ShopifyGraphQLNet
{
    public static class Extensions
    {
        public static IServiceCollection AddShopifyGraphQLNetClient(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddHttpClient<ShopifyGraphQLNetClient>();

            return services;
        }
    }
}
