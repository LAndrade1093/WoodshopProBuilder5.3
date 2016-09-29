using UnityEngine;
using System.Collections;

/* NOTES:
 * This is the initial stats class I made a while back to keep track certain player statistics. I added 
 * these stats in, but it might be a good idea to go over with the client what kind of stats we want
 * to track for the final game.
 */

/// <summary>
/// The various stats for a player
/// </summary>
public class PlayerStatistics : AbstractAsset
{
    private float _associatedProfileID;
    private int _totalNumberOfProjectsCompleted;
    private float _totalScore;
    private float _totalCashEarned;
    private float _totalTimePlayed;
    private float _totalPerfectLinesCut;
    private float _totalPerfectDadosCut;
    private float _totalPerfectGluings;
    private float _totalPerfectSandings;
    private float _totalPerfectShines;
    private float _totalPerfectPaints;

    public float AssociatedProfileID
    {
        get { return _associatedProfileID; }
        set { _associatedProfileID = value; }
    }

    public int TotalNumberOfProjectsCompleted
    {
        get { return _totalNumberOfProjectsCompleted; }
        set { _totalNumberOfProjectsCompleted = value; }
    }

    public float TotalScore
    {
        get { return _totalScore; }
        set { _totalScore = value; }
    }

    public float TotalCashEarned
    {
        get { return _totalCashEarned; }
        set { _totalCashEarned = value; }
    }

    public float TotalTimePlayed
    {
        get { return _totalTimePlayed; }
        set { _totalTimePlayed = value; }
    }

    public float TotalPerfectLinesCut
    {
        get { return _totalPerfectLinesCut; }
        set { _totalPerfectLinesCut = value; }
    }

    public float TotalPerfectDadosCut
    {
        get { return _totalPerfectDadosCut; }
        set { _totalPerfectDadosCut = value; }
    }

    public float TotalPerfectGluings
    {
        get { return _totalPerfectGluings; }
        set { _totalPerfectGluings = value; }
    }

    public float TotalPerfectSandings
    {
        get { return _totalPerfectSandings; }
        set { _totalPerfectSandings = value; }
    }

    public float TotalPerfectShines
    {
        get { return _totalPerfectShines; }
        set { _totalPerfectShines = value; }
    }

    public float TotalPerfectPaints
    {
        get { return _totalPerfectPaints; }
        set { _totalPerfectPaints = value; }
    }

    public PlayerStatistics() 
        : base()
    {
        this.AssociatedProfileID = -1f;
        init();
    }

    public PlayerStatistics(float id)
        : base(id)
    {
        this.AssociatedProfileID = -1f;
        init();
    }

    public PlayerStatistics(float id, float profile)
        : base(id)
    {
        this.AssociatedProfileID = profile;
        init();
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        PlayerStatistics otherStat = (PlayerStatistics)obj;
        if (this.ID != otherStat.ID) return false;
        if (this.AssociatedProfileID != otherStat.AssociatedProfileID) return false;
        if (this.TotalNumberOfProjectsCompleted != otherStat.TotalNumberOfProjectsCompleted) return false;
        if (this.TotalScore != otherStat.TotalScore) return false;
        if (this.TotalCashEarned != otherStat.TotalCashEarned) return false;
        if (this.TotalPerfectLinesCut != otherStat.TotalPerfectLinesCut) return false;
        if (this.TotalPerfectDadosCut != otherStat.TotalPerfectDadosCut) return false;
        if (this.TotalPerfectGluings != otherStat.TotalPerfectGluings) return false;
        if (this.TotalPerfectSandings != otherStat.TotalPerfectSandings) return false;
        if (this.TotalPerfectShines != otherStat.TotalPerfectShines) return false;
        if (this.TotalPerfectPaints != otherStat.TotalPerfectPaints) return false;

        return true;
    }

    private void init()
    {
        this.TotalNumberOfProjectsCompleted = 0;
        this.TotalScore = 0f;
        this.TotalCashEarned = 0f;
        this.TotalTimePlayed = 0f;
        this.TotalPerfectLinesCut = 0f;
        this.TotalPerfectDadosCut = 0f;
        this.TotalPerfectGluings = 0f;
        this.TotalPerfectSandings = 0f;
        this.TotalPerfectShines = 0f;
        this.TotalPerfectPaints = 0f;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
