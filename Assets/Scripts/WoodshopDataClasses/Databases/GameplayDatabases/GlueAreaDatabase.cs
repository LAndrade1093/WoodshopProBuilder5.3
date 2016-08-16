using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GlueAreaDatabase : ScriptableObject 
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public List<GlueAreaData> GlueAreaDataList;
}
