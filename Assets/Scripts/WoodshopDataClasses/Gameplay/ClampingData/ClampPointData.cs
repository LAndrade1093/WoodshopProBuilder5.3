using UnityEngine;
using System.Collections;

[System.Serializable]
public class ClampPointData : ScriptableObject 
{
    [SerializeField]
    public Vector3 ClampLocalEulerRotation;
    [SerializeField]
    public Vector3 LocalPosition;
    [SerializeField]
    public Vector3 LocalEulerRotation;
    [SerializeField]
    public WoodPieceData AssociatedPiece;
}
