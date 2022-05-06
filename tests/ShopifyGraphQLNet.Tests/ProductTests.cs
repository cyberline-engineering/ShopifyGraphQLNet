using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.StorefrontApi;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Product;
using ShopifyGraphQLNet.Types.Product.Arguments;
using Xunit;

namespace ShopifyGraphQLNet.Tests
{
    public class ProductTests
    {
        private readonly IProductService productService;

        public ProductTests()
        {
            var host = Host
                .CreateDefaultBuilder()
                .UseEnvironment(Environments.Development)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddUserSecrets(Assembly.GetExecutingAssembly(), true);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddShopifyGraphQLNetClient(context.Configuration);
                })
                .ConfigureLogging(builder =>
                {
                    builder.AddDebug();
                    builder.SetMinimumLevel(LogLevel.Trace);
                })
                .Build();

            productService = host.Services.GetRequiredService<IProductService>();
        }

        [Fact]
        public void ProductQueryBuilderTest()
        {
            var query = QueryBuilder.Build(new { edges = Array.Empty<Edge<Product>>(), _arguments = new {first = 10} },
                "products", default, new QueryBuildOptions() {PrettyPrint = true});

            Assert.NotNull(query);
        }

        [Fact]
        public void ProductConnectionQueryBuilderTest()
        {
            var query = QueryBuilder.Build(new ProductConnection(), "products", default,
                new QueryBuildOptions() { PrettyPrint = true });

            Assert.NotNull(query);
        }

        [Fact]
        public async Task ListProductsTest()
        {
            var res = await productService.List(new ProductListArguments() { First = 5 });
            
            res.Assert();
        }

        [Theory]
        [InlineData("gid://shopify/Product/7712881869037")]
        [InlineData(null, "test-product")]
        public async Task GetProductTest(string? id = default, string? handle = default)
        {
            var res = await productService.Get(new ProductGetArguments() { Id = id, Handle = handle});
            
            res.Assert();
        }
    }
}