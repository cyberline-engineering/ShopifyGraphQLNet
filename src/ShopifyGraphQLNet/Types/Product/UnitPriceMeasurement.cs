namespace ShopifyGraphQLNet.Types.Product;

/// <summary>
/// The measurement used to calculate a unit price for a product variant (e.g. $9.99 / 100ml).
/// </summary>
public class UnitPriceMeasurement
{
    /// <summary>
    /// The type of unit of measurement for the unit price measurement.
    /// </summary>
    public UnitPriceMeasurementMeasuredType? MeasuredType { get; set; }
    /// <summary>
    /// The quantity unit for the unit price measurement.
    /// </summary>
    public UnitPriceMeasurementMeasuredUnit? QuantityUnit { get; set; }
    /// <summary>
    /// The quantity value for the unit price measurement.
    /// </summary>
    public double QuantityValue { get; set; }
    /// <summary>
    /// The reference unit for the unit price measurement.
    /// </summary>
    public UnitPriceMeasurementMeasuredUnit? ReferenceUnit { get; set; }
    /// <summary>
    /// The reference value for the unit price measurement.
    /// </summary>
    public long ReferenceValue { get; set; }
}

/// <summary>
/// The valid units of measurement for a unit price measurement.
/// </summary>
public enum UnitPriceMeasurementMeasuredUnit
{
    /// <summary>
    /// 100 centiliters equals 1 liter.
    /// </summary>
    CL,
    /// <summary>
    /// 100 centimeters equals 1 meter.
    /// </summary>
    CM,
    /// <summary>
    /// Metric system unit of weight.
    /// </summary>
    G,
    /// <summary>
    /// 1 kilogram equals 1000 grams.
    /// </summary>
    KG,
    /// <summary>
    /// Metric system unit of volume.
    /// </summary>
    L,
    /// <summary>
    /// Metric system unit of length.
    /// </summary>
    M,
    /// <summary>
    /// Metric system unit of area.
    /// </summary>
    M2,
    /// <summary>
    /// 1 cubic meter equals 1000 liters.
    /// </summary>
    M3,
    /// <summary>
    /// 1000 milligrams equals 1 gram.
    /// </summary>
    MG,
    /// <summary>
    /// 1000 milliliters equals 1 liter.
    /// </summary>
    ML,
    /// <summary>
    /// 1000 millimeters equals 1 meter.
    /// </summary>
    MM
}

/// <summary>
/// The accepted types of unit of measurement.
/// </summary>
public enum UnitPriceMeasurementMeasuredType
{
    /// <summary>
    /// Unit of measurements representing areas.
    /// </summary>
    AREA,
    /// <summary>
    /// Unit of measurements representing lengths.
    /// </summary>
    LENGTH,
    /// <summary>
    /// Unit of measurements representing volumes.
    /// </summary>
    VOLUME,
    /// <summary>
    /// Unit of measurements representing weights.
    /// </summary>
    WEIGHT
}