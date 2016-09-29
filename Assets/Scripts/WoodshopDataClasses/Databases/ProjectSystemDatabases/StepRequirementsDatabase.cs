using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Database for each Step Requirement instance
/// </summary>
[System.Serializable]
public class StepRequirementsDatabase : AbstractDatabase<StepCompletionRequirements>
{
    private static StepRequirementsDatabase _instance;

    public static StepRequirementsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StepRequirementsDatabase();
            }
            return _instance;
        }
    }

    private StepRequirementsDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/StepRequirements" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
