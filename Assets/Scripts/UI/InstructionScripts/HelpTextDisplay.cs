using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/// <summary>
/// UI class for UI that displays paginated information
/// </summary>
public class HelpTextDisplay : PaginatedDisplay
{
    public List<HelpText> HelpTextList;

    void Start()
    {
        if(HelpTextList != null)
        {
            HelpTextList = new List<HelpText>();
        }
        if(HelpTextList.Count > 0)
        {
            base.Initilize(ref HelpTextList);
        }
        else
        {
            if (HelpTextList == null) Debug.Log("Help text list is null");
        }
    }

    public void NextHelpText()
    {
        if (HelpTextList.Count > 0)
        {
            base.Next();
            SetText(HelpTextList[currentIndex]);
            SetPaginationButtonsState(ref HelpTextList);
        }
    }

    public void PreviousHelpText()
    {
        if (HelpTextList.Count > 0)
        {
            base.Previous();
            SetText(HelpTextList[currentIndex]);
            SetPaginationButtonsState(ref HelpTextList);
        }
    }
}
