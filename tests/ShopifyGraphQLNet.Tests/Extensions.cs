using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopifyGraphQLNet.Types;
using ShopifyGraphQLNet.Types.Query;
using Xunit;

namespace ShopifyGraphQLNet.Tests
{
    internal static class Extensions
    {
        public static void Assert<T>(this QueryResult<T> result)
        {
            Xunit.Assert.True(result,
                result.Errors?.Length > 0
                    ? String.Join(',', result.Errors.Select(x => x.Message))
                    : "Fail query result");
        }

        public static readonly MailingAddressInput TestAddress = new()
        {
            FirstName = "Matthew",
            LastName = "Fisher",
            Address1 = "1019 W 47th Pl",
            City = "Chicago",
            Province = "IL",
            Zip = "60609",
            Country = "US"
        };

        public static readonly MailingAddressInput TestAddress2 = new()
        {
            FirstName = "John",
            LastName = "Doe",
            Address1 = "136 Georgia Ave",
            City = "San Bruno",
            Province = "CA",
            Zip = "94066",
            Phone = "4086179562",
            Country = "USA"
        };
    }
}
