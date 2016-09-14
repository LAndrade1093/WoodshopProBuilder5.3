using UnityEngine;
using System.Collections;

/// <summary>
/// The individual planes on a gluing area
/// Used to instantiate the individual sections of a gluing area
/// </summary>
[System.Serializable]
public class GluePlaneData : AbstractAsset
{
    public float AssociatedGlueArea; //Glue area data association
    public Vector3 LocalPosition; //Local position to the associated glue area
    public Vector3 LocalScale; //Local scale to the associated glue area
    public Vector3 LocalEulerRotation; //Local rotation to the associated glue area
}
