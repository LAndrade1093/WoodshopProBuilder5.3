using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CutLineData : ScriptableObject 
{
    [SerializeField]
    public int CutLineID;
    [SerializeField]
    public CutLineType CutType;
    [SerializeField]
    public List<Vector3> Checkpoints;
    [SerializeField]
    public List<GraphEdge> Connections;
    [SerializeField]
    public Vector3 LocalPosition;
    [SerializeField]
    public float LengthOfPieceInInches;
}
