namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// Credit card information used for a payment.
/// Requires unauthenticated_read_checkouts access scope.
/// </summary>
public class CreditCard
{
    /// <summary>
    /// The brand of the credit card.
    /// </summary>
    public string? Brand { get; set; }
    /// <summary>
    /// The expiry month of the credit card.
    /// </summary>
    public int? ExpiryMonth { get; set; }
    /// <summary>
    /// The expiry year of the credit card.
    /// </summary>
    public int? ExpiryYear { get; set; }
    /// <summary>
    /// The credit card's BIN number.
    /// </summary>
    public string? FirstDigits { get; set; }
    /// <summary>
    /// The first name of the card holder.
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// The last 4 digits of the credit card.
    /// </summary>
    public string? LastDigits { get; set; }
    /// <summary>
    /// The last name of the card holder.
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// The masked credit card number with only the last 4 digits displayed.
    /// </summary>
    public string? MaskedNumber { get; set; }

    public static readonly CreditCard Default = new()
    {
        Brand = String.Empty, FirstName = String.Empty, ExpiryMonth = 1, ExpiryYear = 28, FirstDigits = String.Empty,
        LastDigits = String.Empty, LastName = String.Empty, MaskedNumber = String.Empty
    };
}