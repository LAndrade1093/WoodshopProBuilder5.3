using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Database class to store all CutLine data instances.
/// </summary>
[System.Serializable]
public class CutLineDatabase : GameplayDatabase<CutLineData>
{
    private static CutLineDatabase _instance;

    public static CutLineDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new CutLineDatabase();
            }
            return _instance;
        }
    }

    private CutLineDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/CutLines" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
