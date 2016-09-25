using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ProjectRequirementsDatabase : AbstractDatabase<ProjectCompletionRequirements>
{
    private static ProjectRequirementsDatabase _instance;

    public static ProjectRequirementsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProjectRequirementsDatabase();
            }
            return _instance;
        }
    }

    private ProjectRequirementsDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/ProjectCompletionRequirement" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}