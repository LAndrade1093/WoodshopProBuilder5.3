using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// Stores all scores in the game
/// </summary>
public class ScoresDatabase : AbstractDatabase<Score>
{
    private static ScoresDatabase _instance;

    public static ScoresDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoresDatabase();
            }
            return _instance;
        }
    }

    private ScoresDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            //Save to binary file on the user's device
            return new List<string> { "Scores" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
