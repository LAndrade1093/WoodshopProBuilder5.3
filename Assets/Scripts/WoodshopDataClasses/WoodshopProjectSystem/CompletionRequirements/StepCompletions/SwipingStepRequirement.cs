using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class SwipingStepRequirement : StepCompletionRequirements
{
    [SerializeField]
    private WoodshopGameplayContainer<SwipingData> _swipingData;

    public WoodshopGameplayContainer<SwipingData> SwipingData
    {
        get { return _swipingData; }
        set{ _swipingData = value; }
    }

    public override float MaxScore
    {
        get { return SwipingData.CalculateTotalMaxScore(); }
    }

    public override float MaxScoreFromDatabase
    {
        get
        {
            float total = 0f;
            foreach(SwipingData s in SwipingDatabase.Instance.GetDataForAssociatedRequirement(ID))
            {
                total += s.PerfectScore;
            }
            return total;
        }
    }

    public SwipingStepRequirement()
        : base()
    {
        SwipingData = new WoodshopGameplayContainer<SwipingData>();
    }

    public SwipingStepRequirement(float id)
        : base(id)
    {
        SwipingData = new WoodshopGameplayContainer<SwipingData>();
    }

    public SwipingStepRequirement(float id, float projectID, float stepID, StepCompletionType type, WoodshopGameplayContainer<SwipingData> gameplay)
        : base(id, projectID, stepID, type)
    {
        SwipingData = gameplay;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(SwipingStepRequirement);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is SwipingStepRequirement)) return false;

        SwipingStepRequirement otherStepRequirements = (SwipingStepRequirement)obj;

        if (this.SwipingData != otherStepRequirements.SwipingData) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
