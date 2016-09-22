using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class CutLineDatabase : AbstractDatabase<CutLineData>
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
