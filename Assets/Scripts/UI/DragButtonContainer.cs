using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Container for the drag buttons in the gluing and snapping gameplay
/// </summary>
public class DragButtonContainer : ScrollingButtonContainer
{
    public Transform canvas;
    public GameObject dragIconObject;
    public Color DisabledDragButtonColor = new Color(0.4f, 0.4f, 1f, 0.6f);
    public Vector2 DragIconOffset = new Vector2(0f, 0f);

    public void CreateButton(Sprite iconSprite, string pieceName)
    {
        GameObject button = base.CreateButton(iconSprite, pieceName);
        CreateDraggingIcon(button, iconSprite, pieceName);
    }

    /// <summary>
    /// When a drag button is pressed, a draggable icon is created
    /// </summary>
    /// <param name="button">The button gameobject pressed</param>
    /// <param name="iconSprite">The sprite that will be added to the dragIconObject</param>
    /// <param name="pieceName">A name the icon is associated to</param>
    private void CreateDraggingIcon(GameObject button, Sprite iconSprite, string pieceName)
    {
        GameObject dragIcon = Instantiate(dragIconObject) as GameObject;
        dragIcon.name = pieceName + dragIconObject.name;
        if (canvas != null)
        {
            dragIcon.transform.SetParent(canvas);
            dragIcon.transform.SetAsLastSibling();
        }

        Image iconImage = dragIcon.GetComponent<Image>();
        iconImage.sprite = iconSprite;
        iconImage.color = new Color(1f, 1f, 1f, 1f);
        dragIcon.SetActive(false);

        UIDragButton dragButton = button.GetComponent<UIDragButton>();
        dragButton.SetElementToDrag(dragIcon);
        dragIcon.SetActive(false);
        dragButton.DragOffset = DragIconOffset;
    }

    public bool ContainsButton(GameObject button)
    {
        bool buttonAvailable = false;
        if (button != null)
        {
            buttonAvailable = AvailableButtonsList.Contains(button);
        }
        return buttonAvailable;
    }

    public int IndexOfButton(GameObject button)
    {
        return AvailableButtonsList.IndexOf(button);
    }

    /// <summary>
    /// Disables the UIDragButton at the given index
    /// </summary>
    /// <param name="buttonToDisable">Index of UIDragButton script to disable</param>
    public void DisableButton(int buttonIndex)
    {
        GameObject buttonToDisable = AvailableButtonsList[buttonIndex];
        DisableButton(buttonToDisable.GetComponent<UIDragButton>());
    }

    /// <summary>
    /// Disables the given UIDragButton
    /// </summary>
    /// <param name="buttonToDisable">The UIDragButton script to disable</param>
    public void DisableButton(UIDragButton buttonToDisable)
    {
        UIDragButton button = buttonToDisable.GetComponent<UIDragButton>();
        Destroy(button);
        Image buttonImage = buttonToDisable.GetComponent<Image>();
        buttonImage.color = DisabledDragButtonColor;
        for (int i = 0; i < buttonToDisable.transform.childCount; i++)
        {
            GameObject child = buttonToDisable.transform.GetChild(i).gameObject;
            if (child.GetComponent<Image>() != null)
            {
                Color childImageColor = child.GetComponent<Image>().color;
                child.GetComponent<Image>().color = new Color(childImageColor.r, childImageColor.g, childImageColor.b, DisabledDragButtonColor.a);
            }
            else if (child.GetComponent<Text>() != null)
            {
                Color childTextColor = child.GetComponent<Text>().color;
                child.GetComponent<Text>().color = new Color(childTextColor.r, childTextColor.g, childTextColor.b, DisabledDragButtonColor.a);
            }
        }
    }
}
