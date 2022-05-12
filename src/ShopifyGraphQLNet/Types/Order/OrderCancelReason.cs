namespace ShopifyGraphQLNet.Types.Order;

/// <summary>
/// Represents the reason for the order's cancellation.
/// </summary>
public enum OrderCancelReason
{
    /// <summary>
    /// The customer wanted to cancel the order.
    /// </summary>
    CUSTOMER,
    /// <summary>
    /// Payment was declined.
    /// </summary>
    DECLINED,
    /// <summary>
    /// The order was fraudulent.
    /// </summary>
    FRAUD,
    /// <summary>
    /// There was insufficient inventory.
    /// </summary>
    INVENTORY,
    /// <summary>
    /// The order was canceled for an unlisted reason.
    /// </summary>
    OTHER,
}