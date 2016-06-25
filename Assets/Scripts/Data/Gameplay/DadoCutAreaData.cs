using UnityEngine;
using System.Collections;

[System.Serializable]
public class DadoCutAreaData : ScriptableObject 
{
    [SerializeField]
    public float NumberOfCuts;
    [SerializeField]
    public Vector3 LocalPosition;
    [SerializeField]
    public Vector3 LocalScale;
    [SerializeField]
    public Quaternion LocalRotation;
}
