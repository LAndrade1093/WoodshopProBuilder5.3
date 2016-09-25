using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

[System.Serializable]
public class StepsDatabase : AbstractDatabase<Step>
{
    private static StepsDatabase _instance;

    public static StepsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StepsDatabase();
            }
            return _instance;
        }
    }

    private StepsDatabase() { }

    public static List<Step> RetrieveStepsInProject(float projectID)
    {
        List<Step> allSteps = new List<Step>();
        allSteps = Instance.Entities.FindAll(x => x.AssociatedProjectID == projectID);
        return allSteps;
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/Steps" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}