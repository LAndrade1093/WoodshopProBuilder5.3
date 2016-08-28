using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public interface IDal<T> where T : IDalAsset
{
    /// <summary>
    /// Creates and saves an entity in the implementing database class
    /// </summary>
    /// <param name="entity">The entity to save</param>
    /// <returns>The saved entity with a proper ID</returns>
    T CreateEntity(T entity);

    /// <summary>
    /// Retrieves an object based on the ID passed in
    /// </summary>
    /// <param name="id">The id of the entity to find</param>
    /// <returns>The entity associated to the id argument</returns>
    T RetrieveEntity(float id);
    
    /// <summary>
    /// Gets all of the entities available in the database
    /// </summary>
    /// <returns>A collection of entities</returns>
    List<T> RetrieveAllEntities();
    
    /// <summary>
    /// Updates the entity in the database based on the id of the passed in entity
    /// </summary>
    /// <param name="entity">The updated entity</param>
    /// <returns>The same passed in entity</returns>
    T UpdateEntity(T entity);

    /// <summary>
    /// Deletes the entity associated to the id from the database
    /// </summary>
    /// <param name="entity">The id of the associated entity to delete</param>
    void DeleteEntity(float id);

    /// <summary>
    /// Deletes the passed-in entities from the database
    /// </summary>
    /// <param name="entity">The entity to delete</param>
    void DeleteEntity(T entity);

    /// <summary>
    /// Determines the number of entities in the database 
    /// </summary>
    /// <returns>The total number of entities in the database</returns>
    int Count();

    /// <summary>
    /// Checks whether the entity is in the database based on an id
    /// </summary>
    /// <param name="id">The associated id of the entity to find</param>
    /// <returns>A bool that determines whether or not the entity is in the database</returns>
    bool Contains(float id);

    /// <summary>
    /// Checks whether the entity is in the database based on the passed-in entity
    /// </summary>
    /// <param name="entity">The entity to find</param>
    /// <returns>A bool that determines whether or not the entity is in the database</returns>
    bool Contains(T entity);

    /// <summary>
    /// Determines the next id from the database
    /// i.e. if database has ids 1, 2, 8, and 10, id 11 will be retrieved
    /// </summary>
    /// <returns>The next id in the database</returns>
    float GetNextID();
}
