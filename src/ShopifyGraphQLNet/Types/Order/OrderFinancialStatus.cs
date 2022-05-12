namespace ShopifyGraphQLNet.Types.Order;

/// <summary>
/// Represents the order's current financial status.
/// </summary>
public enum OrderFinancialStatus
{
    /// <summary>
    /// Displayed as Authorized.
    /// </summary>
    AUTHORIZED,
    /// <summary>
    /// Displayed as Paid.
    /// </summary>
    PAID,
    /// <summary>
    /// Displayed as Partially paid.
    /// </summary>
    PARTIALLY_PAID,
    /// <summary>
    /// Displayed as Partially refunded.
    /// </summary>
    PARTIALLY_REFUNDED,
    /// <summary>
    /// Displayed as Pending.
    /// </summary>
    PENDING,
    /// <summary>
    /// Displayed as Refunded.
    /// </summary>
    REFUNDED,
    /// <summary>
    /// Displayed as Voided.
    /// </summary>
    VOIDED
}