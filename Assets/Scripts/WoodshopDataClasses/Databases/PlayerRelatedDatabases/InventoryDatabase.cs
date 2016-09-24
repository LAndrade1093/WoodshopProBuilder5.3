using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Stores the different inventory instances (one instance per player)
/// </summary>
public class InventoryDatabase : AbstractDatabase<Inventory>
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
            return new List<string> { "PlayerInventory" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
