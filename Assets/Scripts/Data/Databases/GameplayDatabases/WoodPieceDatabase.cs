using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WoodPieceDatabase : ScriptableObject 
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public List<WoodPieceData> pieces;
    [SerializeField]
    public List<WoodLeftoverData> leftovers;
}
