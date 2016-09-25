using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class ClampStepRequirement : StepCompletionRequirements
{
    [SerializeField]
    private WoodshopGameplayContainer<ClampPointData> _clampData;

    public WoodshopGameplayContainer<ClampPointData> ClampData
    {
        get { return _clampData; }
        set { _clampData = value; }
    }

    public override float MaxScore
    {
        get { return ClampData.CalculateTotalMaxScore(); }
    }

    public override float MaxScoreFromDatabase
    {
        get
        {
            float total = 0f;
            foreach (ClampPointData s in ClampPointDatabase.Instance.GetDataForAssociatedRequirement(ID))
            {
                total += s.PerfectScore;
            }
            return total;
        }
    }

    public ClampStepRequirement()
        : base()
    {
        ClampData = new WoodshopGameplayContainer<ClampPointData>();
    }

    public ClampStepRequirement(float id)
        : base(id)
    {
        ClampData = new WoodshopGameplayContainer<ClampPointData>();
    }

    public ClampStepRequirement(float id, float projectID, float stepID, StepCompletionType type, WoodshopGameplayContainer<ClampPointData> gameplay)
        : base(id, projectID, stepID, type)
    {
        ClampData = gameplay;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(ClampStepRequirement);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is ClampStepRequirement)) return false;

        ClampStepRequirement otherStepRequirements = (ClampStepRequirement)obj;

        if (this.ClampData != otherStepRequirements.ClampData) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
