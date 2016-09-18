using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProjectCompletionRequirements : AbstractAsset
{
    [SerializeField]
    private float _associatedProjectID;
    [SerializeField]
    private List<float> _stepIDs;

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set { _associatedProjectID = value; }
    }

    public List<float> StepIDs
    {
        get { return _stepIDs; }
        private set { _stepIDs = value; }
    }

    public ProjectCompletionRequirements()
        : base()
    {
        this.AssociatedProjectID = -1f;
        this.StepIDs = new List<float>();
    }

    public ProjectCompletionRequirements(float id)
        : base(id)
    {
        this.AssociatedProjectID = -1f;
        this.StepIDs = new List<float>();
    }

    public ProjectCompletionRequirements(float id, float associatedProjectID, List<float> projectSteps)
        : base(id)
    {
        this.AssociatedProjectID = associatedProjectID;
        if (projectSteps == null)
        {
            this.StepIDs = new List<float>();
        }
        else
        {
            this.StepIDs = projectSteps;
        }
    }

    public Step GetStepByIndex(int stepIndex)
    {
        Step step = null;
        if (stepIndex >= 0 && stepIndex <= StepIDs.Count - 1)
        {
            float id = StepIDs[stepIndex];
            step = StepsDatabase.RetrieveStep(id);
        }
        return step;
    }

    public Step GetStepByID(float stepID)
    {
        Step step = null;
        if (ProjectContainsStep(stepID))
        {
            step = StepsDatabase.RetrieveStep(stepID);
        }
        return step;
    }

    public bool ProjectContainsStep(float stepID)
    {
        return StepIDs.Contains(stepID);
    }
}
