using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDal<T> where T : IDalAsset
{
    /// <summary>
    /// Creates and saves an object in the implementing database class
    /// </summary>
    /// <param name="asset">The object to save</param>
    /// <returns>The saved object with a proper ID</returns>
    T CreateAsset(T asset);

    /// <summary>
    /// Retrieves an asset based on the ID passed in
    /// </summary>
    /// <param name="id">The id of the asset to find</param>
    /// <returns>The asset associated to the id argument</returns>
    T RetrieveAsset(float id);
    
    /// <summary>
    /// Gets all of the assets available in the database
    /// </summary>
    /// <returns>A collection of assets</returns>
    IEnumerable<T> RetrieveAllAssets();
    
    /// <summary>
    /// Updates the asset in the database based on the id of the passed in asset
    /// </summary>
    /// <param name="asset">The updated asset</param>
    /// <returns>The same passed in asset</returns>
    T UpdateAsset(T asset);

    /// <summary>
    /// Deletes the asset associated to the id from the database
    /// </summary>
    /// <param name="asset">The id of the associated asset to delete</param>
    void DeleteAsset(float id);

    /// <summary>
    /// Deletes the passed-in assets from the database
    /// </summary>
    /// <param name="asset">The asset to delete</param>
    void DeleteAsset(T asset);

    /// <summary>
    /// Determines the number of assets in the database 
    /// </summary>
    /// <returns>The total number of assets in the database</returns>
    int Count();

    /// <summary>
    /// Checks whether the asset is in the database based on an id
    /// </summary>
    /// <param name="id">The associated id of the asset to find</param>
    /// <returns>A bool that determines whether or not the asset is in the database</returns>
    bool Contains(float id);

    /// <summary>
    /// Checks whether the asset is in the database based on the passed-in asset
    /// </summary>
    /// <param name="asset">The asset to find</param>
    /// <returns>A bool that determines whether or not the asset is in the database</returns>
    bool Contains(T asset);

    /// <summary>
    /// Determines the next id from the database
    /// i.e. if database has ids 1, 2, 8, and 10, id 11 will be retrieved
    /// </summary>
    /// <returns>The next id in the database</returns>
    float GetNextID();
}
