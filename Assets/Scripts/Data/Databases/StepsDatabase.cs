using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StepsDatabase
{
    private static Dictionary<float, Step> projectStepDictionary;

    public static void ValidateDatabase()
    {
        if (projectStepDictionary == null)
        {
            projectStepDictionary = new Dictionary<float, Step>();
        }
    }

    public static void CreateStep(Step step)
    {
        ValidateDatabase();
        if (projectStepDictionary.ContainsKey(step.ID))
        {
            Debug.LogError("Step ID " + step.ID + " is already used. Step was not saved.");
        }
        else
        {
            projectStepDictionary.Add(step.ID, step);
        }
    }

    public static Step RetrieveStep(float stepID)
    {
        ValidateDatabase();
        Step step = null;
        if (projectStepDictionary.ContainsKey(stepID))
        {
            step = projectStepDictionary[stepID];
        }
        return step;
    }

    public static List<Step> RetrieveStepsInProject(float projectID)
    {
        ValidateDatabase();
        List<Step> allSteps = new List<Step>();
        allSteps = projectStepDictionary.Values.Where(x => x.AssociatedProjectID == projectID).ToList();
        return allSteps;
    }

    public static List<Step> RetrieveAllSteps()
    {
        ValidateDatabase();
        List<Step> allSteps = new List<Step>();
        if (projectStepDictionary.Count > 0)
        {
            allSteps = projectStepDictionary.Values.ToList();
        }
        return allSteps;
    }
}









//public static void UpdateStep(Step step)
//{
//    ValidateDatabase();
//    if (!projectStepDictionary.ContainsKey(step.ID))
//    {
//        CreateStep(step);
//    }
//    else
//    {
//        projectStepDictionary[step.ID].PointsToScore = step.PointsToScore;
//        projectStepDictionary[step.ID].PlanDrawing = step.PlanDrawing;
//        projectStepDictionary[step.ID].CompletionInstructions = step.CompletionInstructions;
//        projectStepDictionary[step.ID].CompletionRequirements = step.CompletionRequirements;
//    }
//}

//public static bool DeleteStep(int stepID)
//{
//    ValidateDatabase();
//    bool successful = false;
//    if (projectStepDictionary.ContainsKey(stepID))
//    {
//        successful = projectStepDictionary.Remove(stepID);
//    }
//    return successful;
//}