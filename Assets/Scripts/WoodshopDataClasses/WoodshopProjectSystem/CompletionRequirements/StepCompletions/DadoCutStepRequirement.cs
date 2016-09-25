using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class DadoCutStepRequirement : StepCompletionRequirements
{
    [SerializeField]
    private WoodshopGameplayContainer<DadoCutAreaData> _dadoCutData;

    public WoodshopGameplayContainer<DadoCutAreaData> DadoCutData
    {
        get { return _dadoCutData; }
        set { _dadoCutData = value; }
    }
    
    public override float MaxScore
    {
        get
        {
            return DadoCutData.CalculateTotalMaxScore();
        }
    }
    
    public override float MaxScoreFromDatabase
    {
        get
        {
            float total = 0f;
            foreach (DadoCutAreaData s in DadoCutAreaDatabase.Instance.GetDataForAssociatedRequirement(ID))
            {
                total += s.PerfectScore;
            }
            return total;
        }
    }

    public DadoCutStepRequirement()
        : base()
    {
        DadoCutData = new WoodshopGameplayContainer<DadoCutAreaData>();
    }

    public DadoCutStepRequirement(float id)
        : base(id)
    {
        DadoCutData = new WoodshopGameplayContainer<DadoCutAreaData>();
    }

    public DadoCutStepRequirement(float id, float projectID, float stepID, StepCompletionType type, WoodshopGameplayContainer<DadoCutAreaData> gameplay)
        : base(id, projectID, stepID, type)
    {
        DadoCutData = gameplay;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(DadoCutStepRequirement);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is DadoCutStepRequirement)) return false;

        DadoCutStepRequirement otherStepRequirements = (DadoCutStepRequirement)obj;

        if (this.DadoCutData != otherStepRequirements.DadoCutData) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
