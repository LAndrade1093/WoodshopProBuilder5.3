using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class PlayerProfileDatabase : AbstractDatabase<PlayerProfile>
{
    private static PlayerProfileDatabase _instance;

    public static PlayerProfileDatabase Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new PlayerProfileDatabase();
            }
            return _instance;
        }
    }

    private PlayerProfileDatabase() { }

    public PlayerProfile currentProfile = null;
    private const int MaxProfiles = 4;

    public static void SetCurrentPlayer(float profileID)
    {
        if(Instance.Contains(profileID))
        {
            Instance.currentProfile = Instance.RetrieveEntity(profileID);
        }
        else
        {
            throw new PlayerDoesNotExistException("Player with ID "+profileID+" does not exist");
        }
    }

    public override PlayerProfile CreateEntity(PlayerProfile entity)
    {
        if(NumberOfProfilesAvailable() < MaxProfiles)
        {
            return base.CreateEntity(entity);
        }
        else
        {
            throw new MaxProfileLimitReachedException("The max number of " + MaxProfiles + " profiles has been reached. No more profiles can be added.");
        }
    }

    public int NumberOfProfilesAvailable()
    {
        return MaxProfiles - Count();
    }

    protected override List<string> DataFilePaths
    {
        get
        {
            //Save to binary file on the user's device
            return new List<string> { "PlayerProfiles" };
        }
    }

    protected override void LoadFromDataFile()
    {
        throw new NotImplementedException();
    }
}
