using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PaginatedDisplay: MonoBehaviour
{
    public Text TitleText;
    public Text InfoText;
    public Button NextButton;
    public Button PreviousButton;

    protected int currentIndex = 0;

    virtual protected void Initilize(ref List<HelpText> list)
    {
        currentIndex = 0;
        if (list.Count > 0)
        { 
            SetText(list[currentIndex]);
            SetPaginationButtonsState(ref list);
        }
    }

    virtual protected void Next()
    {
        currentIndex++;
    }

    virtual protected void Previous()
    {
        currentIndex--;
    }

    virtual public void Close()
    {
        gameObject.SetActive(false);
    }

    virtual public void Open()
    {
        gameObject.SetActive(true);
    }

    protected void SetText(HelpText text)
    {
        TitleText.text = text.Title;
        InfoText.text = text.Info;
    }

    protected void SetPaginationButtonsState(ref List<HelpText> list)
    {
        NextButton.interactable = false;
        PreviousButton.interactable = false;

        if (list != null)
        {
            NextButton.interactable = false;
            PreviousButton.interactable = false;
            if (currentIndex > 0)
            {
                PreviousButton.interactable = true;
            }
            if (currentIndex < (list.Count - 1))
            {
                NextButton.interactable = true;
            }
        }
    }
}
