using UnityEngine;
using System.Collections;

/// <summary>
/// This is a prototype and test script. The id is saved in GameplayEntity classes, so once 
/// data can be loaded in from databases, this can be deleted and replaced by the date in the Step and StepCompletionRequirements classes
/// </summary>
public class StepID : MonoBehaviour 
{
    public int StepNumber;

    public bool UsedInStep(int stepNumber)
    {
        return (StepNumber == stepNumber);
    }
}
