using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Database class to store all SwipeGameplay data instances.
/// </summary>
[System.Serializable]
public class SwipingDatabase : GameplayDatabase<SwipingData>
{
    private static SwipingDatabase _instance;

    public static SwipingDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new SwipingDatabase();
            }
            return _instance;
        }
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/SwipeData" };
        }
    }

    private SwipingDatabase() { }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
