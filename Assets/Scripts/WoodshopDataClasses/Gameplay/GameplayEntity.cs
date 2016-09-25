using UnityEngine;
using System.Collections;

/// <summary>
/// Objects that can affect the final score and sale price
/// </summary>
[System.Serializable]
public class WoodshopGameplayEntity : AbstractAsset
{
    //The gameobject name this data is associated to (see WoodshopDataClasses/Gameplay/CuttingData/Node class)
    //Any extra notes related to how it's used is on the derived classes
    [SerializeField]
    private string _pieceNodeID;
    [SerializeField]
    private float _associatedStepRequirementID;
    [SerializeField]
    private float _perfectScore;
    [SerializeField]
    private float _averageScore;
    [SerializeField]
    private float _poorScore;

    public string PieceNodeID
    {
        get { return _pieceNodeID; }
        private set { _pieceNodeID = value; }
    }

    public float AssociatedStepRequirementID
    {
        get { return _associatedStepRequirementID; }
        private set { _associatedStepRequirementID = value; }
    }

    public float PerfectScore
    {
        get { return _perfectScore; }
        private set { _perfectScore = value; }
    }

    public float AverageScore
    {
        get { return _averageScore; }
        private set { _averageScore = value; }
    }

    public float PoorScore
    {
        get { return _poorScore; }
        private set { _poorScore = value; }
    }

    public WoodshopGameplayEntity()
        : base ()
    {
        PieceNodeID = string.Empty;
        AssociatedStepRequirementID = -1f;
        PerfectScore = 100f;
        AverageScore = 75f;
        PoorScore = 50f;
    }

    public WoodshopGameplayEntity(float id)
        : base(id)
    {
        PieceNodeID = string.Empty;
        AssociatedStepRequirementID = -1f;
        PerfectScore = 100f;
        AverageScore = 75f;
        PoorScore = 50f;
    }

    public WoodshopGameplayEntity(float id, string pieceID, float requirementID, float perfectScore, float averageScore, float poorScore)
        : base(id)
    {
        PieceNodeID = pieceID;
        AssociatedStepRequirementID = requirementID;
        PerfectScore = perfectScore;
        AverageScore = averageScore;
        PoorScore = poorScore;
    }
}
