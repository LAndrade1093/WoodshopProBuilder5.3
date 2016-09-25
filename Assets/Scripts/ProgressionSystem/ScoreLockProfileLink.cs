using UnityEngine;
using System.Collections;

/// <summary>
/// Associates a ScoreLock instance to a PlayerProfile through IDs.
/// Tracks whether or not the project associated to the ScoreLock is unlocked for the associated profile.
/// When a player profile is created, a new instance for each ScoreLock must be created and saved.
/// </summary>
public class ScoreLockProfileLink : AbstractAsset
{
    private float _scoreLockID;
    private float _profileID;
    private bool _projectUnlocked;

    public float ScoreLockID
    {
      get { return _scoreLockID; }
      private set { _scoreLockID = value; }
    }

    public float ProfileID
    {
        get { return _profileID; }
        private set { _profileID = value; }
    }

    public bool ProjectUnlocked
    {
        get { return _projectUnlocked; }
        set { _projectUnlocked = value; }
    }

    public ScoreLockProfileLink()
        : base()
    {
        this.ScoreLockID = -1f;
        this.ProfileID = -1f;
        this.ProjectUnlocked = false;
    }

    public ScoreLockProfileLink(float id)
        : base(id)
    {
        this.ScoreLockID = -1f;
        this.ProfileID = -1f;
        this.ProjectUnlocked = false;
    }

    public ScoreLockProfileLink(float id, float scoreLockID, float profileID)
        : base(id)
    {
        this.ScoreLockID = scoreLockID;
        this.ProfileID = profileID;
        this.ProjectUnlocked = false;
    }

    public ScoreLockProfileLink(float id, float scoreLockID, float profileID, bool projectIsUnlocked)
        : base(id)
    {
        this.ScoreLockID = scoreLockID;
        this.ProfileID = profileID;
        this.ProjectUnlocked = projectIsUnlocked;
    }
}


//public float ProjectIdToUnlock
//{
//    get { return _projectIdToUnlock; }
//    private set { _projectIdToUnlock = value; }
//}
