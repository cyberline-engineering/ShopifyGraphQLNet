using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        public static IEnumerable<object[]> TestIdData()
        {
            yield return new object[] { "gid://shopify/Product/7712881869037", "test-product" };
        }

        public static IEnumerable<object[]> TestIdsData()
        {
            yield return new object[] { new[] { "gid://shopify/Product/7712881869037" } };
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
            var query = QueryBuilder.Build(new ProductConnection(), "products", default, new QueryBuildOptions() { PrettyPrint = true });

            Assert.NotNull(query);
        }

        [Fact]
        public async Task ListProductsTest()
        {
            var res = await productService.List(new ProductListArguments() { First = 5 });
            
            res.Assert();
        }

        [Theory]
        [MemberData(nameof(TestIdData))]
        public async Task GetProductTest(string id, string handle)
        {
            var arguments = Random.Shared.NextSingle() < 0.5f
                ? new ProductGetArguments{ Id = id }
                : new ProductGetArguments{ Handle = handle };

            var res = await productService.Get(arguments);
            
            res.Assert();
        }

        [Theory]
        [MemberData(nameof(TestIdData))]
        public async Task GetNodeTest(string id, string _)
        {
            var res = await productService.GetNode(id, Product.Default);
            
            res.Assert();
        }

        [Theory]
        [MemberData(nameof(TestIdData))]
        public async Task GetPartialNodeTest(string id, string _)
        {
            var res = await productService.GetNode(id,
                new { id = String.Empty, title = String.Empty, images = ImageConnection.Default }, "Product");
            
            res.Assert();
        }

        [Theory]
        [MemberData(nameof(TestIdData))]
        public async Task GetPartialNode2Test(string id, string _)
        {
            var res = await productService.GetNode(id,
                new
                {
                    id = String.Empty, title = String.Empty,
                    images = new { nodes = new[] { Image.Default }, _arguments = new { first = 2 } }
                }, "Product");

            res.Assert();
        }

        [Theory]
        [MemberData(nameof(TestIdsData))]
        public async Task GetNodesTest(string[] ids)
        {
            var res = await productService.GetNodes(ids, Product.Default);
            
            res.Assert();
        }
    }
}