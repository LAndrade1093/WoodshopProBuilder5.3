using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class GlueAreaDatabase : AbstractDatabase<GlueAreaData>
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
