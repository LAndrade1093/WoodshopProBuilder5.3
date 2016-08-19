using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Inventory : AbstractAsset
{
    [SerializeField]
    private float _associatedProfileID;
    [SerializeField]
    private List<WoodshopMaterialCount> _availableMaterials;
    [SerializeField]
    private List<Tool> _availableTools;
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

    public List<Tool> AvailableTools
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
        this.AvailableTools = new List<Tool>();
        this._cash = -100f;
    }

    public Inventory(float id, float associatedProfileID)
        : base(id)
    {
        this.AssociatedProfileID = associatedProfileID;
        this.AvailableMaterials = new List<WoodshopMaterialCount>();
        this.AvailableTools = new List<Tool>();
        this._cash = -100f;
    }

    public Inventory(float id, float associatedProfileID, List<WoodshopMaterialCount> availableMaterials, List<Tool> tools)
        : base(id)
    {
        this.AssociatedProfileID = associatedProfileID;
        this.AvailableMaterials = availableMaterials;
        this.AvailableTools = tools;
        this._cash = -100f;
    }

    public Inventory(float id, float associatedProfileID, List<WoodshopMaterialCount> availableMaterials, List<Tool> tools, float cash)
        : base(id)
    {
        this.AssociatedProfileID = associatedProfileID;
        this.AvailableMaterials = availableMaterials;
        this.AvailableTools = tools;
        this._cash = cash;
    }

    #region Cash Methods
    public void AddCash(float amount)
    {
        _cash += amount;
    }

    public MethodResult RemoveCash(float amount)
    {
        MethodResult result = new MethodResult(successful: true);
        if (Cash - amount < 0f)
        {
            result = new MethodResult("You don't have enough cash!", false, ErrorType.NegativeCashAmountResult);
        }
        else
        {
            _cash -= amount;
        }
        return result;
    }
    #endregion

    #region Material Methods
    public MethodResult AddMaterials(WorkshopMaterial material, int amountToAdd = 1)
    {
        MethodResult result = new MethodResult();
        //if (amountToAdd < 0)
        //{
        //    result = new MethodResult(successful: false, error: ErrorType.NegativeCashAmountResult);
        //    Debug.LogError("Amount of materials to add cannot be negative.");
        //}
        //else
        //{
        //    if (AvailableMaterials.ContainsKey(material))
        //    {
        //        AvailableMaterials[material] = AvailableMaterials[material] + amountToAdd;
        //    }
        //    else
        //    {
        //        AvailableMaterials.Add(material, amountToAdd);
        //    }
        //    result = new MethodResult(successful: true);
        //    return result;
        //}
        return result;
    }

    public MethodResult RemoveMaterial(WorkshopMaterial material, int amountToRemove = 1)
    {
        MethodResult result = new MethodResult();
        //if (amountToRemove < 0)
        //{
        //    result = new MethodResult(successful: false, error: ErrorType.NegativeCashAmountResult);
        //    Debug.LogError("Technically, the amount of materials to remove cannot be negative.");
        //}
        //else
        //{
        //    if (AvailableMaterials.ContainsKey(material))
        //    {
        //        if (AvailableMaterials[material] - amountToRemove < 0)
        //        {
        //            result = new MethodResult(message: "You don't have enough of this item (" + material.Name + ")", successful: false, error: ErrorType.NotEnoughMaterialsAvailable);
        //        }
        //        else
        //        {
        //            AvailableMaterials[material] = AvailableMaterials[material] - amountToRemove;
        //            if (AvailableMaterials[material] == 0)
        //            {
        //                AvailableMaterials.Remove(material);
        //                result = new MethodResult(message:"You're now out of "+material.Name+". Get some more at the store.", successful: true);
        //            }
        //            else
        //            {
        //                result = new MethodResult(message: material.Name + " remaining: " + AvailableMaterials[material]);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        result = new MethodResult(message: "You don't have this item (" + material.Name + ")", successful: false, error: ErrorType.MaterialNotAvailable);
        //    }
        //}
        return result;
    }

    public int GetMaterialCount(WorkshopMaterial material)
    {
        //if (AvailableMaterials.ContainsKey(material))
        //{
        //    return AvailableMaterials[material];
        //}
        //else
        //{
            return 0;
        //}
    }

    public List<WoodshopMaterialCount> GetAllAvailableMaterials()
    {
        List<WoodshopMaterialCount> materials = new List<WoodshopMaterialCount>();
        //foreach (KeyValuePair<WorkshopMaterial, int> materialCount in AvailableMaterials)
        //{
        //    materials.Add(new GameMaterialStorage(materialCount.Key, materialCount.Value));
        //}
        return materials;
    }

    public bool MaterialIsAvailable(WorkshopMaterial material)
    {
        return true;// AvailableMaterials.ContainsKey(material);
    }
    #endregion

    #region Tool Methods
    public MethodResult AddTool(Tool tool)
    {
        MethodResult result;
        if (!AvailableTools.Contains(tool))
        {
            AvailableTools.Add(tool);
            result = new MethodResult(successful: true);
        }
        else
        {
            result = new MethodResult("You already have a " + tool.DisplayName, false, ErrorType.ToolCantBeAdded);
        }
        return result;
    }

    public MethodResult RemoveTool(Tool tool)
    {
        MethodResult result;
        if (AvailableTools.Contains(tool))
        {
            AvailableTools.Remove(tool);
            result = new MethodResult(successful: true);
        }
        else
        {
            result = new MethodResult("You don't have a " + tool.DisplayName, false, ErrorType.ToolCantBeRemoved);
        }
        return result;
    }

    public bool ToolIsAvailable(Tool tool)
    {
        return AvailableTools.Contains(tool);
    }
    #endregion
}