using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoresDatabase
{
    private static Dictionary<float, Score> scoresDictionary = null;

    public static void ValidateDatabase()
    {
        if (scoresDictionary == null)
        {
            scoresDictionary = new Dictionary<float, Score>();
        }
    }

    public static void AddScore(Score score)
    {
        ValidateDatabase();
        if (scoresDictionary.ContainsKey(score.ID))
        {
            Debug.LogError("Project ID \"" + score.ID + "\" is already used. Score was not saved.");
        }
        else
        {
            scoresDictionary.Add(score.ID, score);
        }
    }

    public static void UpdateScore(float id, Score score)
    {
        if (id == score.ID)
        {
            ValidateDatabase();
            if (!scoresDictionary.ContainsKey(id))
            {
                AddScore(score);
            }
            else
            {
                scoresDictionary[id] = score;
            }
        }
        else
        {
            Debug.LogError("The id \"" + id + "\" does not match \"" + score.ID + "\", the id of the Score being updated.");
        }
    }

    public static Score RetrieveScore(float scoreID)
    {
        ValidateDatabase();
        Score score = null;
        if (scoresDictionary.ContainsKey(scoreID))
        {
            score = scoresDictionary[scoreID];
        }
        else
        {
            Debug.LogError("The id \"" + scoreID + "\" was not in the Scores database.");
        }
        return score;
    }

    public static List<Score> RetrieveAllScores()
    {
        ValidateDatabase();
        List<Score> allScores = new List<Score>();
        if (scoresDictionary.Count > 0)
        {
            allScores = scoresDictionary.Values.ToList();
        }
        return allScores;
    }

    //public static bool DeleteProject(string projectID)
    //{
    //    ValidateDatabase();
    //    bool successful = false;
    //    if (gameProjectsDictionary.ContainsKey(projectID))
    //    {
    //        successful = gameProjectsDictionary.Remove(projectID);
    //    }
    //    else
    //    {
    //        Debug.LogError("The project id \"" + projectID + "\" was not in the database.");
    //    }
    //    return successful;
    //}
}
