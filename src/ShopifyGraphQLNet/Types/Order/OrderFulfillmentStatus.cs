namespace ShopifyGraphQLNet.Types.Order;

/// <summary>
/// Represents the order's aggregated fulfillment status for display purposes.
/// </summary>
public enum OrderFulfillmentStatus
{
    /// <summary>
    /// Displayed as Fulfilled. All of the items in the order have been fulfilled.
    /// </summary>
    FULFILLED,
    /// <summary>
    /// Displayed as In progress. Some of the items in the order have been fulfilled, or a request for fulfillment has been sent to the fulfillment service.
    /// </summary>
    IN_PROGRESS,
    /// <summary>
    /// Displayed as On hold. All of the unfulfilled items in this order are on hold.
    /// </summary>
    ON_HOLD,
    /// <summary>
    /// Displayed as Open. None of the items in the order have been fulfilled. Replaced by "UNFULFILLED" status.
    /// </summary>
    OPEN,
    /// <summary>
    /// Displayed as Partially fulfilled. Some of the items in the order have been fulfilled.
    /// </summary>
    PARTIALLY_FULFILLED,
    /// <summary>
    /// Displayed as Pending fulfillment. A request for fulfillment of some items awaits a response from the fulfillment service. Replaced by "IN_PROGRESS" status.
    /// </summary>
    PENDING_FULFILLMENT,
    /// <summary>
    /// Displayed as Restocked. All of the items in the order have been restocked. Replaced by "UNFULFILLED" status.
    /// </summary>
    RESTOCKED,
    /// <summary>
    /// Displayed as Scheduled. All of the unfulfilled items in this order are scheduled for fulfillment at later time.
    /// </summary>
    SCHEDULED,
    /// <summary>
    /// Displayed as Unfulfilled. None of the items in the order have been fulfilled.
    /// </summary>
    UNFULFILLED
}