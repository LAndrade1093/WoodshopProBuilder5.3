using UnityEngine;
using System.Collections;

public enum StepCompletionType
{
    CutAllLines,
    CutAllDados,
    SandPieces,
    GluePieces,
    Clamp,
    Paint
}

[System.Serializable]
public class StepCompletionRequirements
{
    private Step _associatedStep;
    private StepCompletionType _type;

    public Step AssociatedStep
    {
        get { return _associatedStep; }
        private set { _associatedStep = value; }
    }

    public StepCompletionType Type
    {
        get { return _type; }
        private set { _type = value; }
    }

    public StepCompletionRequirements(Step step, StepCompletionType type)
    {
        this.AssociatedStep = step;
        this.Type = type;
    }

    public StepCompletionRequirements(float stepID, StepCompletionType type)
    {
        this.AssociatedStep = StepsDatabase.RetrieveStep(stepID);
        this.Type = type;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(StepCompletionRequirements);
    }

    protected virtual bool EqualsInheritance(object obj)
    {
        if (obj == null || !(obj is StepCompletionRequirements)) return false;

        StepCompletionRequirements otherStepRequirements = (StepCompletionRequirements)obj;

        if (this.AssociatedStep != otherStepRequirements.AssociatedStep) return false;
        if (this.Type != otherStepRequirements.Type) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
