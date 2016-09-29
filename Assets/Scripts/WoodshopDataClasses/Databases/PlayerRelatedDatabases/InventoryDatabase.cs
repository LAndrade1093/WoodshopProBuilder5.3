using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/* NOTES:
 * This is sensitive game data. 
 * Save this data to a binary file on the user's phone.
 */

/// <summary>
/// Stores the different inventory instances (one instance per player)
/// </summary>
[System.Serializable]
public class InventoryDatabase : AbstractDatabase<Inventory>, IBinaryDatabase
{
    private static InventoryDatabase _instance;

    public static InventoryDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new InventoryDatabase();
            }
            return _instance;
        }
    }

    private InventoryDatabase() { }

    public Inventory GetInventoryByPlayer(float playerProfileID)
    {
        Inventory inventory = Entities.Find(x => x.AssociatedProfileID == playerProfileID);
        return inventory;
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            //Save to binary file on the user's device
            return new List<string> { Application.persistentDataPath + "PlayerInventory" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }

    public bool SaveToBinaryFile()
    {
        throw new NotImplementedException();
    }
}
