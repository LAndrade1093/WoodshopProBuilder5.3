using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public abstract class StepCompletionRequirements : AbstractAsset
{
    [SerializeField]
    private float _associatedProjectID;
    [SerializeField]
    private float _associatedStepID;
    [SerializeField]
    private StepCompletionType _type;

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set { _associatedProjectID = value; }
    }

    public float AssociatedStepID
    {
        get { return _associatedStepID; }
        private set { _associatedStepID = value; }
    }

    public StepCompletionType Type
    {
        get { return _type; }
        private set { _type = value; }
    }

    public StepCompletionRequirements()
        : base()
    {
        this.AssociatedProjectID = -1f;
        this.AssociatedStepID = -1f;
        this.Type = StepCompletionType.None;
    }

    public StepCompletionRequirements(float id)
        : base(id)
    {
        this.AssociatedProjectID = -1f;
        this.AssociatedStepID = -1f;
        this.Type = StepCompletionType.None;
    }

    public StepCompletionRequirements(float id, float projectID, float stepID, StepCompletionType type)
        : base(id)
    {
        this.AssociatedProjectID = projectID;
        this.AssociatedStepID = stepID;
        this.Type = type;
    }

    /// <summary>
    /// Use this when the container is loaded in (Usually when the player is working on a project)
    /// </summary>
    public abstract float MaxScore { get; }

    /// <summary>
    /// Use this when getting the max score outside of a project (Container may not be loaded in for the other Property outside of a project)
    /// </summary>
    public abstract float MaxScoreFromDatabase { get; }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(StepCompletionRequirements);
    }

    protected virtual bool EqualsInheritance(object obj)
    {
        if (obj == null || !(obj is StepCompletionRequirements)) return false;

        StepCompletionRequirements otherStepRequirements = (StepCompletionRequirements)obj;
        if (this.AssociatedStepID != otherStepRequirements.AssociatedStepID) return false;
        if (this.Type != otherStepRequirements.Type) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
