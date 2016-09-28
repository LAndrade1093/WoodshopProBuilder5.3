using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* Notes:
 * A simpler version of the PaginatedDisplay class. This is used by the main menu UI for the
 * tools and materials displays. This was meant to replace the PaginatedDisplay class so 
 * that it would be a better abstraction of the pagination controls from what the 
 * implemeting UI
 */

/// <summary>
/// A simpler base class for paginated UI
/// </summary>
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
