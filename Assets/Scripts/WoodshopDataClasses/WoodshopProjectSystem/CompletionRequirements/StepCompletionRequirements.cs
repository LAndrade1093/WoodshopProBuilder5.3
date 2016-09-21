using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum StepCompletionType
{
    None,
    CutAllLines,
    CutAllDados,
    SandPieces,
    GluePieces,
    Clamp,
    Paint
}

[System.Serializable]
public class StepCompletionRequirements<T> : AbstractAsset where T : GameplayEntity
{
    private float _associatedStepID;
    private StepCompletionType _type;
    private List<T> _gameplayEntities;

    public float AssociatedStep
    {
        get { return _associatedStepID; }
        private set { _associatedStepID = value; }
    }

    //public Step AssociatedStep
    //{
    //    get { return StepsDatabase }
    //}

    public StepCompletionType Type
    {
        get { return _type; }
        private set { _type = value; }
    }

    public List<T> GameplayEntities
    {
        get
        {
            if(_gameplayEntities == null)
            {
                _gameplayEntities = new List<T>();
            }
            return _gameplayEntities;
        }
        private set { _gameplayEntities = value; }
    }

    public StepCompletionRequirements()
        : base()
    {
        this.AssociatedStep = -1;
        this.Type = StepCompletionType.None;
    }

    public StepCompletionRequirements(float id)
        : base(id)
    {
        this.AssociatedStep = -1;
        this.Type = StepCompletionType.None;
    }

    public StepCompletionRequirements(float id, float stepID, StepCompletionType type)
        : base(id)
    {
        this.AssociatedStep = stepID;
        this.Type = type;
    }

    public override bool Equals(object obj)
    {
        if (object.ReferenceEquals(this, obj)) return true;
        return EqualsInheritance(obj) && obj.GetType() == typeof(StepCompletionRequirements<T>);
    }

    protected virtual bool EqualsInheritance(object obj)
    {
        if (obj == null || !(obj is StepCompletionRequirements<T>)) return false;

        StepCompletionRequirements<T> otherStepRequirements = (StepCompletionRequirements<T>)obj;

        if (this.AssociatedStep != otherStepRequirements.AssociatedStep) return false;
        if (this.Type != otherStepRequirements.Type) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
