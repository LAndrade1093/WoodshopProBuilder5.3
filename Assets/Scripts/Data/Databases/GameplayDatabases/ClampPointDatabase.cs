using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ClampPointDatabase : ScriptableObject 
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public List<ClampPointData> ClampPointList;
}
