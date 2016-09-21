using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CutLineStepRequirement// : StepCompletionRequirements
{
    //private List<CutLineData> _linesToCut;

    //public List<CutLineData> LinesToCut
    //{
    //    get { return _linesToCut; }
    //    private set { _linesToCut = value; }
    //}

    //public CutLineStepRequirement(Step step, StepCompletionType type, List<CutLineData> lines)
    //    : base(step, type)
    //{
    //    if (lines == null)
    //    {
    //        LinesToCut = new List<CutLineData>();
    //    }
    //    else
    //    {
    //        LinesToCut = lines;
    //    }
    //}

    //public override bool Equals(object obj)
    //{
    //    if (object.ReferenceEquals(this, obj)) return true;
    //    return EqualsInheritance(obj) && obj.GetType() == typeof(CutLineStepRequirement);
    //}

    //protected virtual bool EqualsInheritance(object obj)
    //{
    //    if (!base.EqualsInheritance(obj)) return false;
    //    if (obj == null || !(obj is CutLineStepRequirement)) return false;

    //    CutLineStepRequirement otherStepRequirements = (CutLineStepRequirement)obj;

    //    if (this.LinesToCut != otherStepRequirements.LinesToCut) return false;

    //    return true;
    //}

    //public override int GetHashCode()
    //{
    //    return base.GetHashCode();
    //}
}