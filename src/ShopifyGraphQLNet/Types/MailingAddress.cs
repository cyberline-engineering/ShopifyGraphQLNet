using ShopifyGraphQLNet.Types.Interface;

namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Represents a mailing address for customers and shipping.
/// </summary>
public class MailingAddress: INode
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
    /// The name of the customer's company or organization.
    /// </summary>
    public string? Company { get; set; }
    /// <summary>
    /// The name of the country.
    /// </summary>
    public string? Country { get; set; }
    /// <summary>
    /// The two-letter code for the country of the address.
    /// For example, US.
    /// </summary>
    public CountryCode? CountryCodeV2 { get; set; }
    /// <summary>
    /// The first name of the customer.
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// A formatted version of the address, customized by the provided arguments.
    /// </summary>
    public MailingAddressFormatted Formatted { get; set; } = default!;
    /// <summary>
    /// A comma-separated list of the values for city, province, and country.
    /// </summary>
    public string? FormattedArea { get; set; }
    /// <inheritdoc />
    public string Id { get; set; } = default!;
    /// <summary>
    /// The last name of the customer.
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// The latitude coordinate of the customer address.
    /// </summary>
    public double? Latitude { get; set; }
    /// <summary>
    /// The longitude coordinate of the customer address.
    /// </summary>
    public double? Longitude { get; set; }
    /// <summary>
    /// The full name of the customer, based on firstName and lastName.
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// A unique phone number for the customer.
    /// Formatted using E.164 standard. For example, +16135551111.
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// The region of the address, such as the province, state, or district.
    /// </summary>
    public string? Province { get; set; }
    /// <summary>
    /// The two-letter code for the region.
    /// For example, ON.
    /// </summary>
    public string? ProvinceCode { get; set; }
    /// <summary>
    /// The zip or postal code of the address.
    /// </summary>
    public string? Zip { get; set; }

    public static readonly MailingAddress Default = new()
    {
        Name = String.Empty,
        Address1 = String.Empty,
        Address2 = String.Empty,
        City = String.Empty,
        Country = String.Empty,
        CountryCodeV2 = CountryCode.US,
        Id = String.Empty,
        ProvinceCode = String.Empty,
        Zip = String.Empty,
        FirstName = String.Empty,
        LastName = String.Empty,
        FormattedArea = String.Empty,
        Phone = String.Empty,
        Province = String.Empty,
        Company = String.Empty,
        Latitude = 0.0,
        Longitude = 0.0,
        //Formatted = MailingAddressFormatted.Default
    };
}

public class MailingAddressFormatted : List<string>
{
    /// <summary>
    /// A formatted version of the address, customized by the provided arguments.
    /// </summary>
    internal dynamic? _arguments { get; set; } = new { withName = true, withCompany = true };

    public static readonly MailingAddressFormatted Default = new();
}