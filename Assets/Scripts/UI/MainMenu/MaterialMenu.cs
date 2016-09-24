using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaterialMenu : InventoryDisplay
{
    void Awake()
    {
        //If data is not available, I default to the test data added through the Editor
        PlayerProfile p = PlayerProfileDatabase.Instance.currentProfile;
        if (p != null)
        {
            Inventory inventory = InventoryDatabase.Instance.GetInventoryByPlayer(p.ID);
            if (inventory != null)
            {
                PlayerInventory = new List<InventoryDataDisplay>();
                foreach (float materialID in inventory.AvailableTools)
                {
                    int amount = inventory.GetMaterialCount(materialID);
                    WoodshopMaterial wm = MaterialsDatabase.Instance.RetrieveEntity(materialID);
                    InventoryDataDisplay display = new InventoryDataDisplay { Name = wm.ToString(), Image = wm.Icon, Available = amount };
                    PlayerInventory.Add(display);
                }
            }
        }

        Initilize(PlayerInventory.Count - 1);
        UpdateDisplay();
    }
}