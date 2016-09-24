using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectPanelController : MonoBehaviour
{
    public GameObject ProjectButtonPrefab;

    private List<ProjectButtonUI> projectButtons;

	void Start ()
    {
        List<Project> p = ProjectsDatabase.Instance.RetrieveAllEntities();
        if(ProjectsDatabase.Instance.Count() <= 0)
        {
            Debug.Log("No projects available. Leaving test project.");
        }
        else
        {

        }
    }
}
