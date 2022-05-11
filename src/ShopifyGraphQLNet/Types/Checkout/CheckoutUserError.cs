namespace ShopifyGraphQLNet.Types.Checkout;

public class CheckoutUserError
{
    /// <summary>
    /// The error code.
    /// </summary>
    public CheckoutErrorCode? Code { get; set; }
    /// <summary>
    /// The path to the input field that caused the error.
    /// </summary>
    public string[]? Field { get; set; }
    /// <summary>
    /// The error message.
    /// </summary>
    public string Message { get; set; } = default!;
}

/// <summary>
/// Possible error codes that can be returned by <see cref="CheckoutUserError">CheckoutUserError</see>.
/// </summary>
public enum CheckoutErrorCode
{
    /// <summary>
    /// Checkout is already completed.
    /// </summary>
    ALREADY_COMPLETED,
    /// <summary>
    /// Input email contains an invalid domain name.
    /// </summary>
    BAD_DOMAIN,
    /// <summary>
    /// The input value is blank.
    /// </summary>
    BLANK,
    /// <summary>
    /// Cart does not meet discount requirements notice.
    /// </summary>
    CART_DOES_NOT_MEET_DISCOUNT_REQUIREMENTS_NOTICE,
    /// <summary>
    /// Customer already used once per customer discount notice.
    /// </summary>
    CUSTOMER_ALREADY_USED_ONCE_PER_CUSTOMER_DISCOUNT_NOTICE,
    /// <summary>
    /// Discount already applied.
    /// </summary>
    DISCOUNT_ALREADY_APPLIED,
    /// <summary>
    /// Discount disabled.
    /// </summary>
    DISCOUNT_DISABLED,
    /// <summary>
    ///     Discount expired.
    /// </summary>
    DISCOUNT_EXPIRED,
    /// <summary>
    /// Discount limit reached.
    /// </summary>
    DISCOUNT_LIMIT_REACHED,
    /// <summary>
    /// Discount not found.
    /// </summary>
    DISCOUNT_NOT_FOUND,
    /// <summary>
    /// Checkout is already completed.
    /// </summary>
    EMPTY,
    /// <summary>
    ///  Queue token has expired.
    /// </summary>
    EXPIRED_QUEUE_TOKEN,
    /// <summary>
    /// Gift card has already been applied.
    /// </summary>
    GIFT_CARD_ALREADY_APPLIED,
    /// <summary>
    /// Gift card code is invalid.
    /// </summary>
    GIFT_CARD_CODE_INVALID,
    /// <summary>
    /// Gift card currency does not match checkout currency.
    /// </summary>
    GIFT_CARD_CURRENCY_MISMATCH,
    /// <summary>
    /// Gift card has no funds left.
    /// </summary>
    GIFT_CARD_DEPLETED,
    /// <summary>
    /// Gift card is disabled.
    /// </summary>
    GIFT_CARD_DISABLED,
    /// <summary>
    /// Gift card is expired.
    /// </summary>
    GIFT_CARD_EXPIRED,
    /// <summary>
    /// Gift card was not found.
    /// </summary>
    GIFT_CARD_NOT_FOUND,
    /// <summary>
    /// Gift card cannot be applied to a checkout that contains a gift card.
    /// </summary>
    GIFT_CARD_UNUSABLE,
    /// <summary>
    /// The input value should be greater than or equal to the minimum value allowed.
    /// </summary>
    GREATER_THAN_OR_EQUAL_TO,
    /// <summary>
    /// The input value is invalid.
    /// </summary>
    INVALID,
    /// <summary>
    /// Cannot specify country and presentment currency code.
    /// </summary>
    INVALID_COUNTRY_AND_CURRENCY,
    /// <summary>
    /// Input Zip is invalid for country provided.
    /// </summary>
    INVALID_FOR_COUNTRY,
    /// <summary>
    /// Input Zip is invalid for country and province provided.
    /// </summary>
    INVALID_FOR_COUNTRY_AND_PROVINCE,
    /// <summary>
    /// Invalid province in country.
    /// </summary>
    INVALID_PROVINCE_IN_COUNTRY,
    /// <summary>
    /// Queue token is invalid.
    /// </summary>
    INVALID_QUEUE_TOKEN,
    /// <summary>
    /// Invalid region in country.
    /// </summary>
    INVALID_REGION_IN_COUNTRY,
    /// <summary>
    /// Invalid state in country.
    /// </summary>
    INVALID_STATE_IN_COUNTRY,
    /// <summary>
    /// The input value should be less than the maximum value allowed.
    /// </summary>
    LESS_THAN,
    /// <summary>
    /// The input value should be less than or equal to the maximum value allowed.
    /// </summary>
    LESS_THAN_OR_EQUAL_TO,
    /// <summary>
    /// Line item was not found in checkout.
    /// </summary>
    LINE_ITEM_NOT_FOUND,
    /// <summary>
    /// Checkout is locked.
    /// </summary>
    LOCKED,
    /// <summary>
    /// Missing payment input.
    /// </summary>
    MISSING_PAYMENT_INPUT,
    /// <summary>
    /// Not enough in stock.
    /// </summary>
    NOT_ENOUGH_IN_STOCK,
    /// <summary>
    /// Input value is not supported.
    /// </summary>
    NOT_SUPPORTED,
    /// <summary>
    /// The input value needs to be blank.
    /// </summary>
    PRESENT,
    /// <summary>
    /// Shipping rate expired.
    /// </summary>
    SHIPPING_RATE_EXPIRED,
    /// <summary>
    /// Throttled during checkout.
    /// </summary>
    THROTTLED_DURING_CHECKOUT,
    /// <summary>
    /// The input value is too long.
    /// </summary>
    TOO_LONG,
    /// <summary>
    /// The amount of the payment does not match the value to be paid.
    /// </summary>
    TOTAL_PRICE_MISMATCH,
    /// <summary>
    /// Unable to apply discount.
    /// </summary>
    UNABLE_TO_APPLY
}