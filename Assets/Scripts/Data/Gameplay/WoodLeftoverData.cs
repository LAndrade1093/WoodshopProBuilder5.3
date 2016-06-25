using UnityEngine;
using System.Collections;

[System.Serializable]
public class WoodLeftoverData : ScriptableObject
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public Vector3 LocalPositionToBoard;
    [SerializeField]
    public Vector3 LocalRotationToBoard;
    [SerializeField]
    public Vector3 Scale;
    [SerializeField]
    public GameObject PieceGameObject;
}
