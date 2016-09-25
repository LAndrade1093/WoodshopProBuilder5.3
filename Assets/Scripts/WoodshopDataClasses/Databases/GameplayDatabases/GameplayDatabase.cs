using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Abstract class for databases that store gameplay data.
/// </summary>
/// <typeparam name="T">Concrete type of T must inherit from WoodshopGameplayEntity</typeparam>
[System.Serializable]
public abstract class GameplayDatabase<T> : AbstractDatabase<T> where T : WoodshopGameplayEntity
{
    public List<T> GetDataForAssociatedRequirement(float stepRequirementID)
    {
        List<T> data = Entities.FindAll(x => x.AssociatedStepRequirementID == stepRequirementID);
        return data;
    }

    public List<T> GetDataForAssociatedPiece(string pieceNodeID)
    {
        List<T> data = Entities.FindAll(x => x.PieceNodeID == pieceNodeID);
        return data;
    }
}
