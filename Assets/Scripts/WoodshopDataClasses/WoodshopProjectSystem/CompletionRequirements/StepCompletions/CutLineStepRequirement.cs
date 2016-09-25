using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class CutLineStepRequirement : StepCompletionRequirements
{
    [SerializeField]
    private WoodshopGameplayContainer<CutLineData> _cutLineData;

    public WoodshopGameplayContainer<CutLineData> CutLineData
    {
        get { return _cutLineData; }
        set { _cutLineData = value; }
    }

    public override float MaxScore
    {
        get { return CutLineData.CalculateTotalMaxScore(); }
    }

    public override float MaxScoreFromDatabase
    {
        get
        {
            float total = 0f;
            foreach (CutLineData s in CutLineDatabase.Instance.GetDataForAssociatedRequirement(ID))
            {
                total += s.PerfectScore;
            }
            return total;
        }
    }

    public CutLineStepRequirement()
        : base()
    {
        CutLineData = new WoodshopGameplayContainer<CutLineData>();
    }

    public CutLineStepRequirement(float id)
        : base(id)
    {
        CutLineData = new WoodshopGameplayContainer<CutLineData>();
    }

    public CutLineStepRequirement(float id, float projectID, float stepID, StepCompletionType type, WoodshopGameplayContainer<CutLineData> gameplay)
        : base(id, projectID, stepID, type)
    {
        CutLineData = gameplay;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(CutLineStepRequirement);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is CutLineStepRequirement)) return false;

        CutLineStepRequirement otherStepRequirements = (CutLineStepRequirement)obj;

        if (this.CutLineData != otherStepRequirements.CutLineData) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}