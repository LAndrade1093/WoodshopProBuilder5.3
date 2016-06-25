using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GlueAreaStepRequirement : StepCompletionRequirements
{
    private List<GlueAreaData> _glueAreas;
    private List<SnapPointData> _snapPoints;

    public List<GlueAreaData> GlueAreas
    {
        get { return _glueAreas; }
        private set { _glueAreas = value; }
    }

    public List<SnapPointData> SnapPoints
    {
        get { return _snapPoints; }
        private set { _snapPoints = value; }
    }

    public GlueAreaStepRequirement(Step step, StepCompletionType type, List<GlueAreaData> glueAreas, List<SnapPointData> snapPoints)
        : base(step, type)
    {
        if (glueAreas == null)
        {
            GlueAreas = new List<GlueAreaData>();
        }
        else
        {
            GlueAreas = glueAreas;
        }

        if (snapPoints == null)
        {
            SnapPoints = new List<SnapPointData>();
        }
        else
        {
            SnapPoints = snapPoints;
        }
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(GlueAreaStepRequirement);
    }

    protected virtual bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is GlueAreaStepRequirement)) return false;

        GlueAreaStepRequirement otherStepRequirements = (GlueAreaStepRequirement)obj;

        if (this.GlueAreas != otherStepRequirements.GlueAreas) return false;
        if (this.SnapPoints != otherStepRequirements.SnapPoints) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
