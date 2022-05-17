using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopifyGraphQLNet.Helper
{
    internal static class TypeHelper
    {
        public static readonly Uri DefaultUrl = new ("https://shopify.com");
        public static readonly object? EmptyArgs = default;

        public static bool IsNullable<T>(T t) { return false; }
        public static bool IsNullable<T>(T? t) where T : struct { return true; }

        public static Type GetUnderlyingType(this Type type)
        {
            return Nullable.GetUnderlyingType(type) ?? type;
        }
    }
}
