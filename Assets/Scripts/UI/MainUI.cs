﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/*NOTE:
 * Not all UI classes implement this yet. It was built with the intent of delegating the same
 * UI in a tool scene to one, base class. Anything unique would extend this class. I didn't
 * implement it in all the other classes because UI wasn't supposed to be the main focus 
 * until milestone 4, the vertical slice.
 */

/// <summary>
/// Base class for the main UI in the tool scenes
/// </summary>
public class MainUI : MonoBehaviour 
{
    [Header("Main UI In Every Tool")]
    public Color SelectedButtonColor = new Color(0.35f, 0.55f, 0.24f, 1f);
    public GameObject SelectedButton;
    public List<Button> OptionButtons;

    [Header("Plans to Display For Step")]
    public GameObject PlansPanel;

    [Header("Display Results of Tool")]
    public GameObject ResultsPanel;
    public Text ResultsText;
    public Button StartOverButton;
    public Button NextSceneButton;

    virtual public void Initialize()
    {
        if (OptionButtons.Count > 0)
        {
            //SelectedButton.GetComponent<Image>().color = SelectedButtonColor;
            SelectedButton.GetComponent<Button>().interactable = false;
        }
        DisplayPlans(true);
        ResultsPanel.SetActive(false);
    }

    public void DisplayPlans(bool showPlans)
    {
        PlansPanel.SetActive(showPlans);
        ResultsPanel.SetActive(false);
    }

    public void DisplayResultsPanel(string textToDisplay, bool displayStartOverButton = false, bool displayNextSceneButton = false)
    {
        PlansPanel.SetActive(false);
        ResultsPanel.SetActive(true);
        ResultsText.text = textToDisplay;
        if (StartOverButton != null)
        {
            StartOverButton.gameObject.SetActive(displayStartOverButton);
        }
        if (NextSceneButton != null)
        {
            NextSceneButton.gameObject.SetActive(displayNextSceneButton);
        }
    }

    public void HideResultsPanel()
    {
        ResultsPanel.SetActive(true);
    }

    public void SwitchActiveButton(GameObject buttonToUse)
    {
        if (buttonToUse != SelectedButton && OptionButtons.Count > 0)
        {
            //SelectedButton.GetComponent<Image>().color = Color.white;
            SelectedButton.GetComponent<Button>().interactable = true;

            SelectedButton = buttonToUse;
            //SelectedButton.GetComponent<Image>().color = SelectedButtonColor;
            SelectedButton.GetComponent<Button>().interactable = false;
        }
    }

    protected void EnableOptions()
    {
        foreach (Button button in OptionButtons)
        {
            button.interactable = true;
            //button.GetComponent<Image>().color = Color.white;
        }
        if (SelectedButton != null)
        {
            SelectedButton.GetComponent<Button>().interactable = false;
        }
    }

    protected void DisableOptions()
    {
        foreach (Button button in OptionButtons)
        {
            button.interactable = false;
            //button.GetComponent<Image>().color = Color.white;
        }
    }
}
