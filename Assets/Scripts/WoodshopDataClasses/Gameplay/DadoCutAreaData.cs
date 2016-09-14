using UnityEngine;
using System.Collections;

/// <summary>
/// The dados that will be cut out
/// </summary>
[System.Serializable]
public class DadoCutAreaData : GameplayEntity 
{
    public string PieceNodeID; //The gameobject name of the dado this data is associated to (see WoodshopDataClasses/Gameplay/CuttingData/Node class)
    public float NumberOfCuts; //Number of cuts to make before the dado is completely cut
}
