using System.Threading.Tasks;
using GraphQL.Query.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
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
        public void ProductSchemaTest()
        {
            QueryOptions options = new()
            {
                Formatter = CamelCasePropertyNameFormatter.Format,
            };

            var query = new Query<ProductConnection>("products", options) // set the name of the query// add query argumentsadd firstName field
                .AddArguments(new {first = "$first"})
                .AddField(h => h.PageInfo, sq => sq.AddField(p => p.StartCursor)) // add lastName field
                .AddField( // add a sub-object field
                    h => h.Edges, // set the name of the field
                    sq => sq /// build the sub-query
                        .AddField(p => p.Node, x => x
                            .AddField(v => v.Handle)
                            .AddField(v => v.Id)
                            .AddField(v => v.Description)
                        )
                        .AddField(p => p.Cursor)
                );

            var data = query.Build();

            Assert.NotNull(data);
        }

        [Fact]
        public void ProductQueryBuilderTest()
        {
            var query = QueryBuilder.Build(new { pageInfo = new { StartCursor = "" }, nodes = new { id = 0 }, },
                "products", new {first = 10}, new QueryBuildOptions() {PrettyPrint = true});

            Assert.NotNull(query);
        }

        [Fact]
        public async Task GetProductsTest()
        {
            var res = await productService.ListProducts(new ProductConnectionArguments() { First = 5 });
            
            Assert.NotNull(res);
        }
    }
}