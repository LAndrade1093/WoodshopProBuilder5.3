using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ProjectsDatabase 
{
    private static Dictionary<float, Project> gameProjectsDictionary = null;

    public static void ValidateDatabase()
    {
        if (gameProjectsDictionary == null)
        {
            gameProjectsDictionary = new Dictionary<float, Project>();
        }
    }

    public static void AddProject(Project project)
    {
        ValidateDatabase();
        if (ProjectsDatabase.Contains(project))
        {
            Debug.LogError("Project ID \"" + project.ID + "\" is already in the database. Project was not saved.");
        }
        else
        {
            gameProjectsDictionary.Add(project.ID, project);
        }
    }

    public static Project RetrieveProject(float projectID)
    {
        ValidateDatabase();
        Project project = null;
        if (ProjectsDatabase.Contains(projectID))
        {
            project = gameProjectsDictionary[projectID];
        }
        else
        {
            Debug.LogError("The project id \"" + projectID + "\" was not in the database.");
        }
        return project;
    }

    public static List<Project> RetrieveAllProjects()
    {
        ValidateDatabase();
        List<Project> allProjects = new List<Project>();
        if (gameProjectsDictionary.Count > 0)
        {
            allProjects = gameProjectsDictionary.Values.ToList();
        }
        return allProjects;
    }

    public static bool Contains(float projectID)
    {
        return gameProjectsDictionary.ContainsKey(projectID);
    }

    public static bool Contains(Project project)
    {
        return Contains(project.ID);
    }
}
