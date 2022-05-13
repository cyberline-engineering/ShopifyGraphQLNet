namespace ShopifyGraphQLNet.Types.Order;

public class SuccessfulFulfillments : List<SuccessfulFulfillment>
{
    /// <summary>
    /// Truncate the array result to this size.
    /// </summary>
    internal dynamic _arguments = new { first = 10 };
}

/// <summary>
/// Represents a single fulfillment in an order.
/// Requires unauthenticated_read_customers access scope.
/// </summary>
public class SuccessfulFulfillment
{
    /// <summary>
    /// The name of the tracking company.
    /// </summary>
    public string? TrackingCompany { get; set; }

    /// <summary>
    /// Tracking information associated with the fulfillment, such as the tracking number and tracking URL.
    /// </summary>
    public FulfillmentTrackingInfos TrackingInfo { get; set; } = default!;
}

public class FulfillmentTrackingInfos: List<FulfillmentTrackingInfo>
{
    /// <summary>
    /// Truncate the array result to this size.
    /// </summary>
    internal dynamic _arguments = new { first = 10 };
}

/// <summary>
/// Tracking information associated with the fulfillment.
/// Requires unauthenticated_read_customers access scope.
/// </summary>
public class FulfillmentTrackingInfo
{
    /// <summary>
    /// The tracking number of the fulfillment.
    /// </summary>
    public string? Number { get; set; }
    /// <summary>
    /// The URL to track the fulfillment.
    /// </summary>
    public Uri? Url { get; set; }
}