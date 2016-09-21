using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// (Deprecated) Stored PlayerProjectScoreLink instances.
/// Like mentioned in the PlayerProjectScoreLink notes, this was ignored since it can make things too complicated.
/// </summary>
public class PlayerScoreLinkDatabase 
{
    private static List<PlayerProjectScoreLink> playerScoresCollection = null;

    public static void ValidateDatabase()
    {
        if (playerScoresCollection == null)
        {
            playerScoresCollection = new List<PlayerProjectScoreLink>();
        }
    }

    public static void AddPlayerScoreLink(PlayerProjectScoreLink score)
    {
        ValidateDatabase();
        if (playerScoresCollection.Contains(score))
        {
            Debug.LogError("(" + score + ") is already in the database. Player Score was not saved.");
        }
        else
        {
            playerScoresCollection.Add(score);
        }
    }

    public static Score RetrieveScoreByProfile(float profileID, float projectID)
    {
        PlayerProjectScoreLink link = playerScoresCollection.First(x => x.PlayerProfileID == profileID && x.ProjectID == projectID);
        Score score = ScoresDatabase.Instance.RetrieveEntity(link.ScoreID);
        return score;
    }

    public static List<Score> RetrieveAllScoresAssociatedToTheProfile(float profileID)
    {
        List<PlayerProjectScoreLink> links = playerScoresCollection.Where(x => x.PlayerProfileID == profileID).ToList();
        List<Score> allProfileScores;
        PlayerScoreLinkDatabase.PopulateScoreList(out allProfileScores, links);
        return allProfileScores;
    }

    public static List<Score> RetrieveAllScoresAssociatedToTheProject(float projectIDToSearchBy)
    {
        List<PlayerProjectScoreLink> links = playerScoresCollection.Where(x => x.ProjectID == projectIDToSearchBy).ToList();
        List<Score> allProjectScores;
        PlayerScoreLinkDatabase.PopulateScoreList(out allProjectScores, links);
        return allProjectScores;
    }

    public static List<PlayerProjectScoreLink> RetrieveAllPlayerProjectScoreLinks()
    {
        ValidateDatabase();
        return playerScoresCollection;
    }

    private static void PopulateScoreList(out List<Score> scoresList, List<PlayerProjectScoreLink> links)
    {
        scoresList = new List<Score>();
        foreach (PlayerProjectScoreLink scoreLink in links)
        {
            Score score = ScoresDatabase.Instance.RetrieveEntity(scoreLink.ScoreID);
            if (score != null)
            {
                scoresList.Add(score);
            }
        }
    }
}







//public static List<PlayerProjectScoreLink> RetrievePlayerScoresByProfile(float profileID)
//{
//    ValidateDatabase();
//    return playerScoresCollection.Where(x => x.profileID == profileID).ToList();
//}

//public static List<PlayerProjectScoreLink> RetrievePlayerScoresByProject(float projectID)
//{
//    ValidateDatabase();
//    return playerScoresCollection.Where(x => x.projectID == projectID).ToList();
//}

//public static List<PlayerProjectScoreLink> RetrievePlayerScoresByScore(float scoreID)
//{
//    ValidateDatabase();
//    return playerScoresCollection.Where(x => x.scoreID == scoreID).ToList();
//}