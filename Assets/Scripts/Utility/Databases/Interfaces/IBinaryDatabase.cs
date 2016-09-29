using UnityEngine;
using System.Collections;

public interface IBinaryDatabase
{
    /// <summary>
    /// Saves the data in a database to a binary file
    /// </summary>
    /// <returns>Whether or not the save was successful</returns>
    bool SaveToBinaryFile();
}
