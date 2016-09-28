using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// The UI controller for the tutorials in the game
/// </summary>
public class TutorialDisplay : PaginatedDisplay
{
    public List<TutorialHelpText> GestureTutorialsList;

    void Awake()
    {
        if (GestureTutorialsList == null)
        {
            GestureTutorialsList = new List<TutorialHelpText>();
        }
        if (GestureTutorialsList.Count > 0)
        {
            foreach (TutorialHelpText gesture in GestureTutorialsList)
            {
                gesture.getGestureObject().SetActive(false);
            }
            List<HelpText> list = GestureTutorialsList.Cast<HelpText>().ToList();
            base.Initilize(ref list);
            Close();
        }
    }

    public override void Close()
    {
        if (GestureTutorialsList.Count > 0)
        {
            GestureTutorialsList[currentIndex].getGestureObject().SetActive(false);
        }
        base.Close();
    }

    public override void Open()
    {
        base.Open();
        EnableCurrentGesture();
    }

    public void NextTutorial()
    {
        if (GestureTutorialsList.Count > 0)
        {
            base.Next();
            List<HelpText> list = GestureTutorialsList.Cast<HelpText>().ToList();
            SetText(list[currentIndex]);
            SetPaginationButtonsState(ref list);
            GestureTutorialsList[currentIndex - 1].getGestureObject().SetActive(false);
            EnableCurrentGesture();
        }
    }

    public void PreviousTutorial()
    {
        if (GestureTutorialsList.Count > 0)
        {
            base.Previous();
            List<HelpText> list = GestureTutorialsList.Cast<HelpText>().ToList();
            SetText(list[currentIndex]);
            SetPaginationButtonsState(ref list);
            GestureTutorialsList[currentIndex + 1].getGestureObject().SetActive(false);
            EnableCurrentGesture();
        }
    }

    private void EnableCurrentGesture()
    {
        if (GestureTutorialsList.Count > 0)
        {
            GestureTutorialsList[currentIndex].getGestureObject().SetActive(true);
            int hash = GestureTutorialsList[currentIndex].gesture.AnimationHash;
            GestureTutorialsList[currentIndex].gesture.Controller.Play(hash, -1, 0f);
        }
    }
}
