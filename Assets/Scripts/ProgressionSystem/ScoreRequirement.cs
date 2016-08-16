using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ScoreRequirement 
{
    private ScoreLock _associatedScoreLock;
    private float _requiredScore;
    private float _associatedProjectID = -1f;

    public ScoreLock AssociatedScoreLock
    {
        get { return _associatedScoreLock; }
        private set { _associatedScoreLock = value; }
    }

    public float RequiredScore
    {
        get { return _requiredScore; }
        set { _requiredScore = value; }
    }

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set 
        {
            if (_associatedProjectID < 0) //If not set
            {
                Project project = ProjectsDatabase.RetrieveProject(value);
                if (project != null)
                {
                    _associatedProjectID = value;
                    List<Score> scores = PlayerScoreLinkDatabase.RetrieveAllScoresAssociatedToTheProject(_associatedProjectID);
                    foreach(Score score in scores)
                    {
                        score.OnLatestScoreUpdated += OnProjectScoreUpdated;
                    }
                }
            }
        }
    }

    public ScoreRequirement(float projectID)
    {
        this.AssociatedScoreLock = null;
        this.RequiredScore = -1f;
        this.AssociatedProjectID = projectID;
    }

    public ScoreRequirement(float minimumScore, float projectID)
    {
        this.AssociatedScoreLock = null;
        this.RequiredScore = minimumScore;
        this.AssociatedProjectID = projectID;
    }

    public bool ProjectScoreReachedRequiredScore()
    {
        bool reached = false;
        Project project = ProjectsDatabase.RetrieveProject(AssociatedProjectID);
        Score score = PlayerScoreLinkDatabase.RetrieveScoreByProfile(PlayerProfileDatabase.currentProfile.ID, project.ID);
        float projectScoreValue = score.HighScore;
        reached = (projectScoreValue >= RequiredScore);
        return reached;
    }

    public void SetAssociatedScoreLock(ScoreLock scoreLock)
    {
        this.AssociatedScoreLock = scoreLock;
    }

    public void OnProjectScoreUpdated(object sender, EventArgs e)
    {
        if (sender.GetType() == typeof(Score))
        {
            if (ProjectScoreReachedRequiredScore())
            {
                AssociatedScoreLock.UnlockProject();
            }
        }
    }
}





//public ScoreRequirement(float minimumScore, Project project)
//{
//    this.ID = nextId++;
//    this.MinimumScore = minimumScore;
//    this.ProjectToCheck = project;
//}

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




//else if (_associatedProjectID != value)
//{
//    Project currentProject = ProjectsCollection.RetrieveProject(_associatedProjectID);
//    Project otherProject = ProjectsCollection.RetrieveProject(value);
//    canBeSet = (currentProject != null && otherProject != null);
//    if (canBeSet)
//    {
//        Score currentScore = PlayerScoresCollection.RetrieveScoreByProfile(PlayerProfileContainer.currentProfile.ID, currentProject.ID);
//        currentScore.OnLatestScoreUpdated -= OnProjectScoreUpdated;
//        Score otherScore = PlayerScoresCollection.RetrieveScoreByProfile(PlayerProfileContainer.currentProfile.ID, value);
//        otherScore.OnLatestScoreUpdated += OnProjectScoreUpdated;
//    }
//}