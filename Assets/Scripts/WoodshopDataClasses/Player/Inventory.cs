using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// The player's inventory. Tracks everything the player has with methods to access and manipulate what the player has.
/// </summary>
[System.Serializable]
public class Inventory : AbstractAsset
{
    [SerializeField]
    private float _associatedProfileID;
    [SerializeField]
    private List<WoodshopMaterialCount> _availableMaterials;
    [SerializeField]
    private List<float> _availableTools;
    [SerializeField]
    private float _cash;

    public float AssociatedProfileID
    {
        get { return _associatedProfileID; }
        private set { _associatedProfileID = value; }
    }

    public List<WoodshopMaterialCount> AvailableMaterials
    {
        get { return _availableMaterials; }
        private set { _availableMaterials = value; }
    }

    public List<float> AvailableTools
    {
        get { return _availableTools; }
        private set { _availableTools = value; }
    }

    public float Cash
    {
        get { return _cash; }
    }

    public Inventory() 
        : base()
    {
        this.AssociatedProfileID = -1f;
        this.AvailableMaterials = new List<WoodshopMaterialCount>();
        this.AvailableTools = new List<float>();
        this._cash = -100f;
    }

    public Inventory(float id, float associatedProfileID)
        : base(id)
    {
        this.AssociatedProfileID = associatedProfileID;
        this.AvailableMaterials = new List<WoodshopMaterialCount>();
        this.AvailableTools = new List<float>();
        this._cash = -100f;
    }

    public Inventory(float id, float associatedProfileID, List<WoodshopMaterialCount> availableMaterials, List<float> tools)
        : base(id)
    {
        this.AssociatedProfileID = associatedProfileID;
        this.AvailableMaterials = availableMaterials;
        this.AvailableTools = tools;
        this._cash = -100f;
    }

    public Inventory(float id, float associatedProfileID, List<WoodshopMaterialCount> availableMaterials, List<float> tools, float cash)
        : base(id)
    {
        this.AssociatedProfileID = associatedProfileID;
        this.AvailableMaterials = availableMaterials;
        this.AvailableTools = tools;
        this._cash = cash;
    }

    #region Cash Methods
    public void ApplyCashAmount(float amount)
    {
        _cash += amount;
    }

    public bool EnoughCashIsAvailable(float amountToCheck)
    {
        bool enoughCashAvailable = (Cash >= amountToCheck);
        return enoughCashAvailable;
    }
    #endregion
    
    #region Material Methods
    public bool AddMaterials(float materialID, int amountToAdd)
    {
        if (amountToAdd <= 0)
        {
            Debug.LogError("Amount of materials to add cannot be 0 or less.");
            return false;
        }
        else
        {
            if (MaterialIsAvailable(materialID))
            {
                WoodshopMaterialCount w = AvailableMaterials.Find(x => x.MaterialID == materialID);
                int index = AvailableMaterials.IndexOf(w);
                w.Amount += amountToAdd;
                AvailableMaterials.Insert(index, w);
            }
            else
            {
                WoodshopMaterialCount newCount = new WoodshopMaterialCount { MaterialID = materialID, Amount = amountToAdd };
                AvailableMaterials.Add(newCount);
            }
            return true;
        }
    }

    public bool RemoveMaterial(float materialID, int amountToRemove)
    {
        if (amountToRemove <= 0)
        {
            Debug.LogError("Amount of materials to remove cannot be 0 or less.");
            return false;
        }
        else
        {
            if (MaterialIsAvailable(materialID))
            {
                if (GetMaterialCount(materialID) - amountToRemove < 0)
                {
                    throw new Exception("You don't have enough of this item (ID: " + materialID + ")");
                }
                else
                {
                    WoodshopMaterialCount w = AvailableMaterials.Find(x => x.MaterialID == materialID);
                    w.Amount -= amountToRemove;
                    if (w.Amount == 0)
                    {
                        AvailableMaterials.Remove(w);
                    }
                    return true;
                }
            }
            else
            {
                throw new Exception("You don't have enough of this item (ID: " + materialID + ")");
            }
        }
    }

    public int GetMaterialCount(float materialID)
    {
        int count = 0;
        if (MaterialIsAvailable(materialID))
        {
            WoodshopMaterialCount w = AvailableMaterials.Find(x => x.MaterialID == materialID);
            count = w.Amount;
        }
        return count;
    }

    public List<WoodshopMaterialCount> GetAllAvailableMaterials()
    {
        List<WoodshopMaterialCount> copy = AvailableMaterials;
        return copy;
    }

    public bool MaterialIsAvailable(float materialID)
    {
        WoodshopMaterialCount w = AvailableMaterials.Find(x => x.MaterialID == materialID);
        return (w != null);
    }
    #endregion

    #region Tool Methods
    public void AddTool(float toolID)
    {
        if (!ToolIsAvailable(toolID))
        {
            AvailableTools.Add(toolID);
        }
    }

    public void RemoveTool(float toolID)
    {
        if (AvailableTools.Contains(toolID))
        {
            AvailableTools.Remove(toolID);
        }
    }

    public bool ToolIsAvailable(float toolID)
    {
        return AvailableTools.Contains(toolID);
    }
    #endregion
}