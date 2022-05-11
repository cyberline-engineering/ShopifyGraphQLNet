namespace ShopifyGraphQLNet.Types;

/// <summary>
/// The code designating a country/region, which generally follows ISO 3166-1 alpha-2 guidelines.
/// If a territory doesn't have a country code value in the CountryCode enum, it might be considered a subdivision of another country.
/// For example, the territories associated with Spain are represented by the country code ES,
/// and the territories associated with the United States of America are represented by the country code US.
/// </summary>
public enum CountryCode
{
    /// <summary>
    /// United States.
    /// </summary>
    US
}