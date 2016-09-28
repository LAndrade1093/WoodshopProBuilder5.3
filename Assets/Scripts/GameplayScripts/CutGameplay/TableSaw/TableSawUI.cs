using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Main UI controller for the UI in the table saw
/// </summary>
public class TableSawUI : MonoBehaviour 
{
    public GameObject SelectedButton;
    public List<Button> OptionButtons;
    public Button NextButton;
    public Button PreviousButton;
    public Button StartSawButton;
    public Button StopSawButton;
    public Button ShowMiterGaugeButton;
    public Button HideMiterGaugeButton;
    public Slider AngleSlider;

    public GameObject PlansPanel;
    public GameObject InfoPanel;
    public Text InfoText;
    public Button HideButton;
    public Button StartOverButton;
    public Button NextSceneButton;

    private bool SawButtonsActive = true;

    void Awake()
    {
        SelectedButton.GetComponent<Button>().interactable = false;
        PlansPanel.SetActive(false);
        InfoPanel.SetActive(false);
    }
    
    public void DisplayPlans(bool showPlans)
    {
        PlansPanel.SetActive(showPlans);
    }

    public void DisplayInfo(bool showPlans)
    {
        InfoPanel.SetActive(showPlans);
    }

    //Disables the button in the top bar that is currently selected
    public void SwitchActiveButton(GameObject buttonToUse)
    {
        if (buttonToUse != SelectedButton)
        {
            SelectedButton.GetComponent<Button>().interactable = true;

            SelectedButton = buttonToUse;
            SelectedButton.GetComponent<Button>().interactable = false;
        }
    }

    //Switches which saw blade buttons are enabled
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

    //Updates the buttons that switch between pieces.
    //Currently though, this UI that uses this is not used in the prototype due to some bugs.
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

    public void DisplaySawButtons()
    {
        StartSawButton.gameObject.SetActive(true);
        StopSawButton.gameObject.SetActive(true);
        SawButtonsActive = true;
    }

    public void DisplayBoardRotationButtons()
    {
        StartSawButton.gameObject.SetActive(false);
        StopSawButton.gameObject.SetActive(false);
        SawButtonsActive = false;
    }

    public void ToggleMiterGaugeControls(bool enableControls)
    {
        AngleSlider.interactable = enableControls;
        if(enableControls)
        {
            ShowMiterGaugeButton.gameObject.SetActive(false);
            HideMiterGaugeButton.gameObject.SetActive(true);
        }
        else
        {
            ShowMiterGaugeButton.gameObject.SetActive(true);
            HideMiterGaugeButton.gameObject.SetActive(false);
        }
    }
}
