namespace ShopifyGraphQLNet.Types.Checkout;

/// <summary>
/// An object representing exchange of money for a product or service.
/// Requires unauthenticated_read_checkouts access scope.
/// </summary>
public class Transaction
{
    /// <summary>
    /// The amount of money that the transaction was for.
    /// </summary>
    public MoneyV2 AmountV2 { get; set; } = default!;
    /// <summary>
    /// The kind of the transaction.
    /// </summary>
    public TransactionKind Kind { get; set; }
    /// <summary>
    /// The status of the transaction.
    /// </summary>
    public TransactionStatus? StatusV2 { get; set; }
    /// <summary>
    /// Whether the transaction was done in test mode or not.
    /// </summary>
    public bool Test { get; set; }

    public static readonly Transaction Default = new()
        { AmountV2 = MoneyV2.Default, StatusV2 = TransactionStatus.SUCCESS };
}

/// <summary>
/// Transaction statuses describe the status of a transaction.
/// </summary>
public enum TransactionStatus
{
    /// <summary>
    /// There was an error while processing the transaction.
    /// </summary>
    ERROR,
    /// <summary>
    /// The transaction failed.
    /// </summary>
    FAILURE,
    /// <summary>
    /// The transaction is pending.
    /// </summary>
    PENDING,
    /// <summary>
    /// The transaction succeeded.
    /// </summary>
    SUCCESS
}

/// <summary>
/// The different kinds of order transactions.
/// </summary>
public enum TransactionKind
{
    /// <summary>
    /// An amount reserved against the cardholder's funding source. Money does not change hands until the authorization is captured.
    /// </summary>
    AUTHORIZATION,
    /// <summary>
    /// A transfer of the money that was reserved during the authorization stage.
    /// </summary>
    CAPTURE,
    /// <summary>
    /// Money returned to the customer when they have paid too much.
    /// </summary>
    CHANGE,
    /// <summary>
    /// An authorization for a payment taken with an EMV credit card reader.
    /// </summary>
    EMV_AUTHORIZATION,
    /// <summary>
    /// An authorization and capture performed together in a single step.
    /// </summary>
    SALE
}