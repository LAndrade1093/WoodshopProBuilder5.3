using UnityEngine;
using System.Collections;

/// <summary>
/// The point at which two pieces are connected together
/// </summary>
[System.Serializable]
public class SnapPointData : GameplayEntity
{
    public string PieceNodeID; //The gameobject name of the wood piece this data is associated to (see WoodshopDataClasses/Gameplay/CuttingData/Node class)
    public string ConnectionID; //The ID used to determine which other SnapPoint this point connects to
    public Vector3 LocalPosition; //Local position to the associated wood piece
    public Quaternion LocalRotation; //Local rotation to the associated wood piece
}
