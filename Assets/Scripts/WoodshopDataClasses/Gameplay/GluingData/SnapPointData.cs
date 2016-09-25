using UnityEngine;
using System.Collections;

/// <summary>
/// The point at which two pieces are connected together.
/// While it inherits from WoodshopGameplayEntity, it isn't assigned any score.
/// The score is based on the GlueAreas in the same step.
/// </summary>
[System.Serializable]
public class SnapPointData : WoodshopGameplayEntity
{
    public string ConnectionID; //The ID used to determine which other SnapPoint this point connects to
    public Vector3 LocalPosition; //Local position to the associated wood piece
    public Quaternion LocalRotation; //Local rotation to the associated wood piece
}
