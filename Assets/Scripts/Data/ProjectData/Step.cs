using System.Collections;
using System;
using UnityEngine;

[System.Serializable]
public class Step 
{
    private float _id;
    private float _associatedProjectID;
    private int _stepNumber;
    private float _pointsToScore;
    private Sprite _planDrawing;
    private string _stepInstructions;
    private string _specificInstructions;
    private string _toolGameplayInstructions;
    private StepCompletionRequirements _completionRequirements;

    public float ID
    {
        get { return _id; }
        private set { _id = value; }
    }

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set { _associatedProjectID = value; }
    }

    public int StepNumber
    {
        get { return _stepNumber; }
        set { _stepNumber = value; }
    }

    public float PointsToScore
    {
        get { return _pointsToScore; }
        private set { _pointsToScore = value; }
    }

    public Sprite PlanDrawing
    {
        get { return _planDrawing; }
        private set { _planDrawing = value; }
    }

    public string StepInstructions
    {
        get { return _stepInstructions; }
        private set { _stepInstructions = value; }
    }

    public string SpecificInstructions
    {
        get { return _specificInstructions; }
        set { _specificInstructions = value; }
    }

    public string ToolGameplayInstructions
    {
        get { return _toolGameplayInstructions; }
        set { _toolGameplayInstructions = value; }
    }

    public StepCompletionRequirements CompletionRequirements
    {
        get { return _completionRequirements; }
        private set { _completionRequirements = value; }
    }

    

    public Step(float id, float projectID, float pointsPossible, Sprite planDrawing, string instructions, StepCompletionRequirements completionRequirements)
    {
        this.ID = id;
        this.AssociatedProjectID = projectID;
        this.PointsToScore = pointsPossible;
        this.PlanDrawing = planDrawing;
        this.StepInstructions = instructions;
        this.CompletionRequirements = completionRequirements;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Step otherStep = (Step)obj;
        if (this.ID != otherStep.ID) return false;
        if (this.AssociatedProjectID != otherStep.AssociatedProjectID) return false;
        if (this.StepNumber != otherStep.StepNumber) return false;
        if (this.PointsToScore != otherStep.PointsToScore) return false;
        if (this.PlanDrawing != otherStep.PlanDrawing) return false;
        if (this.StepInstructions != otherStep.StepInstructions) return false;
        if (this.CompletionRequirements != otherStep.CompletionRequirements) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}



//public ToolType ToolToUse;