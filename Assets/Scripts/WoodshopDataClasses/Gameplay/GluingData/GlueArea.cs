using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The data for the areas on the wood pieces that need gluing
/// </summary>
[System.Serializable]
public class GlueAreaData : WoodshopGameplayEntity
{
    //ID of the SnapPoint that is displayed when enough glue is added
    //Every GlueArea has a SnapPoint, but not every SnapPoint has a GlueArea
    public float AssociatedSnapPointID; 
    public float TimeToDryInMinutes; //Time to dry area (will be combined with other glue areas)
    public Vector3 LocalPosition; //Local position to the associated piece
    public Vector3 LocalScale; //Local scale to the associated piece
    public Vector3 LocalEulerRotation; //Local rotation to the associated piece
    public List<GluePlaneData> GluingPlanes; //The surfaces this gluing area affects
}
