using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Stores and controls the score for a specific project for a specific player profile
/// </summary>
[System.Serializable]
public class Score : AbstractAsset
{
    private float _associatedProfileID;
    private float _associatedProjectID;
    private float _latestScoreValue;
    private float _highestScoreValue;

    private float temporaryPointValue;

    public float AssociatedProfileID
    {
        get { return _associatedProfileID; }
        private set{ _associatedProfileID = value; }
    }

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set { _associatedProjectID = value; }
    }
    
    public float LatestScore
    {
        get { return _latestScoreValue; }
        private set { _latestScoreValue = value; }
    }

    public float HighScore
    {
        get { return _highestScoreValue; }
        private set { _highestScoreValue = value; }
    }

    public Score()
        : base()
    {
        this.LatestScore = 0f;
        this.HighScore = 0f;
        this.temporaryPointValue = 0f;
        this.AssociatedProfileID = -1f;
        this.AssociatedProjectID = -1f;
    }

    public Score(float id)
        : base(id)
    {
        this.LatestScore = 0f;
        this.HighScore = 0f;
        this.temporaryPointValue = 0f;
        this.AssociatedProfileID = -1f;
        this.AssociatedProjectID = -1f;
    }

    public Score(float id, float latest, float highScore, float profileID, float projectID)
        : base(id)
    {        
        this.LatestScore = latest;
        this.HighScore = highScore;
        this.temporaryPointValue = 0f;
        this.AssociatedProfileID = profileID;
        this.AssociatedProjectID = projectID;
    }

    public Score(float id, float latest, float highScore, float previousScore, float profileID, float projectID)
        : base(id)
    {
        this.LatestScore = latest;
        this.HighScore = highScore;
        this.temporaryPointValue = previousScore;
        this.AssociatedProfileID = profileID;
        this.AssociatedProjectID = projectID;
    }

    public virtual void Increase(float amount)
    {
        temporaryPointValue += amount;
    }

    public virtual void Decrease(float amount, bool canBeLessThanZero = false)
    {
        if ((temporaryPointValue - amount) < 0 && !canBeLessThanZero)
        {
            temporaryPointValue = 0;
        }
        else
        {
            temporaryPointValue -= amount;
        }
    }

    public virtual void ResetScore(bool storeScoreValue = false)
    {
        if (storeScoreValue)
        {
            SaveScore(temporaryPointValue);
        }
        temporaryPointValue = 0;
    }

    private void SaveScore(float scoreToSave)
    {
        LatestScore = scoreToSave;
        if (ScoreReachedHighScore(scoreToSave))
        {
            HighScore = temporaryPointValue;
            if (onHighScoreReached != null)
            {
                onHighScoreReached(this, EventArgs.Empty);
            }
        }
        if (onLatestScoreUpdated != null)
        {
            onLatestScoreUpdated(this, EventArgs.Empty);
        }
        ScoresDatabase.Instance.UpdateEntity(this);
    }

    public bool ScoreReachedHighScore(float scoreValue)
    {
        return (scoreValue > HighScore);
    }

    public float GetCurrentScore()
    {
        return temporaryPointValue;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Score otherScore = (Score)obj;
        if (this.ID != otherScore.ID) return false;
        if (this.LatestScore != otherScore.LatestScore) return false;
        if (this.HighScore != otherScore.HighScore) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    private event EventHandler onLatestScoreUpdated;
    public event EventHandler OnLatestScoreUpdated
    {
        add
        {
            if (value != null)
            {
                onLatestScoreUpdated += value;
            }
            else
            {
                Debug.LogError("NULL value cannot be assigned to OnLatestScoreUpdated");
            }
        }
        remove
        {
            onLatestScoreUpdated -= value;
        }
    }

    public event EventHandler onHighScoreReached;
    public event EventHandler OnHighScoreReached
    {
        add
        {
            if (value != null)
            {
                onHighScoreReached += value;
            }
            else
            {
                Debug.LogError("NULL value cannot be assigned to OnHighScoreReached");
            }
        }
        remove
        {
            onHighScoreReached -= value;
        }
    }
}