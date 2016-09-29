using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/* NOTES:
 * This is sensitive game data. 
 * Save this data to a binary file on the user's phone.
 * 
 * There needs to be an instance of a Score class for each link between a player 
 * and a project
 */

/// <summary>
/// Stores all scores in the game
/// </summary>
[System.Serializable]
public class ScoresDatabase : AbstractDatabase<Score>, IBinaryDatabase
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

    public List<Score> GetScoresForPlayer(float playerProfileID)
    {
        List<Score> associatedScores = new List<Score>();
        List<Score> scores = RetrieveAllEntities();
        foreach(Score s in scores)
        {
            if(s.AssociatedProfileID == playerProfileID)
            {
                scores.Add(s);
            }
        }
        return scores;
    }

    public List<Score> GetScoresByProjectID(float projectID)
    {
        List<Score> associatedScores = new List<Score>();
        List<Score> scores = RetrieveAllEntities();
        foreach (Score s in scores)
        {
            if (s.AssociatedProjectID == projectID)
            {
                scores.Add(s);
            }
        }
        return scores;
    }

    public Score GetScoreByAssociations(float projectID, float playerProfileID)
    {
        List<Score> scores = RetrieveAllEntities();
        Score score = scores.Find(x => x.AssociatedProjectID == projectID && x.AssociatedProfileID == playerProfileID);
        return score;
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            //Save to binary file on the user's device
            return new List<string> { Application.persistentDataPath + "Scores" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }

    public bool SaveToBinaryFile()
    {
        throw new NotImplementedException();
    }
}
