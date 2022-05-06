namespace ShopifyGraphQLNet.Types.Interface;

/// <summary>
/// An object with an ID field to support global identification,
/// in accordance with the <see href="https://relay.dev/graphql/objectidentification.htm#sec-Node-Interface">Relay specification</see>
/// </summary>
public interface INode
{
    /// <summary>
    /// A globally-unique identifier.
    /// </summary>
    public string Id { get; set; }
}