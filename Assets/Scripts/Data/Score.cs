using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class Score
{
    private float nextID = 0;
    private float _id;
    private float _latestScoreValue;
    private float _highestScoreValue;

    private float temporaryPointValue;

    public float ID
    {
        get { return _id; }
        private set { _id = value; }
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
    {
        this.ID = nextID++;
        this.LatestScore = 0f;
        this.HighScore = 0f;
        this.temporaryPointValue = 0f;
    }

    public Score(float latest, float highScore)
    {
        this.ID = nextID++;        
        this.LatestScore = latest;
        this.HighScore = highScore;
        this.temporaryPointValue = 0f;
    }

    public Score(float latest, float highScore, float previousScore)
    {
        this.ID = nextID++;
        this.LatestScore = latest;
        this.HighScore = highScore;
        this.temporaryPointValue = previousScore;
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
        ScoresDatabase.UpdateScore(ID, this);
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



//public Score(string id, )
//{
//    this.ID = id;
//    TotalPoints = 0;
//    temporaryPoints = 0;
//}

//public virtual void Decrease(float amount, bool canBeLessThanZero = false)
//{
//    if ((temporaryPointValue - amount) < 0 && !canBeLessThanZero)
//    {
//        temporaryPointValue = 0;
//    }
//    else
//    {
//        temporaryPointValue -= amount;
//    }
//}