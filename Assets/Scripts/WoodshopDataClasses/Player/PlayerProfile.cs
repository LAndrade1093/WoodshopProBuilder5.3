using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

public class PlayerProfile 
{
    private static float nextID = 0;
    private float _id;
    private string _name;
    private WoodshopRank _rank;
    private PlayerStatistics _stats;

    public float ID
    {
        get { return _id; }
        private set { _id = value; }
    }

    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public WoodshopRank Rank
    {
        get { return _rank; }
        set { _rank = value; }
    }

    public PlayerStatistics Stats
    {
        get { return _stats; }
        set { _stats = value; }
    }

    public PlayerProfile()
    {
        this.ID = nextID++;
        this.Name = "NA";
        this.Rank = WoodshopRank.Amateur;
        this.Stats = new PlayerStatistics(this.ID);
    }

    public PlayerProfile(string name, WoodshopRank rank, PlayerStatistics stats)
    {
        this.ID = nextID++;
        this.Name = name;
        this.Rank = rank;
        this.Stats = stats;
    }
}
