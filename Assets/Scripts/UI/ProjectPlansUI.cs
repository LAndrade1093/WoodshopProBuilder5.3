using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ProjectPlansUI : MonoBehaviour
{
    public GameObject InstructionsPanel;
    public GameObject SideInfoPanel;
    public GameObject ToolsControlsPanel;
    public GameObject CameraControlsPanel;
    public Image ProjectImage;
    public Text StepInstructionsText;
    public Text StepNumberText;

    void Awake()
    {
        ToolsControlsPanel.GetComponent<InformationText>().Initialize();
        CameraControlsPanel.GetComponent<InformationText>().Initialize();
        OpenProjectPlans();
    }

    public void SetStepNumber(int number)
    {
        string numberString = number.ToString();
        StepNumberText.text = "Step " + numberString;
    }

    public void SetStepInstructions(string instructions)
    {
        StepInstructionsText.text = instructions;
    }

    public void DisplayMainPanels()
    {
        HideAllPanels();
        InstructionsPanel.SetActive(true);
        SideInfoPanel.SetActive(true);
    }

    public void DisplayToolsPanel()
    {
        HideAllPanels();
        ToolsControlsPanel.SetActive(true);
    }

    public void DisplayCameraPanel()
    {
        HideAllPanels();
        CameraControlsPanel.SetActive(true);
    }

    public void OpenProjectPlans()
    {
        gameObject.SetActive(true);
        DisplayMainPanels();
    }

    public void CloseProjectPlans()
    {
        HideAllPanels();
        gameObject.SetActive(false);
    }

    private void HideAllPanels()
    {
        InstructionsPanel.SetActive(false);
        SideInfoPanel.SetActive(false);
        ToolsControlsPanel.SetActive(false);
        CameraControlsPanel.SetActive(false);
    }
}
