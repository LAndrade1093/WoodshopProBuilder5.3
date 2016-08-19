using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class ProjectRequirements : AbstractAsset
{
    [SerializeField]
    private float _associatedProjectID;
    [SerializeField]
    private List<WoodshopMaterialCount> _requiredMaterials;
    [SerializeField]
    private List<Tool> _requiredTools;

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        private set { _associatedProjectID = value; }
    }

    public List<WoodshopMaterialCount> RequiredMaterials
    {
        get { return _requiredMaterials; }
        private set { _requiredMaterials = value; }
    }

    public List<Tool> RequiredTools
    {
        get { return _requiredTools; }
        private set { _requiredTools = value; }
    }

    public ProjectRequirements() 
        : base()
    {
        this.AssociatedProjectID = -1f;
        this.RequiredMaterials = new List<WoodshopMaterialCount>();
        this.RequiredTools = new List<Tool>();
    }

    public ProjectRequirements(float id, float projectID)
        : base(id)
    {
        this.AssociatedProjectID = projectID;
        this.RequiredMaterials = new List<WoodshopMaterialCount>();
        this.RequiredTools = new List<Tool>();
    }

    public ProjectRequirements(float id, float projectID, List<WoodshopMaterialCount> requiredMaterials, List<Tool> requiredTools)
        : base(id)
    {
        this.AssociatedProjectID = projectID;
        this.RequiredMaterials = requiredMaterials;
        this.RequiredTools = requiredTools;
    }

    public bool RequiresWorkshopMaterial(WorkshopMaterial wm)
    {
        return true;
        //return RequiredMaterials.ContainsKey(wm);
    }

    public bool RequiresTool(Tool tool)
    {
        return RequiredTools.Contains(tool);
    }

    public void AddMaterialRequirement(WorkshopMaterial workshopMaterial, int amount)
    {
        //if (RequiredMaterials.ContainsKey(workshopMaterial))
        //{
        //    RequiredMaterials[workshopMaterial] = amount;
        //}
        //else
        //{
        //    RequiredMaterials.Add(workshopMaterial, amount);
        //}
    }

    public void RemoveMaterialRequirement(WorkshopMaterial workshopMaterial)
    {
        //if (RequiredMaterials.ContainsKey(workshopMaterial))
        //{
        //    RequiredMaterials.Remove(workshopMaterial);
        //}
    }

    public void AddToolRequirement(Tool tool)
    {
        if (!RequiredTools.Contains(tool))
        {
            RequiredTools.Add(tool);
        }
    }

    public void RemoveToolRequirement(Tool tool)
    {
        if (RequiredTools.Contains(tool))
        {
            RequiredTools.Remove(tool);
        }
    }

    public bool AllMaterialsAvailable(Inventory playerInventory)
    {
        bool hasAllMaterials = true;

        //foreach (KeyValuePair<WorkshopMaterial, int> mat in RequiredMaterials)
        //{
        //    int count = playerInventory.GetMaterialCount(mat.Key);
        //    if (count == -1 || count < mat.Value)
        //    {
        //        hasAllMaterials = false;
        //        break;
        //    }
        //}

        return hasAllMaterials;
    }

    public bool AllToolsAvailable(Inventory playerInventory)
    {
        bool toolAvailable = true;

        foreach (Tool tool in RequiredTools)
        {
            toolAvailable = playerInventory.ToolIsAvailable(tool);
            if (!toolAvailable)
            {
                break;
            }
        }

        return toolAvailable;
    }

    public List<WorkshopMaterialCountData> CheckMaterials(Inventory playerInventory)
    {
        List<WorkshopMaterialCountData> availableMaterials = new List<WorkshopMaterialCountData>();
        //foreach (KeyValuePair<WorkshopMaterial, int> mat in _requiredMaterials)
        //{
        //    int required = mat.Value;
        //    int available = playerInventory.GetMaterialCount(mat.Key);
        //    availableMaterials.Add(new WorkshopMaterialCountData(mat.Key, available, required));
        //}
        return availableMaterials;
    }

    public List<ToolData> CheckTools(Inventory playerInventory)
    {
        List<ToolData> toolAvailable = new List<ToolData>();
        foreach (Tool tool in RequiredTools)
        {
            bool available = playerInventory.ToolIsAvailable(tool);
            toolAvailable.Add(new ToolData(tool, available));
        }
        return toolAvailable;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        ProjectRequirements pr = (ProjectRequirements)obj;
        if (this.AssociatedProjectID != pr.AssociatedProjectID) return false;
        if (this.RequiredMaterials != pr.RequiredMaterials) return false;
        if (this.RequiredTools != pr.RequiredTools) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public class ToolData
{
    private Tool _toolToCheck;
    private bool _available;

    public Tool ToolToCheck
    {
        get { return _toolToCheck; }
        private set { _toolToCheck = value; }
    }

    public bool AmountAvailable
    {
        get { return _available; }
        private set { _available = value; }
    }

    public ToolData(Tool tool, bool available)
    {
        this.ToolToCheck = tool;
        this.AmountAvailable = available;
    }
}


public class WorkshopMaterialCountData
{
    private WorkshopMaterial _workMaterial;
    private int _amountAvailable;
    private int _amountRequired;

    public WorkshopMaterial WorkMaterial
    {
        get { return _workMaterial; }
        private set { _workMaterial = value; }
    }

    public int AmountAvailable
    {
        get { return _amountAvailable; }
        private set { _amountAvailable = value; }
    }

    public int AmountRequired
    {
        get { return _amountRequired; }
        private set { _amountRequired = value; }
    }

    public bool RequirementMet
    {
        get
        {
            return AmountAvailable >= AmountRequired;
        }
    }

    public WorkshopMaterialCountData(WorkshopMaterial material, int available, int required)
    {
        this.WorkMaterial = material;
        this.AmountAvailable = available;
        this.AmountRequired = required;
    }
}

[System.Serializable]
public class WoodshopMaterialCount
{
    public float RequiredMaterialID;
    public int NumberRequired;
}






//ID = nextID++;
//public float ID
//{
//    get { return _id; }
//    private set { _id = value; }
//}