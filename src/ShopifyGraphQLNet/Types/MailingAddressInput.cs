namespace ShopifyGraphQLNet.Types;

/// <summary>
/// Specifies the fields accepted to create or update a mailing address.
/// </summary>
public class MailingAddressInput
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
    /// The first name of the customer.
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// The last name of the customer.
    /// </summary>
    public string? LastName { get; set; }
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
    /// The zip or postal code of the address.
    /// </summary>
    public string? Zip { get; set; }
}