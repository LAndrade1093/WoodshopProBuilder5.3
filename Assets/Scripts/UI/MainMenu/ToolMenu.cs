using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ToolMenu : InventoryDisplay
{
    void Awake ()
    {
        //If data is not available, I default to the test data added through the Editor
        PlayerProfile p = PlayerProfileDatabase.Instance.currentProfile;
        if (p != null)
        {
            Inventory inventory = InventoryDatabase.Instance.GetInventoryByPlayer(p.ID);
            if(inventory != null)
            {
                PlayerInventory = new List<InventoryDataDisplay>();
                foreach (float toolID in inventory.AvailableTools)
                {
                    Tool tool = ToolsDatabase.Instance.RetrieveEntity(toolID);
                    InventoryDataDisplay display = new InventoryDataDisplay { Name = tool.DisplayName, Image = tool.Icon, Available = 1};
                    PlayerInventory.Add(display);
                }
            }
        }

        Initilize(PlayerInventory.Count - 1);
        UpdateDisplay();
    }
}