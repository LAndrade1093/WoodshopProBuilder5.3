using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Database class to store all ClampPoint data instances.
/// </summary>
[System.Serializable]
public class ClampPointDatabase : GameplayDatabase<ClampPointData> 
{
    private static ClampPointDatabase _instance;

    public static ClampPointDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ClampPointDatabase();
            }
            return _instance;
        }
    }

    private ClampPointDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/ClampPoints" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
