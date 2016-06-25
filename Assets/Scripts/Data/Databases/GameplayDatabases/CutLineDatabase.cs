using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class CutLineDatabase : ScriptableObject
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public List<CutLineData> CutLineDataList;
}
