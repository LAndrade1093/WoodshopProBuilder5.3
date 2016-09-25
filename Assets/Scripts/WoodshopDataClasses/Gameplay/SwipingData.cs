using UnityEngine;
using System.Collections;

/// <summary>
/// The data used for the painting, sanding, and shine gameplay
/// </summary>
[System.Serializable]
public class SwipingData : WoodshopGameplayEntity
{
    public SwipeGameType SwipingGameplayType; //Used to determine if the player is painting, sanding, or adding shine in the swiping gameplay
}
