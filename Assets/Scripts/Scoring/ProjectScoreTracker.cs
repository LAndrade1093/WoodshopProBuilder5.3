using UnityEngine;
using System.Collections;

public class ProjectScoreTracker : MonoBehaviour 
{
    [Header("Project Value")]
    public float ProjectCashValue;
    public int ProjectPointsValue;

    [HideInInspector]
    public float TotalScore;
    [HideInInspector]
    public float ScorePercentage;
    [HideInInspector]
    public float NumberOfSteps;

    void Awake()
    {
        TotalScore = 0f;
        ScorePercentage = 0f;
        NumberOfSteps = 0f;
    }

    public void ApplyScore(float points)
    {
        TotalScore += points;
        NumberOfSteps++;
        CalculatePercentage();
        Debug.Log("Applied Score: " + points);
        Debug.Log("Number of Completed Steps: " + NumberOfSteps);
        Debug.Log("Current Total Score: " + TotalScore);
        Debug.Log("Current Score Percentage: " + ScorePercentage);
        Debug.Log("Current Project Value: " + CalculateCurrentCashValue());
    }

    public void ResetScore()
    {
        TotalScore = 0f;
        ScorePercentage = 100f;
        NumberOfSteps = 0;
    }

    private void CalculatePercentage()
    {
        if (NumberOfSteps == 0)
        {
            ScorePercentage = 100;
        }
        else
        {
            ScorePercentage = TotalScore / NumberOfSteps;
            if (ScorePercentage > 100f)
            {
                ScorePercentage = 100f;
            }
        }

    }

    public float CalculateCurrentCashValue()
    {
        if (NumberOfSteps == 0)
        {
            return ProjectCashValue;
        }
        else
        {
            float valueFromPercentage = ProjectCashValue * (ScorePercentage / 100.0f);
            return valueFromPercentage;
        }
    }

    public float CalculateCurrentPointValue()
    {
        if (NumberOfSteps == 0)
        {
            return ProjectPointsValue;
        }
        else
        {
            float valueFromPercentage = ProjectPointsValue * (ScorePercentage / 100.0f);
            return valueFromPercentage;
        }
    }
}
