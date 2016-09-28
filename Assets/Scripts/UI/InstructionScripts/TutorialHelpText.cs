using UnityEngine;
using System.Collections;

/// <summary>
/// A class containing the text and animation for the tutorials in the game
/// </summary>
[System.Serializable]
public class TutorialHelpText : HelpText
{
    public GestureController gesture;

    public GameObject getGestureObject()
    {
        return gesture.gameObject;
    }
}
