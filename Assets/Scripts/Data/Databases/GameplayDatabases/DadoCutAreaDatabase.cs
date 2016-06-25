using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class DadoCutAreaDatabase : ScriptableObject
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public List<DadoCutAreaData> DadoCutDataList;
}
