using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Data for a wood project in the game
/// </summary>
[System.Serializable]
public class Project : AbstractAsset
{
    [SerializeField]
    private string _name;
    [SerializeField]
    private float _salePrice; //Max price to sell the project at once complete
    [SerializeField]
    private float _projectPlansPrice; //The price to buy the project from the store
    [SerializeField]
    private float _materialRequirementsID;
    [SerializeField]
    private float _completionRequirementsID;

    public string Name
    {
        get { return _name; }
        private set { _name = value; }
    }

    public float SalePrice
    {
        get { return _salePrice; }
        private set { _salePrice = value; }
    }

    public float ProjectPlansPrice
    {
        get { return _projectPlansPrice; }
        private set { _projectPlansPrice = value; }
    }

    public float MaterialRequirementID
    {
        get { return _materialRequirementsID; }
        private set { _materialRequirementsID = value; }
    }

    public ProjectMaterialRequirements MaterialRequirements
    {
        get { return ProjectMaterialRequirementsDatabase.Instance.RetrieveEntity(MaterialRequirementID); }
    }

    public float CompletionRequirementID
    {
        get { return _completionRequirementsID; }
        private set { _completionRequirementsID = value; }
    }

    public ProjectCompletionRequirements ProjectCompletionRequirements
    {
        get { return ProjectRequirementsDatabase.Instance.RetrieveEntity(CompletionRequirementID); }
    }

    public float TotalProjectScore
    {
        get { return ProjectCompletionRequirements.GetTotalProjectScore(); }
    }

    public float CalculateFinalSalePrice(float scoreAchieved)
    {
        float finalSalePrice = 0f;
        if (scoreAchieved > 0f)
        {
            float temp = scoreAchieved * 100f;
            float scorePercentage = (temp / TotalProjectScore) * 0.01f;
            finalSalePrice = SalePrice * scorePercentage;
        }
        return finalSalePrice;
    }

    public Project()
        : base()
    {
        this.Name = string.Empty;
        this.SalePrice = -100f;
        this.ProjectPlansPrice = -100f;
        this.MaterialRequirementID = -1f;
        this.CompletionRequirementID = -1f;
    }

    public Project(float id, string name, float salePrice, float projectPlansPrice, float requirementsID, float completionID)
        : base(id)
    {
        this.Name = name;
        this.SalePrice = salePrice;
        this.ProjectPlansPrice = projectPlansPrice;
        this.MaterialRequirementID = requirementsID;
        this.CompletionRequirementID = completionID;
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        Project otherProject = (Project)obj;
        if (this.ID != otherProject.ID) return false;
        if (this.Name != otherProject.Name) return false;
        if (this.SalePrice != otherProject.SalePrice) return false;
        if (this.MaterialRequirementID != otherProject.MaterialRequirementID) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}