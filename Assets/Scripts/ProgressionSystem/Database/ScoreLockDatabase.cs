using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// Stores all ScoreLock instances.
/// </summary>
public class ScoreLockDatabase : AbstractDatabase<ScoreLock>
{
    private static ScoreLockDatabase _instance;

    public static ScoreLockDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ScoreLockDatabase();
            }
            return _instance;
        }
    }

    private ScoreLockDatabase() { }

    public ScoreLock RetrieveScoreLockByProjectID(float projectID)
    {
        ScoreLock scoreLock = null;
        scoreLock = Instance.RetrieveAllEntities().First(x => x.ProjectIDToUnlock == projectID);
        return scoreLock;
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/ScoreLock" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
