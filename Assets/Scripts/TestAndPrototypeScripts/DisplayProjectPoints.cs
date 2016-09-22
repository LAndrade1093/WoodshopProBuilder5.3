using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class DisplayProjectPoints : MonoBehaviour 
{
    public int numberOfStepsToCreate;
    public float pointsPerStep;
    public Text textDisplay;

    private Project projectToDisplay;
    private float totalPoints;
    string pointsText = "Total Project Points: 000/";

	void Start () 
    {
        //projectToDisplay = new Project();
        //totalPoints = 0f;
        //projectToDisplay.projectSteps = new List<Step>();
        //for (int i = 0; i < numberOfStepsToCreate; i++)
        //{
        //    Step newStep = new Step();
        //    newStep.pointsToScore = pointsPerStep;
        //    projectToDisplay.projectSteps.Add(newStep);
        //    totalPoints += pointsPerStep;
        //}
        //textDisplay.text = pointsText + totalPoints;
	}

    void OnDisable()
    {
        textDisplay.text = pointsText + "000";
    }
}
