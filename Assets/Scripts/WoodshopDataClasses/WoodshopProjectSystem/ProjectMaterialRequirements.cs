using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Since Unity cannot natively serialize a Dictionary, 
/// this is a simple workaround that will instead store a list of this data class
/// </summary>
[System.Serializable]
public class WoodshopMaterialCount
{
    public float RequiredMaterialID;
    public int AmountRequired;
}

/// <summary>
/// Class that tracks what materials and tools a player needs to work on the associated project
/// To even look at the project though, the player must first unlock and buy the project
/// </summary>
[System.Serializable]
public class ProjectMaterialRequirements : AbstractAsset
{
    [SerializeField]
    private float _associatedProjectID;
    [SerializeField]
    private List<WoodshopMaterialCount> _requiredMaterials;
    [SerializeField]
    private List<float> _requiredToolIDs;

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

    public List<float> RequiredToolIDs
    {
        get { return _requiredToolIDs; }
        private set { _requiredToolIDs = value; }
    }

    public ProjectMaterialRequirements()
        : base()
    {
        AssociatedProjectID = -1f;
        RequiredMaterials = new List<WoodshopMaterialCount>();
        RequiredToolIDs = new List<float>();
    }

    public ProjectMaterialRequirements(float id)
        : base(id)
    {
        AssociatedProjectID = -1f;
        RequiredMaterials = new List<WoodshopMaterialCount>();
        RequiredToolIDs = new List<float>();
    }

    public ProjectMaterialRequirements(float id, float projectID)
        : base(id)
    {
        AssociatedProjectID = projectID;
        RequiredMaterials = new List<WoodshopMaterialCount>();
        RequiredToolIDs = new List<float>();
    }

    public ProjectMaterialRequirements(float id, float projectID, List<WoodshopMaterialCount> requiredMaterials, List<float> requiredTools)
        : base(id)
    {
        AssociatedProjectID = projectID;
        RequiredMaterials = requiredMaterials;
        RequiredToolIDs = requiredTools;
    }

    #region Material Methods
    public void AddMaterialRequirement(float workshopMaterialID, int amountRequired)
    {
        WoodshopMaterialCount newCount = new WoodshopMaterialCount { RequiredMaterialID = workshopMaterialID, AmountRequired = amountRequired };
        if (RequiresWorkshopMaterial(workshopMaterialID))
        {
            WoodshopMaterialCount currentCount = RequiredMaterials.Find(x => x.RequiredMaterialID == workshopMaterialID);
            int index = RequiredMaterials.IndexOf(currentCount);
            RequiredMaterials.Insert(index, newCount);
        }
        else
        {
            RequiredMaterials.Add(newCount);
        }
    }

    public void RemoveMaterialRequirement(float workshopMaterialID)
    {
        if (RequiresWorkshopMaterial(workshopMaterialID))
        {
            WoodshopMaterialCount m = RequiredMaterials.Find(x => x.RequiredMaterialID == workshopMaterialID);
            RequiredMaterials.Remove(m);
        }
    }

    public bool RequiresWorkshopMaterial(float workshopMaterialID)
    {
        WoodshopMaterialCount wsm = RequiredMaterials.Find(x => x.RequiredMaterialID == workshopMaterialID);
        bool found = (wsm != null);
        return found;
    }

    public List<WoodshopMaterialCountData> CheckPlayerMaterials(Inventory playerInventory)
    {
        List<WoodshopMaterialCountData> availableMaterials = new List<WoodshopMaterialCountData>();
        foreach (WoodshopMaterialCount wc in RequiredMaterials)
        {
            WoodshopMaterial wm = MaterialsDatabase.Instance.RetrieveEntity(wc.RequiredMaterialID);
            int amountAvailable = playerInventory.GetMaterialCount(wm.ID);
            availableMaterials.Add(new WoodshopMaterialCountData(wm, amountAvailable, wc.AmountRequired));
        }
        return availableMaterials;
    }

    public bool PlayerHasAllRequiredMaterials(Inventory playerInventory)
    {
        bool hasAllMaterials = true;
        for (int i = 0; i < RequiredMaterials.Count && hasAllMaterials; i++)
        {
            WoodshopMaterialCount wc = RequiredMaterials[i];
            int count = playerInventory.GetMaterialCount(wc.RequiredMaterialID);
            if(count == 0 || count < wc.AmountRequired)
            {
                hasAllMaterials = false;
            }
        }
        return hasAllMaterials;
    }
    #endregion

    #region Tool Methods
    public void AddToolRequirement(float toolID)
    {
        if (!RequiredToolIDs.Contains(toolID))
        {
            RequiredToolIDs.Add(toolID);
        }
    }

    public void RemoveToolRequirement(float toolID)
    {
        if (RequiredToolIDs.Contains(toolID))
        {
            RequiredToolIDs.Remove(toolID);
        }
    }

    public bool RequiresTool(float toolID)
    {
        return RequiredToolIDs.Contains(toolID);
    }

    public List<ToolData> CheckPlayerTools(Inventory playerInventory)
    {
        List<ToolData> toolsAvailable = new List<ToolData>();
        foreach (float toolID in RequiredToolIDs)
        {
            Tool tool = ToolsDatabase.Instance.RetrieveEntity(toolID);
            bool available = playerInventory.ToolIsAvailable(toolID);
            toolsAvailable.Add(new ToolData(tool, available));
        }
        return toolsAvailable;
    }

    public bool PlayerHasAllRequiredTools(Inventory playerInventory)
    {
        bool allToolsAvailable = true;

        for (int i = 0; i < RequiredToolIDs.Count && allToolsAvailable; i++)
        {
            float toolID = RequiredToolIDs[i];
            allToolsAvailable = playerInventory.ToolIsAvailable(toolID);
        }

        return allToolsAvailable;
    }
    #endregion

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        ProjectMaterialRequirements pr = (ProjectMaterialRequirements)obj;
        if (this.AssociatedProjectID != pr.AssociatedProjectID) return false;
        if (this.RequiredMaterials != pr.RequiredMaterials) return false;
        if (this.RequiredToolIDs != pr.RequiredToolIDs) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

/// <summary>
/// Returned by methods in the ProjectRequirements class that bulk check tool availability in the player inventory
/// </summary>
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

/// <summary>
///  Returned by methods in the ProjectRequirements class that bulk check WorkshopMaterial availability in the player inventory
/// </summary>
public class WoodshopMaterialCountData
{
    private WoodshopMaterial _workMaterial;
    private int _amountAvailable;
    private int _amountRequired;

    public WoodshopMaterial WorkMaterial
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

    public WoodshopMaterialCountData(WoodshopMaterial material, int available, int required)
    {
        this.WorkMaterial = material;
        this.AmountAvailable = available;
        this.AmountRequired = required;
    }
}