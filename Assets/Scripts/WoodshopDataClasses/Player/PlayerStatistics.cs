using UnityEngine;
using System.Collections;

public class PlayerStatistics
{
    private float _associatedProfileID;
    private int _totalNumberOfProjectsCompleted;
    private float _totalScore;
    private float _totalCashEarned;
    private float _totalTimePlayed;

    public float AssociatedProfileID
    {
        get { return _associatedProfileID; }
        private set { _associatedProfileID = value; }
    }

    public int TotalNumberOfProjectsCompleted
    {
        get { return _totalNumberOfProjectsCompleted; }
        set { _totalNumberOfProjectsCompleted = value; }
    }

    public float TotalScore
    {
        get { return _totalScore; }
        set { _totalScore = value; }
    }

    public float TotalCashEarned
    {
        get { return _totalCashEarned; }
        set { _totalCashEarned = value; }
    }

    public float TotalTimePlayed
    {
        get { return _totalTimePlayed; }
        set { _totalTimePlayed = value; }
    }

    public PlayerStatistics(float profile)
    {
        this.AssociatedProfileID = profile;
        this.TotalNumberOfProjectsCompleted = 0;
        this.TotalScore = 0f;
        this.TotalCashEarned = 0f;
        this.TotalTimePlayed = 0f;
    }

    public PlayerStatistics(float profile, int projectsCompleted, float score, float cash, float time)
    {
        this.AssociatedProfileID = profile;
        this.TotalNumberOfProjectsCompleted = projectsCompleted;
        this.TotalScore = score;
        this.TotalCashEarned = cash;
        this.TotalTimePlayed = time;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        PlayerStatistics otherStat = (PlayerStatistics)obj;
        if (this.AssociatedProfileID != otherStat.AssociatedProfileID) return false;
        if (this.TotalNumberOfProjectsCompleted != otherStat.TotalNumberOfProjectsCompleted) return false;
        if (this.TotalScore != otherStat.TotalScore) return false;
        if (this.TotalCashEarned != otherStat.TotalCashEarned) return false;
        if (this.TotalTimePlayed != otherStat.TotalTimePlayed) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
