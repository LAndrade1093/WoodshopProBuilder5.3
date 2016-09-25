using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Database class to store all GlueArea data instances.
/// </summary>
[System.Serializable]
public class GlueAreaDatabase : GameplayDatabase<GlueAreaData>
{
    private static GlueAreaDatabase _instance;

    public static GlueAreaDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GlueAreaDatabase();
            }
            return _instance;
        }
    }

    private GlueAreaDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/GlueAreas" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
