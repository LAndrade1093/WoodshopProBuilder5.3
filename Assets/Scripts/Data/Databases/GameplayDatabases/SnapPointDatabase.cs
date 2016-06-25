using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SnapPointDatabase : ScriptableObject 
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public List<SnapPointData> SnapPointDataList;
}
