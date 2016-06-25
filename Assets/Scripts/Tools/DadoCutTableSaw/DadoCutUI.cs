using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DadoCutUI : MonoBehaviour 
{
    public GameObject SelectedButton;
    public List<Button> OptionButtons;

    public Button NextButton;
    public Button PreviousButton;
    public Button StartSawButton;
    public Button StopSawButton;

    public GameObject CameraControls;
    public GameObject PlansPanel;
    public GameObject InfoPanel;
    public Text InfoText;
    public Button HideButton;
    public Button StartOverButton;
    public Button NextSceneButton;

    private bool SawButtonsActive = true;

    void Start()
    {
        SelectedButton.GetComponent<Button>().interactable = false;
        PlansPanel.SetActive(false);
        InfoPanel.SetActive(false);
        CameraControls.SetActive(false);
    }

    public void DisplayCameraInstructions(bool showControls)
    {
        CameraControls.SetActive(showControls);
    }

    public void DisplayPlans(bool showPlans)
    {
        PlansPanel.SetActive(showPlans);
    }

    public void DisplayInfo(bool showPlans)
    {
        InfoPanel.SetActive(showPlans);
    }

    public void SwitchActiveButton(GameObject buttonToUse)
    {
        if (buttonToUse != SelectedButton)
        {
            SelectedButton.GetComponent<Button>().interactable = true;

            SelectedButton = buttonToUse;
            SelectedButton.GetComponent<Button>().interactable = false;
        }
    }

    public void ChangeSawButtons(bool bladeIsActive)
    {
        if (SawButtonsActive)
        {
            if (bladeIsActive)
            {
                StartSawButton.interactable = false;
                StopSawButton.interactable = true;
            }
            else
            {
                StartSawButton.interactable = true;
                StopSawButton.interactable = false;
            }
        }
    }

    public void UpdateSelectionButtons(int index, int totalWoodMaterial)
    {
        if (NextButton != null && PreviousButton != null)
        {
            NextButton.interactable = (index < totalWoodMaterial - 1);
            PreviousButton.interactable = (index > 0);
        }
    }

    public void EnableOptions()
    {
        foreach (Button button in OptionButtons)
        {
            button.interactable = true;
        }
        SelectedButton.GetComponent<Button>().interactable = false;
    }

    public void DisableOptions()
    {
        foreach (Button button in OptionButtons)
        {
            button.interactable = false;
        }
    }

    public void EnableAllButtons()
    {
        EnableOptions();
        NextButton.interactable = true;
        PreviousButton.interactable = true;
        StartSawButton.interactable = true;
        StopSawButton.interactable = true;
    }

    public void DisableAllButtons()
    {
        DisableOptions();
        NextButton.interactable = false;
        PreviousButton.interactable = false;
        StartSawButton.interactable = false;
        StopSawButton.interactable = false;
    }

    //public void DisplaySawButtons()
    //{
    //    StartSawButton.gameObject.SetActive(true);
    //    StopSawButton.gameObject.SetActive(true);
    //    RotateClockwiseButton.gameObject.SetActive(false);
    //    RotateCounterClockwiseButton.gameObject.SetActive(false);
    //    ResetRotationButton.gameObject.SetActive(false);
    //    SawButtonsActive = true;
    //}

    //public void DisplayBoardRotationButtons()
    //{
    //    StartSawButton.gameObject.SetActive(false);
    //    StopSawButton.gameObject.SetActive(false);
    //    RotateClockwiseButton.gameObject.SetActive(true);
    //    RotateCounterClockwiseButton.gameObject.SetActive(true);
    //    ResetRotationButton.gameObject.SetActive(true);
    //    SawButtonsActive = false;
    //}
}
