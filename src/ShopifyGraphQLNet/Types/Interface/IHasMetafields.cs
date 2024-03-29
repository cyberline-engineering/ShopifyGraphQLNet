﻿namespace ShopifyGraphQLNet.Types.Interface;

/// <summary>
/// Represents information about the metafields associated to the specified resource.
/// </summary>
public interface IHasMetafields
{
    /// <summary>
    /// Returns a metafield found by namespace and key.
    /// </summary>
    public Metafield? Metafield { get; set; }
}