using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Base class for a button container that can scroll to show more buttons, if needed.
/// </summary>
public class ScrollingButtonContainer : MonoBehaviour 
{
    public GameObject WoodPieceButton;
    public GameObject ButtonContainer;

    protected int SelectedButtonIndex = -1;
    protected List<GameObject> AvailableButtonsList = new List<GameObject>();

    protected GameObject CreateButton(Sprite iconSprite, string pieceName)
    {
        GameObject button = Instantiate(WoodPieceButton) as GameObject;
        button.transform.SetParent(ButtonContainer.transform);
        button.GetComponent<RectTransform>().localScale = new Vector3(1.0f, 1.0f, 1.0f);

        CustomButtonDisplay display = button.GetComponent<CustomButtonDisplay>();
        if (display != null)
        {
            display.SetIconImage(iconSprite);
            display.SetButtonText(pieceName);
        }

        AvailableButtonsList.Add(button);
        return button;
    }
}
