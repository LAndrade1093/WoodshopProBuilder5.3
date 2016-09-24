using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PaginationDisplay : MonoBehaviour
{
    public Button NextButton;
    public Button PreviousButton;

    protected int currentPageIndex = 0;

    protected virtual void Initilize(int maxPageCount)
    {
        currentPageIndex = 0;
        SetPaginationButtonsState(maxPageCount);
    }

    public virtual void Next()
    {
        currentPageIndex++;
    }

    public virtual void Previous()
    {
        currentPageIndex--;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
    }

    protected void SetPaginationButtonsState(int maxPageCount)
    {
        NextButton.interactable = false;
        PreviousButton.interactable = false;
        if (currentPageIndex > 0)
        {
            PreviousButton.interactable = true;
        }
        if (currentPageIndex < maxPageCount)
        {
            NextButton.interactable = true;
        }
    }
}
