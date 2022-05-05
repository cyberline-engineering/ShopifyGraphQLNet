using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ShopifyGraphQLNet.Helper;
using ShopifyGraphQLNet.StorefrontApi;
using ShopifyGraphQLNet.Types;
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
            var query = QueryBuilder.Build(new { pageInfo = new { StartCursor = "" }, nodes = new { id = 0 }, },
                "products", new {first = 10}, new QueryBuildOptions() {PrettyPrint = true});

            Assert.NotNull(query);
        }

        [Fact]
        public void ProductConnectionQueryBuilderTest()
        {
            var query = QueryBuilder.Build(ProductConnection.Default,
                "products", new {first = 10}, new QueryBuildOptions() {PrettyPrint = true});

            Assert.NotNull(query);
        }

        [Fact]
        public async Task GetProductsTest()
        {
            var res = await productService.ListProducts(new ProductConnectionArguments() { First = 5 });
            
            res.Assert();
        }
    }
}