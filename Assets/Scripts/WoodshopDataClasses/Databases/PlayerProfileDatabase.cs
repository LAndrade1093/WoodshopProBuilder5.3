using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerProfileDatabase
{
    public static List<PlayerProfile> playerProfileList = null;
    public static PlayerProfile currentProfile;

    private const int MaxProfiles = 4;

    public static void ValidateDatabase()
    {
        if (playerProfileList == null)
        {
            playerProfileList = new List<PlayerProfile>(MaxProfiles);
        }
    }

    public static void AddProfile(PlayerProfile profile)
    {
        ValidateDatabase();
        if (playerProfileList.Count == MaxProfiles)
        {
            Debug.LogError("The limit for player profiles has been met.");
        }
        else if (playerProfileList.Contains(profile))
        {
            Debug.LogError("Profile for \"" + profile.Name + "\" is already in the database. Player Score was not saved.");
        }
        else
        {
            playerProfileList.Add(profile);
        }
    }

    public static PlayerProfile RetrieveProfile(float profileID)
    {
        ValidateDatabase();
        PlayerProfile profile = playerProfileList.First(x => x.ID == profileID);
        return profile;
    }

    public static void UpdateProfile(PlayerProfile updatedProfile)
    {
        ValidateDatabase();
        PlayerProfile profile = playerProfileList.First(x => x.ID == updatedProfile.ID);
        int index = playerProfileList.IndexOf(profile);
        playerProfileList[index] = updatedProfile;
    }
}
