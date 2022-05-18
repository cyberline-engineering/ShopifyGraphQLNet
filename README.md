
# ShopifyGraphQLNet: .NET client for SHopify GraphQL API.

https://shopify.dev/api/storefront

# Installation

ShopifyGraphQLNet is [available on NuGet](https://www.nuget.org/packages/ShopifyGraphQLNet/). Use the package manager
console in Visual Studio to install it:

```pwsh
Install-Package ShopifyGraphQLNet
```

If you're using .NET Core, you can use the `dotnet` command from your favorite shell:

```sh
dotnet add package ShopifyGraphQLNet
```

# Using ShopifyGraphQLNet

The `AddShopifyGraphQLNetClient` extension method is used to register services in the DI container.

Example for console app or tests:
```
var host = Host
      .CreateDefaultBuilder()
      .UseEnvironment(Environments.Development)
      .ConfigureServices((context, services) =>
      {
          services.AddShopifyGraphQLNetClient(context.Configuration);
      })
      .Build();

  productService = host.Services.GetRequiredService<IProductService>();
```

# Required settings

`ShopifyGraphQLNet` using `IOptions<ShopifyGraphQLNetClientConfig>` for Store name and API Access Token. 
By default, these parameters should be specified in `appsettings.json` file.

```json
{
  "ShopifyGraphQLNetClientConfig": {
    "StoreName": "",
    "StorefrontApiAccessToken": "",
    "AdminApiAccessToken": "",
    "ApiVersion": { "Value": "2022-04" }
  } 
}
```
