using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// Stores all the different tools in the game
/// </summary>
[System.Serializable]
public class ToolsDatabase : AbstractDatabase<Tool>
{
    private static ToolsDatabase _instance;

    public static ToolsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ToolsDatabase();
            }
            return _instance;
        }
    }

    private ToolsDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/WoodshopMaterials" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}