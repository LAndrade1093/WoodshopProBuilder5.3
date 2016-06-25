using System.Collections;

public interface IScoreable
{
    void UpdateScore();
    void ResetScore();
    float GetScorePercentage();
}
