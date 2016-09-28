using UnityEngine;
using System.Collections;

/* Notes:
 * This class currently has it's own line score percentage to determine how well the player did with their feed rate. Since the score
 * is now stored on the CutLineData class and is tracked by the Score clas, this not be necessary.
 * Refactor the gameplay to use the score in those classes
 */

/// <summary>
/// Class that tracks how fast the player is pushing the wood material into the saw
/// </summary>
public class FeedRate : MonoBehaviour 
{
    public float MinPerfectRate;
    public float MaxPerfectRate;
    public float MaxFeedRate;
    public float ValueDecreasePerUpdate;
    public FeedRateBar RateDisplay;
    public bool RateTooSlow { get; set; }
    public bool RateTooFast { get; set; }

    private float LineScorePercentage = 100.0f;

    void Start()
    {
        RateTooSlow = false;
        RateTooFast = false;
    }

    /// <summary>
    /// Updates the score if pushing too fast or too slow
    /// </summary>
    /// <param name="rate">The current speed</param>
    public void UpdateScoreWithRate(float rate)
    {
        if (rate < MinPerfectRate || rate > MaxPerfectRate)
        {
            LineScorePercentage -= ValueDecreasePerUpdate;
        }
        RateTooSlow = (rate < MinPerfectRate);
        RateTooFast = (rate > MaxPerfectRate);
    }

    public void ReduceScoreDirectly(float amount)
    {
        LineScorePercentage -= amount;
    }

    /// <summary>
    /// Updates the Feed rate UI
    /// </summary>
    /// <param name="rate">The current speed</param>
    public void UpdateDataDisplay(float rate)
    {
        RateDisplay.UpdateBar(rate, MaxFeedRate);
        RateDisplay.UpdateColor(rate, MaxFeedRate, MinPerfectRate, MaxPerfectRate);
    }

    public float GetLineScore()
    {
        return LineScorePercentage;
    }

    public void ResetFeedRate()
    {
        LineScorePercentage = 100.0f;
        RateDisplay.ResetDisplay();
        RateTooSlow = false;
        RateTooFast = false;
    }
}