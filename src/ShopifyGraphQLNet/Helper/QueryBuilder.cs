using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ShopifyGraphQLNet.Types.Attribute;

namespace ShopifyGraphQLNet.Helper
{
    public static class QueryBuilder
    {
        private const string ArgumentsPropertyName = "_arguments";

        public static string Build<T>(T value, string? operationName, object? arguments, QueryBuildOptions? options = default)
        {
            if (value == null)
            {
                throw new ArgumentException("value don't be null", nameof(value));
            }

            options ??= QueryBuildOptions.Default;
            var builder = new StringBuilder();
            var level = 0;

            arguments ??= GetArguments(value);
            var argumentValues = GetArgumentValues(arguments, options).ToArray();

            var root = operationName;
            if (argumentValues.Length > 0)
            {
                if (!String.IsNullOrWhiteSpace(operationName))
                {
                    var argValues = String.Join(", ", argumentValues.Select(x => $"{x.name}: ${x.name}"));
                    var argTypes = String.Join(", ", argumentValues.Select(x => $"${x.name}: {x.type}"));

                    root = $"{operationName}({argValues})";
                    operationName = $"{operationName}({argTypes})";
                }
                else
                {
                    var argValues = String.Join(", ", argumentValues.Select(x => $"{x.name}: {x.value}"));
                    root = $"{operationName}({argValues})";
                }
            }

            AppendValue(builder, $"{operationName} {{", options.PrettyPrint, level++);
            AppendValue(builder, $"{root} {{", options.PrettyPrint, level++);

            BuildType(value, value.GetType(), options, builder, ref level);

            AppendValue(builder, "}", options.PrettyPrint, --level);
            AppendValue(builder, "}", options.PrettyPrint, --level);

            return builder.ToString();
        }

        private static IEnumerable<(string name, string type, string value)> GetArgumentValues(object? arguments,
            QueryBuildOptions options)
        {
            if (arguments == null) return Enumerable.Empty<(string name, string type, string value)>();

            var argProperties = arguments.GetType().GetProperties()
                .Where(property => !property.Name.Equals(ArgumentsPropertyName) && property.GetValue(arguments) != null);
            var argItems = argProperties
                .Select(x => (name: GetPropertyName(x, options), type: GetPropertyGraphType(x),
                    value: FormatQueryParam(x.GetValue(arguments), options)));

            return argItems;
        }

        private static void BuildType(object? value, Type type, QueryBuildOptions options, StringBuilder builder, ref int level)
        {
            var properties = type.GetProperties()
                .Where(x => !x.Name.Equals(ArgumentsPropertyName) && (value == default || x.GetValue(value) != null))
#if DEBUG
                .ToArray()
#endif
                ;

            foreach (var property in properties)
            {
                var propertyName = GetPropertyName(property, options);
                var propertyType = property.PropertyType;

                if ((propertyType.FullName?.StartsWith("System.", StringComparison.Ordinal) ?? false) ||
                    propertyType.IsEnum)
                {
                    AppendValue(builder, propertyName, options.PrettyPrint, level);
                    continue;
                }

                var propertyValue = value != default
                    ? property.GetValue(value)!
                    : default;

                var pt = propertyType;
                var pv = propertyValue;

                if (propertyType.IsArray)
                {
                    pt = propertyType.GetElementType()!;
                }

                if (value != null)
                {
                    if (propertyType.IsArray)
                    {
                        var array = (Array)property.GetValue(value)!;
                        pv = array.Length == 0 ? null : array.GetValue(0);
                    }
                    else if (typeof(IEnumerable).IsAssignableFrom(propertyType))
                    {
                        var enumerable = (IEnumerable<object>)property.GetValue(value)!;
                        pv = enumerable.FirstOrDefault();
                    }
                }

                var arguments = GetArgumentValues(GetArguments(propertyValue), options).ToArray();

                if (arguments.Length > 0)
                {
                    var argValues = String.Join(", ", arguments.Select(x => $"{x.name}: {x.value}"));
                    propertyName = $"{propertyName}({argValues})";
                }

                AppendValue(builder, $"{propertyName} {{", options.PrettyPrint, level++);
                BuildType(pv, pt, options, builder, ref level);
                level--;
                AppendValue(builder, "}", options.PrettyPrint, level);
            }
        }

        private static string GetPropertyName(this PropertyInfo property, QueryBuildOptions options)
        {
            return property.GetCustomAttribute<JsonPropertyNameAttribute>()?.Name ??
                   options.NamingPolicy.ConvertName(property.Name);
        }

        internal static object? GetArguments(object? value)
        {
            var argumentsProperty = value?.GetType()
                .GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .FirstOrDefault(x => x.Name.Equals(ArgumentsPropertyName));

            return argumentsProperty?.GetValue(value);
        }

        private static string GetPropertyGraphType(this PropertyInfo property)
        {
            var notNull = property.GetCustomAttribute<RequiredAttribute>() != default;
            var propertyType = property.PropertyType;
            string typeName;

            if (property.GetCustomAttribute<IdGraphType>() != default)
            {
                typeName = "ID";
            }
            else if (propertyType.IsArray)
            {
                var type = propertyType.GetElementType() ?? propertyType;

                typeName = $"[{type.Name}!]";
            }
            else
            {
                var type = propertyType.GetUnderlyingType();

                typeName = type.Name switch
                {
                    nameof(Int16) => "Int",
                    nameof(Int32) => "Int",
                    nameof(Int64) => "Int",

                    nameof(Single) => "Float",
                    nameof(Double) => "Float",

                    nameof(DateTimeOffset) => "DateTime",

                    _ => type.Name
                };
            }

            return notNull ? $"{typeName}!" : typeName;
        }

        private static void AppendValue(this StringBuilder builder, string value, bool prettyPrint, int level)
        {
            if (prettyPrint)
                builder.AppendLine(value.PadLeft(value.Length + level * 2, ' '));
            else
                builder.Append($"{value} ");
        }

        private static string FormatQueryParam(object? value, QueryBuildOptions options)
        {
            switch (value)
            {
                case string strValue:
                    var encoded = strValue.Replace("\"", "\\\"");
                    return $"\"{encoded}\"";

                case char charValue:
                    return $"\"{charValue}\"";

                case byte byteValue:
                    return byteValue.ToString();

                case sbyte sbyteValue:
                    return sbyteValue.ToString();

                case short shortValue:
                    return shortValue.ToString();

                case ushort ushortValue:
                    return ushortValue.ToString();

                case int intValue:
                    return intValue.ToString();

                case uint uintValue:
                    return uintValue.ToString();

                case long longValue:
                    return longValue.ToString();

                case ulong ulongValue:
                    return ulongValue.ToString();

                case float floatValue:
                    return floatValue.ToString(CultureInfo.InvariantCulture);

                case double doubleValue:
                    return doubleValue.ToString(CultureInfo.InvariantCulture);

                case decimal decimalValue:
                    return decimalValue.ToString(CultureInfo.InvariantCulture);

                case bool booleanValue:
                    return booleanValue ? "true" : "false";

                case Enum enumValue:
                    return enumValue.ToString();

                case DateTime dateTimeValue:
                    return FormatQueryParam(dateTimeValue.ToString("o"), options);

                case KeyValuePair<string, object> kvValue:
                    return $"{kvValue.Key}:{FormatQueryParam(kvValue.Value, options)}";

                case IDictionary<string, object> dictValue:
                    return $"{{{string.Join(",", dictValue.Select(e => FormatQueryParam(e, options)))}}}";

                case IEnumerable enumerableValue:
                    return
                        $"[{string.Join(",", enumerableValue.OfType<object>().Select(x => FormatQueryParam(x, options)))}]";

                case { } objectValue:
                    var dictionary = ObjectToDictionary(objectValue, options);
                    return FormatQueryParam(dictionary, options);

                default:
                    throw new InvalidDataException($"Invalid Object Type in Param List: {value?.GetType()}");
            }
        }

        internal static Dictionary<string, object?> ObjectToDictionary(object @object, QueryBuildOptions options) =>
            @object
                .GetType()
                .GetProperties()
                .Where(property => property.GetValue(@object) != null)
                .Select(property =>
                    new KeyValuePair<string, object?>(
                        GetPropertyName(property, options), property.GetValue(@object)))
                .OrderBy(property => property.Key)
                .ToDictionary(property => property.Key, property => property.Value);
    }

    public class QueryBuildOptions
    {
        public JsonNamingPolicy NamingPolicy { get; set; } = JsonNamingPolicy.CamelCase;
        public bool PrettyPrint { get; set; }

        public static readonly QueryBuildOptions Default = new();
    }
}
