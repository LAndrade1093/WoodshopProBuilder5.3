using System.Collections;
using System;
using UnityEngine;

/// <summary>
/// Data for a step within a wood project
/// </summary>
[System.Serializable]
public class Step : AbstractAsset
{
    [SerializeField]
    private float _associatedProjectID;
    [SerializeField]
    private int _stepNumber;
    [SerializeField]
    private ToolType _tool;
    [SerializeField]
    private Sprite _planDrawing;
    [SerializeField]
    private string _stepInstructions;
    [SerializeField]
    private float _stepCompletionRequirementID;

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set { _associatedProjectID = value; }
    }

    public int StepNumber
    {
        get { return _stepNumber; }
        private set { _stepNumber = value; }
    }

    public ToolType Tool
    {
        get { return _tool; }
        private set { _tool = value; }
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
        get { return _stepCompletionRequirementID; }
        private set { _stepCompletionRequirementID = value; }
    }

    public Step()
        : base()
    {
        this.AssociatedProjectID = -1f;
        this.StepNumber = -1;
        this.Tool = ToolType.None;
        this.PlanDrawing = null;
        this.StepInstructions = string.Empty;
        this.StepCompletionRequirementsID = -1f;
    }

    public Step(float id)
        : base(id)
    {
        this.AssociatedProjectID = -1f;
        this.StepNumber = -1;
        this.Tool = ToolType.None;
        this.PlanDrawing = null;
        this.StepInstructions = string.Empty;
        this.StepCompletionRequirementsID = -1f;
    }

    public Step(float id, float projectID, int stepNumber, ToolType type, Sprite planDrawing, string instructions, float stepCompletion)
        : base(id)
    {
        this.AssociatedProjectID = projectID;
        this.StepNumber = stepNumber;
        this.Tool = type;
        this.PlanDrawing = planDrawing;
        this.StepInstructions = instructions;
        this.StepCompletionRequirementsID = stepCompletion;
    }

    public float GetMaxScoreForStep()
    {
        return 0;
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