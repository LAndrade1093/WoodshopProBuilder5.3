using UnityEngine;
using System.Collections;

/// <summary>
/// Data for where the clamps are added in the game.
/// Points are not given with these, but they must inherit from GameplayEntity.
/// </summary>
[System.Serializable]
public class ClampPointData : GameplayEntity 
{
    public string PieceNodeID; //The gameobject name of the wood piece this data is associated to (see WoodshopDataClasses/Gameplay/CuttingData/Node class)
    public Vector3 ClampLocalEulerRotation; //Rotation of the clamp when added to the game
    public Vector3 LocalPosition; //Local position of the clamping point to the associated piece
    public Vector3 LocalEulerRotation; //Local rotation of the clamping point to the associated piece
}
