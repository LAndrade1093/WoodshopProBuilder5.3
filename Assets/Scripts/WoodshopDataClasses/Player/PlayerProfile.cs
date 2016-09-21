using UnityEngine;
using System.Collections;
using UnityEngine.SocialPlatforms;

/// <summary>
/// Basic data related to the player.
/// </summary>
[System.Serializable]
public class PlayerProfile : AbstractAsset
{
    private string _name;
    private WoodshopRank _rank;
    private PlayerStatistics _stats;
    private bool _defaultTutorialsToOn;
    
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

    public bool DefaultTutorialsToOn
    {
        get { return _defaultTutorialsToOn; }
        set { _defaultTutorialsToOn = value; }
    }

    public PlayerProfile() 
        : base()
    {
        this.Name = "NA";
        this.Rank = WoodshopRank.Amateur;
        this.Stats = new PlayerStatistics(this.ID);
        this.DefaultTutorialsToOn = false;
    }

    public PlayerProfile(float id)
        : base(id)
    {
        this.Name = "NA";
        this.Rank = WoodshopRank.Amateur;
        this.Stats = null;
        this.DefaultTutorialsToOn = false;
    }

    public PlayerProfile(float id, string name, WoodshopRank rank, PlayerStatistics stats, bool tutorialsOn)
        : base(id)
    {
        this.Name = name;
        this.Rank = rank;
        this.Stats = stats;
        this.DefaultTutorialsToOn = tutorialsOn;
    }
}
