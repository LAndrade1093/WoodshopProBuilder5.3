using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class ProjectCompletionRequirements
{
    private float _associatedProjectID;
    private List<float> _stepIDs;

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        set { _associatedProjectID = value; }
    }

    public List<float> StepIDs
    {
        get { return _stepIDs; }
        set { _stepIDs = value; }
    }

    public ProjectCompletionRequirements(float associatedPorjectID, List<float> projectSteps)
    {
        this.AssociatedProjectID = associatedPorjectID;
        if (projectSteps == null)
        {
            this.StepIDs = new List<float>();
        }
        else
        {
            this.StepIDs = projectSteps;
        }
    }

    public List<Step> Steps
    {
        get
        {
            List<Step> steps = StepsDatabase.RetrieveStepsInProject(AssociatedProjectID);
            return steps;
        }
    }

    public Step GetStep(int stepIndex)
    {
        float id = StepIDs[stepIndex];
        Step steps = StepsDatabase.RetrieveStep(id);
        return steps;
    }
}
