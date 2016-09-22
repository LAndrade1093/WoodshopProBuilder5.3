using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class ProjectsDatabase : AbstractDatabase<Project>
{
    private static ProjectsDatabase _instance;

    public static ProjectsDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProjectsDatabase();
            }
            return _instance;
        }
    }

    private ProjectsDatabase() { }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { "GameCSVData/Projects" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
