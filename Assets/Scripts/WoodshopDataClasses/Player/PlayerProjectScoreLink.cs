using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerProjectScoreLink 
{
    private float _projectID;
    private float _scoreID;
    private float _playerProfileID;

    public float ProjectID
    {
        get { return _projectID; }
        private set { _projectID = value; }
    }

    public float PlayerProfileID
    {
        get { return _playerProfileID; }
        private set { _playerProfileID = value; }
    }

    public float ScoreID
    {
        get { return _scoreID; }
        private set { _scoreID = value; }
    }

    public PlayerProjectScoreLink(float projectID, float profileID, float scoreID)
    {
        this.ProjectID = projectID;
        this.PlayerProfileID = profileID;
        this.ScoreID = scoreID;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        PlayerProjectScoreLink otherLink = (PlayerProjectScoreLink)obj;
        if (this.ProjectID != otherLink.ProjectID) return false;
        if (this.ScoreID != otherLink.ScoreID) return false;
        if (this.PlayerProfileID != otherLink.PlayerProfileID) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return "Project ID: " + ProjectID + " | Player Profile ID: " + PlayerProfileID + " | Score ID: " + ScoreID;
    }
}