using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// May not be necessary since the individual wood piece data is saved in a prefab
/// </summary>
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
