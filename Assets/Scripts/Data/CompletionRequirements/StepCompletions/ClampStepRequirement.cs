using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ClampStepRequirement : StepCompletionRequirements 
{
    private List<ClampPointData> _clampPoints;

    public List<ClampPointData> ClampPoints
    {
        get { return _clampPoints; }
        private set { _clampPoints = value; }
    }

    public ClampStepRequirement(Step step, StepCompletionType type, List<ClampPointData> clamps)
        : base(step, type)
    {
        if (clamps == null)
        {
            ClampPoints = new List<ClampPointData>();
        }
        else
        {
            ClampPoints = clamps;
        }
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(ClampStepRequirement);
    }

    protected virtual bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is ClampStepRequirement)) return false;

        ClampStepRequirement otherStepRequirements = (ClampStepRequirement)obj;

        if (this.ClampPoints != otherStepRequirements.ClampPoints) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
