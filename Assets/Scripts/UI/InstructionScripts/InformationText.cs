﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/* Notes:
 * This was created before the PaginationDisplay class was made, but I never got around to implementing it
 * here. There is no rush to do so, but it would be a good idea to do so for consistency
 */

/// <summary>
/// A UI controller for Ui that displays controls and other helpful info.
/// </summary>
public class InformationText : MonoBehaviour
{
    public Text InfoTextDisplay;
    public Button NextButton;
    public Button PreviousButton;
    public Text PageNumber;
    [TextArea(3, 10)]
    public List<string> InformationList;

    private int CurrentIndex = 0;

    void Awake()
    {
        Initialize();
    }

    public void Initialize()
    {
        CurrentIndex = 0;
        if (InformationList != null)
        {
            if (InformationList.Count > 0)
            {
                SetText();
                SetPaginationButtonsState();
            }
        }
    }

    public void Next()
    {
        CurrentIndex++;
        SetText();
        SetPaginationButtonsState();
    }

    public void Previous()
    {
        CurrentIndex--;
        SetText();
        SetPaginationButtonsState();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    private void SetText()
    {
        InfoTextDisplay.text = InformationList[CurrentIndex];
        PageNumber.text = "Page " + (CurrentIndex + 1) + " of " + InformationList.Count;
    }

    private void SetPaginationButtonsState()
    {
        if (InformationList != null)
        {
            NextButton.interactable = false;
            PreviousButton.interactable = false;
            if (CurrentIndex > 0)
            {
                PreviousButton.interactable = true;
            }
            if (CurrentIndex < (InformationList.Count - 1) )
            {
                NextButton.interactable = true;
            }
        }
        else
        {
            NextButton.interactable = false;
            PreviousButton.interactable = false;
        }
    }
}
