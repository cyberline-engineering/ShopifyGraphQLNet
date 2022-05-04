using System.Threading.Tasks;
using GraphQL.Query.Builder;
using GraphQL.Query.Builder.Formatter.SystemTextJson;
using ShopifyGraphQLNet.Types;
using Xunit;

namespace ShopifyGraphQLNet.Tests
{
    public class ProductTests
    {
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
    }
}