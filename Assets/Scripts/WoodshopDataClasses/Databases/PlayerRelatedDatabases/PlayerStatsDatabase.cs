using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/* NOTES: Application.persistentDataPath+
 * This is sensitive game data. 
 * Save this data to a binary file on the user's phone.
 */

/// <summary>
/// Database for the PlayerStatistics
/// </summary>
[System.Serializable]
public class PlayerStatsDatabase : AbstractDatabase<PlayerStatistics>, IBinaryDatabase
{
    private static PlayerStatsDatabase _instance;

    public static PlayerStatsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerStatsDatabase();
            }
            return _instance;
        }
    }

    private PlayerStatsDatabase() { }

    public PlayerStatistics GetStatisticsForPlayer(float playerID)
    {
        return Entities.Find(x => x.AssociatedProfileID == playerID);
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { Application.persistentDataPath + "PlayerStats" };
        }
    }

    public bool SaveToBinaryFile()
    {
        throw new NotImplementedException();
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
