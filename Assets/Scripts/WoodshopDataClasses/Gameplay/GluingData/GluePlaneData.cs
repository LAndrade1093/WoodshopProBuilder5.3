using UnityEngine;
using System.Collections;

[System.Serializable]
public class GluePlaneData
{
    [SerializeField]
    public GlueAreaData ParentGlueArea;
    [SerializeField]
    public Vector3 LocalPosition;
    [SerializeField]
    public Quaternion LocalScale;
}
