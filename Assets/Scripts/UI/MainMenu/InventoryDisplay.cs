using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Base class for any UI that displays stuff from the player's Inventory
/// </summary>
public class InventoryDisplay : PaginationDisplay
{
    public Text DescriptionText;
    public Image SpriteDisplay;
    public Text AvailabilityText;
    public List<InventoryDataDisplay> PlayerInventory;

    public virtual void UpdateDisplay()
    {
        if(DescriptionText != null)
            DescriptionText.text = PlayerInventory[currentPageIndex].Name;
        if (SpriteDisplay != null)
            SpriteDisplay.sprite = PlayerInventory[currentPageIndex].Image;
        if (AvailabilityText != null)
            AvailabilityText.text = PlayerInventory[currentPageIndex].Available.ToString() + " available";
        SetPaginationButtonsState(PlayerInventory.Count - 1);
    }
}

[System.Serializable]
public class InventoryDataDisplay
{
    public string Name;
    public Sprite Image;
    public int Available;
}

