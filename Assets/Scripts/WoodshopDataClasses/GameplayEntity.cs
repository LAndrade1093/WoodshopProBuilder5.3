using UnityEngine;
using System.Collections;

/// <summary>
/// Objects that can affect the final score and sale price
/// </summary>
[System.Serializable]
public class GameplayEntity : AbstractAsset
{
    public float PerfectScore;
    public float AverageScore;
    public float PoorScore;

    public GameplayEntity()
        : base ()
    {
        PerfectScore = -1f;
        AverageScore = -1f;
        PoorScore = -1f;
    }

    public GameplayEntity(float id)
        : base(id)
    {
        PerfectScore = -1f;
        AverageScore = -1f;
        PoorScore = -1f;
    }

    public GameplayEntity(float id, float perfectScore, float averageScore, float poorScore)
        : base(id)
    {
        PerfectScore = perfectScore;
        AverageScore = averageScore;
        PoorScore = poorScore;
    }
}
