using UnityEngine;
using System.Collections;

/* NOTES:
 * This is a class meant to track what projects have been purchased and unlocked for an 
 * associated player. Every player must have a link to a project so that we know what 
 * projects they have access to. Also, this is data that should be saved to a binary 
 * file on the user's phone.
 */

/// <summary>
/// A link class between a player and a project.
/// </summary>
[System.Serializable]
public class PlayerProjectLink : AbstractAsset
{
    private float _associatedProjectID;
    private float _associatedPlayerProfileID;
    private bool _projectUnlocked;
    private bool _projectPurchased;

    public float AssociatedProjectID
    {
        get { return _associatedProjectID; }
        set { _associatedProjectID = value; }
    }

    public float AssociatedPlayerProfileID
    {
        get { return _associatedPlayerProfileID; }
        set { _associatedPlayerProfileID = value; }
    }

    public bool ProjectUnlocked
    {
        get { return _projectUnlocked; }
        private set { _projectUnlocked = value; }
    }

    public bool ProjectPurchased
    {
        get { return _projectPurchased; }
        private set { _projectPurchased = value; }
    }

    public PlayerProjectLink() 
        : base()
    {
        AssociatedProjectID = -1f;
        AssociatedPlayerProfileID = -1f;
        ProjectUnlocked = false;
        ProjectPurchased = false;
    }

    public PlayerProjectLink(float id)
        : base(id)
    {
        AssociatedProjectID = -1f;
        AssociatedPlayerProfileID = -1f;
        ProjectUnlocked = false;
        ProjectPurchased = false;
    }

    public PlayerProjectLink(float id, float projectID, float playerID, bool projectUnlocked, bool projectPurchased)
        : base(id)
    {
        AssociatedProjectID = projectID;
        AssociatedPlayerProfileID = playerID;
        ProjectUnlocked = projectUnlocked;
        ProjectPurchased = projectPurchased;
    }

    public void UnlockProject()
    {
        ProjectUnlocked = true;
    }

    public void SetProjectToPurchased()
    {
        ProjectPurchased = true;
    }
}
