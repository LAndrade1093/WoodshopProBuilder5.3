using UnityEngine;
using System.Collections;

public enum LineCutRank
{
    Perfect,
    Good,
    Passable,
    Failed
}

/* NOTES:
 * Most of the prototype is using percentages to determine what the final score is for a project. After the prototype
 * was done and I began working on the data classes, I decided that the score should be stored with the gameplay 
 * data and the percentages can be used to determine if the player gets a Perfect, Good, or Passable score. 
 * I never got around to fully implementing this, but with the data classes already set up this can work as
 * a basis for that system.
 *      -Set up similar classes that track how well a player finishes a task using percentages (100% to 0%)
 *      -Based on the percentage, the player will wither get a Perfect, Good, or Passable score.
 *      -If the percentage or score is too low, then the player fails and has to start over.
 *          - All the materials used will need to be bought again.
 */

/// <summary>
/// A prototype and test script for the SpiceRack prototype. Can still be repurposed to use the data from the CutLineData class.
/// </summary>
public class LineCutScoring : MonoBehaviour
{
    [Header("Score Values")]
    public float GoodCutScoreReduction;
    public float PassableCutScoreReduction;

    [Header("Rank Range Values")]
    [Range(0f, 100f)]
    public float PerfectCutMinimumScore = 95f;

    [Range(0f, 100f)]
    [Tooltip("Value must be less than the Perfect Cut Rank score minimum")]
    public float GoodCutMinimumScore = 75f;

    [Range(0f, 100f)]
    [Tooltip("Value must be less than the Good Cut Rank score minimum")]
    public float PassableCutMinimumScore = 55f;

    [Range(0f, 100f)]
    [Tooltip("Value must be less than the Passable Cut Rank score minimum")]
    public float FailedCutScore = 35f;

    private float scorePercentage = 100f;
    private LineCutRank lineRank = LineCutRank.Perfect;
    private CutLine line;

    void Start()
    {
        CheckScoreRanges();
        line = GetComponent<CutLine>();
    }

    public LineCutRank UpdateScore(float amountToDecrease)
    {
        scorePercentage -= amountToDecrease;
        if (ScoreDecreasedToGoodCutRank())
        {
            lineRank = LineCutRank.Good;
        }
        else if (ScoreDecreasedToPassableCutRank())
        {
            lineRank = LineCutRank.Passable;
        }
        else if (ScoreDecreasedToFailedRank())
        {
            lineRank = LineCutRank.Failed;
        }
        return lineRank;
    }

    public void ResetScore()
    {
        scorePercentage = 100f;
    }

    public float GetScorePercentage()
    {
        return scorePercentage;
    }

    private bool ScoreDecreasedToGoodCutRank()
    {
        return (scorePercentage < PerfectCutMinimumScore &&
                scorePercentage >= GoodCutMinimumScore &&
                lineRank == LineCutRank.Perfect && lineRank != LineCutRank.Good);
    }

    private bool ScoreDecreasedToPassableCutRank()
    {
        return (scorePercentage < GoodCutMinimumScore &&
                scorePercentage >= PassableCutMinimumScore &&
                lineRank == LineCutRank.Good && lineRank != LineCutRank.Passable);
    }

    private bool ScoreDecreasedToFailedRank()
    {
        return (scorePercentage < PassableCutMinimumScore &&
                scorePercentage <= FailedCutScore &&
                lineRank == LineCutRank.Passable && lineRank != LineCutRank.Failed);
    }

    private void CheckScoreRanges()
    {
        bool cleared = true;
        if (GoodCutMinimumScore >= PerfectCutMinimumScore)
        {
            Debug.LogError(gameObject + ": The Good Cut Rank minimum score must be less than the Perfect Cut Rank minimum score");
            cleared = false;
        }
        if (PassableCutMinimumScore >= GoodCutMinimumScore)
        {
            Debug.LogError(gameObject + ": The Passable Cut Rank minimum score must be less than the Good Cut Rank minimum score");
            cleared = false;
        }
        if (FailedCutScore >= PassableCutMinimumScore)
        {
            Debug.LogError(gameObject + ": The Failed Cut score must be less than the Passable Cut Rank minimum score");
            cleared = false;
        }
        if (!cleared)
        {
            Debug.Log(gameObject + ": End Line Cut Scoring Message--------------------------------------------------");
        }
    }
}
