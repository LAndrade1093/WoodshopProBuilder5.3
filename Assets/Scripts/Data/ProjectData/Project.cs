using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Project 
{
    private float nextID = 0;
    private float _id;
    private string _name;
    private float _salePrice;
    private ProjectRequirements _materialRequirements;
    private ProjectCompletionRequirements _completionRequirements;

    public float ID
    {
        get { return _id; }
        private set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public float SalePrice
    {
        get { return _salePrice; }
        private set { _salePrice = value; }
    }

    public ProjectRequirements MaterialRequirements
    {
        get { return _materialRequirements; }
        private set { _materialRequirements = value; }
    }

    public ProjectCompletionRequirements CompletionRequirements
    {
        get { return _completionRequirements; }
        private set { _completionRequirements = value; }
    }

    public Project(string name, float salePrice, ProjectRequirements requirements, ProjectCompletionRequirements completion)
    {
        this.ID = nextID++;
        this.Name = name;
        this.SalePrice = salePrice;
        this.MaterialRequirements = requirements;
        this.CompletionRequirements = completion;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Project otherProject = (Project)obj;
        if (this.ID != otherProject.ID) return false;
        if (this.Name != otherProject.Name) return false;
        if (this.SalePrice != otherProject.SalePrice) return false;
        if (this.MaterialRequirements != otherProject.MaterialRequirements) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}




//public enum ProjectState
//{
//    None,
//    Locked,
//    Unlocked,
//    Drying,
//    Completed,
//    Failed
//}

//public List<Step> projectSteps;
//public ScoreTracker scoreTracker;

//private int currentStep;

//public float TotalPointsEarned
//{
//    get
//    {
//        float points = 0f;
//        if (scoreTracker == null)
//        {
//            points = -1f;
//            Debug.LogError("Score Tracker is not initialized");
//        }
//        return points;
//    }
//}

//public float TotalPointsPossible
//{
//    get
//    {
//        float points = 0f;
//        foreach (Step step in projectSteps)
//        {
//            points += step.pointsToScore;
//        }
//        return points;
//    }
//}

//public Project(float ID, List<Step> steps, ScoreTracker scoreTracker, string name = "Project")
//{
//    this.ID = ID;
//    this.name = name;
//    this.projectSteps = steps;
//    this.scoreTracker = scoreTracker;
//    this.currentStep = 0;
//}

//public Project(float ID, List<Step> steps, ScoreTracker scoreTracker, string name = "Project")
//{
//    this.ID = ID;
//    this.name = name;
//    this.projectSteps = steps;
//    this.scoreTracker = scoreTracker;
//    this.currentStep = 0;
//}

//public Project(string name, List<Step> steps, ScoreTracker scoreTracker)
//{
//    this.name = name;
//    this.projectSteps = steps;
//    this.scoreTracker = scoreTracker;
//}

//public Project(string name, List<Step> steps, float pointsEarnedInProject)
//{
//    this.name = name;
//    this.projectSteps = steps;
//    this.scoreTracker = new ScoreTracker(pointsEarnedInProject);
//}

//public int GetCurrentStepIndex()
//{
//    return currentStep;
//}

//public int GetCurrentStepNumber()
//{
//    return (currentStep + 1);
//}

//public void GoToNextStep()
//{
//    currentStep++;
//}

//public void StartProject()
//{
//    scoreTracker.StartScoreTracking();
//    currentStep = 0;
//}

//public Step GetCurrentStepObject()
//{
//    return projectSteps[currentStep];
//}

//public Step GetStepObject(int index)
//{
//    return projectSteps[index];
//}