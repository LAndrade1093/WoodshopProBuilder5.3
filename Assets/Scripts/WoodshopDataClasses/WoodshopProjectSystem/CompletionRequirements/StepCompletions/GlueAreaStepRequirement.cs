using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class GlueAreaStepRequirement : StepCompletionRequirements
{
    [SerializeField]
    private WoodshopGameplayContainer<GlueAreaData> _glueData;
    [SerializeField]
    private WoodshopGameplayContainer<SnapPointData> _snapPoints;

    public WoodshopGameplayContainer<GlueAreaData> GlueData
    {
        get { return _glueData; }
        set { _glueData = value; }
    }

    public WoodshopGameplayContainer<SnapPointData> SnapPoints
    {
        get { return _snapPoints; }
        set { _snapPoints = value; }
    }

    public override float MaxScore
    {
        get { return GlueData.CalculateTotalMaxScore(); }
    }

    public override float MaxScoreFromDatabase
    {
        get
        {
            float total = 0f;
            foreach (GlueAreaData s in GlueAreaDatabase.Instance.GetDataForAssociatedRequirement(ID))
            {
                total += s.PerfectScore;
            }
            return total;
        }
    }
    
    public GlueAreaStepRequirement()
        : base()
    {
        GlueData = new WoodshopGameplayContainer<GlueAreaData>();
        SnapPoints = new WoodshopGameplayContainer<SnapPointData>();
    }

    public GlueAreaStepRequirement(float id)
        : base(id)
    {
        GlueData = new WoodshopGameplayContainer<GlueAreaData>();
        SnapPoints = new WoodshopGameplayContainer<SnapPointData>();
    }

    public GlueAreaStepRequirement(float id, float projectID, float stepID, StepCompletionType type, WoodshopGameplayContainer<GlueAreaData> glueData, WoodshopGameplayContainer<SnapPointData> snapPoints)
        : base(id, projectID, stepID, type)
    {
        GlueData = glueData;
        SnapPoints = snapPoints;
    }

    public float CalculateTotalDryTime()
    {
        float totalDryTime = 0f;
        foreach (GlueAreaData s in GlueAreaDatabase.Instance.GetDataForAssociatedRequirement(ID))
        {
            totalDryTime += s.TimeToDryInMinutes;
        }
        return totalDryTime;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(GlueAreaStepRequirement);
    }

    protected override bool EqualsInheritance(object obj)
    {
        if (!base.EqualsInheritance(obj)) return false;
        if (obj == null || !(obj is GlueAreaStepRequirement)) return false;

        GlueAreaStepRequirement otherStepRequirements = (GlueAreaStepRequirement)obj;

        if (this.GlueData != otherStepRequirements.GlueData) return false;
        if (this.SnapPoints != otherStepRequirements.SnapPoints) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
