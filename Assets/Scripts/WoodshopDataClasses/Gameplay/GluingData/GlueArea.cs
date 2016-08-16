using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class GlueAreaData : ScriptableObject
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public float TimeToDryInMinutes;
    [SerializeField]
    public List<GluePlaneData> GluingPlanes;
    [SerializeField]
    public SnapPoint AssociatedSnapPoint;
    [SerializeField]
    public Vector3 LocalPosition;
    [SerializeField]
    public Quaternion LocalScale;
}
