using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Project : AbstractAsset
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _salePrice;
    [SerializeField]
    private float _materialRequirementsID;
    [SerializeField]
    private float _completionRequirementsID;

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

    public float MaterialRequirements
    {
        get { return _materialRequirementsID; }
        private set { _materialRequirementsID = value; }
    }

    public float CompletionRequirements
    {
        get { return _completionRequirementsID; }
        private set { _completionRequirementsID = value; }
    }

    public Project()
        : base()
    {
        this.Name = string.Empty;
        this.SalePrice = -100f;
        this.MaterialRequirements = -1f;
        this.CompletionRequirements = -1f;
    }

    public Project(float id, string name, float salePrice, float requirementsID, float completionID)
        : base(id)
    {
        this.Name = name;
        this.SalePrice = salePrice;
        this.MaterialRequirements = requirementsID;
        this.CompletionRequirements = completionID;
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