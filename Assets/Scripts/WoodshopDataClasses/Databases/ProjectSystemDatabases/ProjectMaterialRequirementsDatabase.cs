using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// Database for each material requirement for a project
/// </summary>
[System.Serializable]
public class ProjectMaterialRequirementsDatabase : AbstractDatabase<ProjectMaterialRequirements>
{
    private static ProjectMaterialRequirementsDatabase _instance;

    public static ProjectMaterialRequirementsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProjectMaterialRequirementsDatabase();
            }
            return _instance;
        }
    }

    private ProjectMaterialRequirementsDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/ProjectMaterialsRequirement" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
