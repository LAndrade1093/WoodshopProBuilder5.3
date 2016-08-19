using System.Collections;
using System;
using UnityEngine;

[System.Serializable]
public class Step : AbstractAsset
{
    [SerializeField]
    private float _associatedProjectID;
    [SerializeField]
    private int _stepNumber;
    [SerializeField]
    private Sprite _planDrawing;
    [SerializeField]
    private string _stepInstructions;
    [SerializeField]
    private float _stepCompletionRequirementsID;

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

    public float StepCompletionRequirementsID
    {
        get { return _stepCompletionRequirementsID; }
        private set { _stepCompletionRequirementsID = value; }
    }

    public Step()
        : base()
    {
        this.AssociatedProjectID = -1f;
        this.StepNumber = -1;
        this.PlanDrawing = null;
        this.StepInstructions = string.Empty;
        StepCompletionRequirementsID = -1f;
    }

    public Step(float id, float projectID, int stepNumber, Sprite planDrawing, string instructions, float stepCompletionId)
        : base(id)
    {
        this.AssociatedProjectID = projectID;
        this.StepNumber = stepNumber;
        this.PlanDrawing = planDrawing;
        this.StepInstructions = instructions;
        this.StepCompletionRequirementsID = stepCompletionId;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Step otherStep = (Step)obj;
        if (this.ID != otherStep.ID) return false;
        if (this.AssociatedProjectID != otherStep.AssociatedProjectID) return false;
        if (this.StepNumber != otherStep.StepNumber) return false;
        if (this.PlanDrawing != otherStep.PlanDrawing) return false;
        if (this.StepInstructions != otherStep.StepInstructions) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}



//public ToolType ToolToUse;