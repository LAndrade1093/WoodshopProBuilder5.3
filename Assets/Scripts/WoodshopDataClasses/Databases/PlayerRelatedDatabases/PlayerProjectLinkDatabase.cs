using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/* NOTES:
 * This is sensitive game data. 
 * Save this data to a binary file on the user's phone.
 */

/// <summary>
/// Database for the PlayerProjectLink
/// </summary>
[System.Serializable]
public class PlayerProjectLinkDatabase : AbstractDatabase<PlayerProjectLink>, IBinaryDatabase
{
    private static PlayerProjectLinkDatabase _instance;

    public static PlayerProjectLinkDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerProjectLinkDatabase();
            }
            return _instance;
        }
    }

    private PlayerProjectLinkDatabase() { }

    public bool IsProjectUnlockedForProfile(float projectID, float profileID)
    {
        PlayerProjectLink link = GetLink(profileID, profileID);
        if (link == null)
        {
            throw new Exception("PlayerProjectLink for project ID " + projectID + " and profile ID " + profileID + " does not exist.");
        }
        else
        {
            return link.ProjectUnlocked;
        }
    }

    public bool IsProjectPurchasedForProfile(float projectID, float profileID)
    {
        PlayerProjectLink link = GetLink(profileID, profileID);
        if (link == null)
        {
            throw new Exception("PlayerProjectLink for project ID " + projectID + " and profile ID " + profileID + " does not exist.");
        }
        else
        {
            return link.ProjectPurchased;
        }
    }

    public void UnlockProjectForProfile(float projectID, float profileID)
    {
        PlayerProjectLink link = GetLink(profileID, profileID);
        if (link == null)
        {
            throw new Exception("PlayerProjectLink for project ID " + projectID + " and profile ID " + profileID + " does not exist.");
        }
        else
        {
            link.UnlockProject();
        }
    }

    public void SetProjectAsPurchased(float projectID, float profileID)
    {
        PlayerProjectLink link = GetLink(profileID, profileID);
        if (link == null)
        {
            throw new Exception("PlayerProjectLink for project ID " + projectID + " and profile ID " + profileID + " does not exist.");
        }
        else
        {
            link.SetProjectToPurchased();
        }
    }

    public PlayerProjectLink GetLink(float scoreLockID, float profileID)
    {
        PlayerProjectLink link = Entities.Find(x => x.AssociatedPlayerProfileID == profileID && x.AssociatedProjectID == profileID);
        return link;
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            return new List<string> { Application.persistentDataPath + "PlayerProfileLinks" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }

    public bool SaveToBinaryFile()
    {
        throw new NotImplementedException();
    }
}
