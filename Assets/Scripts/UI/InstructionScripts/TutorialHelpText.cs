using UnityEngine;
using System.Collections;

[System.Serializable]
public class TutorialHelpText : HelpText
{
    public GestureController gesture;

    public GameObject getGestureObject()
    {
        return gesture.gameObject;
    }
}
