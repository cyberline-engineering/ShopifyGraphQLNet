using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Represents a location where product inventory is held.
/// Requires unauthenticated_read_product_pickup_locations access scope.
/// </summary>
public class Location: INode
{
    /// <summary>
    /// The address of the location.
    /// </summary>
    public LocationAddress Address { get; set; } = default!;
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// The name of the location.
    /// </summary>
    public string Name { get; set; } = default!;
}

/// <summary>
/// Represents the address of a location.
/// </summary>
public class LocationAddress
{
    /// <summary>
    /// The first line of the address. Typically the street address or PO Box number.
    /// </summary>
    public string? Address1 { get; set; }
    /// <summary>
    /// The second line of the address. Typically the number of the apartment, suite, or unit.
    /// </summary>
    public string? Address2 { get; set; }
    /// <summary>
    /// The name of the city, district, village, or town.
    /// </summary>
    public string? City { get; set; }
    /// <summary>
    /// The name of the country.
    /// </summary>
    public string? Country { get; set; }
    /// <summary>
    /// The country code of the location.
    /// </summary>
    public string? CountryCode { get; set; }
    /// <summary>
    /// A formatted version of the address for the location.
    /// </summary>
    public string[] Formatted { get; set; } = default!;
    /// <summary>
    /// The latitude coordinates of the location.
    /// </summary>
    public double? Latitude { get; set; }
    /// <summary>
    /// The longitude coordinates of the location.
    /// </summary>
    public double? Longitude { get; set; }
    /// <summary>
    /// The phone number of the location.
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// The province of the location.
    /// </summary>
    public string? Province { get; set; }
    /// <summary>
    /// The code for the province, state, or district of the address of the location.
    /// </summary>
    public string? ProvinceCode { get; set; }
    /// <summary>
    /// The zip or postal code of the address.
    /// </summary>
    public string? Zip { get; set; }
}