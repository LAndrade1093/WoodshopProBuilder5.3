using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Associates a score requirement to a project for the associated ScoreLock.
/// </summary>
public class ScoreRequirement : AbstractAsset
{
    private float _associatedScoreLockID;
    private float _requiredProjectScore;
    private float _associatedProjectID;

    public float AssociatedScoreLockID
    {
        get { return _associatedScoreLockID; }
        private set { _associatedScoreLockID = value; }
    }

    public float RequiredProjectScore
    {
        get { return _requiredProjectScore; }
        set { _requiredProjectScore = value; }
    }

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set 
        {
            if (_associatedProjectID >= 0) //Association was already set
            {
                Project previousProject = ProjectsDatabase.Instance.RetrieveEntity(_associatedProjectID);
                if (previousProject != null)
                {
                    List<Score> scores = ScoresDatabase.Instance.GetScoresByProjectID(_associatedProjectID);
                    foreach (Score score in scores)
                    {
                        score.OnLatestScoreUpdated -= OnProjectScoreUpdated;
                    }
                }
            }

            _associatedProjectID = value;
            Project project = ProjectsDatabase.Instance.RetrieveEntity(_associatedProjectID);
            if (project != null)
            {
                List<Score> scores = ScoresDatabase.Instance.GetScoresByProjectID(_associatedProjectID);
                foreach (Score score in scores)
                {
                    score.OnLatestScoreUpdated += OnProjectScoreUpdated;
                }
            }
        }
    }

    public ScoreRequirement()
        : base()
    {
        this.AssociatedScoreLockID = -1f;
        this.RequiredProjectScore = -1f;
        this.AssociatedProjectID = -1f;
    }

    public ScoreRequirement(float id)
        : base(id)
    {
        this.AssociatedScoreLockID = -1f;
        this.RequiredProjectScore = -1f;
        this.AssociatedProjectID = -1f;
    }

    public ScoreRequirement(float id, float scoreLockID, float requiredScore, float projectID)
        : base(id)
    {
        this.AssociatedScoreLockID = scoreLockID;
        this.RequiredProjectScore = requiredScore;
        this.AssociatedProjectID = projectID;
    }

    public bool ScoreRequirementMet(float playerprofileID)
    {
        bool reached = false;
        Project project = ProjectsDatabase.Instance.RetrieveEntity(AssociatedProjectID);
        Score score = ScoresDatabase.Instance.GetScoreByAssociations(AssociatedProjectID, playerprofileID);
        float projectScoreValue = score.HighScore;
        reached = (projectScoreValue >= RequiredProjectScore);
        return reached;
    }

    public void SetAssociatedScoreLock(ScoreLock scoreLock)
    {
        SetAssociatedScoreLock(scoreLock.ID);
    }

    public void SetAssociatedScoreLock(float scoreLockID)
    {
        this.AssociatedScoreLockID = scoreLockID;
    }

    public void OnProjectScoreUpdated(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(Score))
        {
            Score score = (Score)sender;
            if (ScoreRequirementMet(score.AssociatedProfileID))
            {
                ScoreLock scoreLock = ScoreLockDatabase.Instance.RetrieveEntity(AssociatedScoreLockID);
                scoreLock.UnlockProject(score.AssociatedProfileID);//Maybe use the currentProfile field in the PlayerProfileDatabase?
            }
        }
    }
}





//public ScoreRequirement(float minimumScore, string projectID)
//{
//    this.ID = nextId++;
//    this.MinimumScore = minimumScore;
//    Project retrievedProject = ProjectsCollection.RetrieveProject(projectID);
//    if (retrievedProject == null)
//    {
//        Debug.LogError("");
//    }
//    else
//    {
//        this.ProjectToCheckID = retrievedProject;
//    }
//}