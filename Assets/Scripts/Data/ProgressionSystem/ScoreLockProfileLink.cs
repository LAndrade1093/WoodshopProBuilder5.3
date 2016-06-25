using UnityEngine;
using System.Collections;

public class ScoreLockProfileLink 
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

    public ScoreLockProfileLink(float scoreLock, float profile)
    {
        this.ScoreLockID = scoreLock;
        this.ProfileID = profile;
        this.ProjectUnlocked = false;
    }
}


//public float ProjectIdToUnlock
//{
//    get { return _projectIdToUnlock; }
//    private set { _projectIdToUnlock = value; }
//}
