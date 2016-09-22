using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class SnapPointDatabase : AbstractDatabase<GlueAreaData>
{
    private static SnapPointDatabase _instance;

    public static SnapPointDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SnapPointDatabase();
            }
            return _instance;
        }
    }

    private SnapPointDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/SnapPoints" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
