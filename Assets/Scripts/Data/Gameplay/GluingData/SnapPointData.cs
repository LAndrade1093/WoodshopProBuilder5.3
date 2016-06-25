using UnityEngine;
using System.Collections;

[System.Serializable]
public class SnapPointData : ScriptableObject
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public WoodPieceData AssociatedPiece;
    [SerializeField]
    public string ConnectionID;
    [SerializeField]
    public Vector3 LocalPosition;
    [SerializeField]
    public Quaternion LocalRotation;
}
