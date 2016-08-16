using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreLockDatabase
{
    private static List<ScoreLock> scoreLockList = null;

    public static void ValidateDatabase()
    {
        if (scoreLockList == null)
        {
            scoreLockList = new List<ScoreLock>();
        }
    }

    public static void AddScoreLock(ScoreLock gate)
    {
        ValidateDatabase();
        if (!scoreLockList.Contains(gate))
        {
            scoreLockList.Add(gate);
        }
        else
        {
            Debug.LogError(gate.ID + ": This score gate is already in the databse");
        }
    }

    public static ScoreLock RetrieveScoreLock(float lockID)
    {
        ValidateDatabase();
        ScoreLock gate = null;
        gate = scoreLockList.First(x => x.ID == lockID);
        return gate;
    }

    public static ScoreLock RetrieveScoreLockByProjectID(float projectID)
    {
        ValidateDatabase();
        ScoreLock gate = null;
        gate = scoreLockList.First(x => x.ProjectIDToUnlock == projectID);
        return gate;
    }

    public List<ScoreLock> RetrieveAllScoreLocks()
    {
        ValidateDatabase();
        return scoreLockList;
    }
}
