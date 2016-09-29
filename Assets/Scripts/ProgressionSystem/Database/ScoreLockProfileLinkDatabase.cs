using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

/// <summary>
/// Stores all ScoreLockProfileLink instances.
/// </summary>
//public class ScoreLockProfileLinkDatabase : AbstractDatabase<ScoreLockProfileLink>
//{
//    private static ScoreLockProfileLinkDatabase _instance;

//    public static ScoreLockProfileLinkDatabase Instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                _instance = new ScoreLockProfileLinkDatabase();
//            }
//            return _instance;
//        }
//    }

//    protected override List<string> DataFilePaths
//    {
//        get
//        {
//            //Save to binary file on device
//            return new List<string> { "ScoreLockProfileLinks" };
//        }
//    }

//    private ScoreLockProfileLinkDatabase() { }

//    public Project RetrieveProjectToUnlock(float scoreLockID)
//    {
//        ScoreLockProfileLink link = Entities.First(x => x.ScoreLockID == scoreLockID);
//        ScoreLock scoreLock = ScoreLockDatabase.Instance.RetrieveEntity(link.ScoreLockID);
//        Project project = ProjectsDatabase.Instance.RetrieveEntity(scoreLock.ProjectIDToUnlock);
//        return project;
//    }

//    public List<ScoreLockStatus> RetrieveAllScoreLockStatusByProfile(float profileID)
//    {
//        List<ScoreLockStatus> statusList = new List<ScoreLockStatus>();
//        List<ScoreLockProfileLink> linkList = Entities.Where(x => x.ProfileID == profileID).ToList();
//        foreach (ScoreLockProfileLink link in linkList)
//        {
//            ScoreLock scoreLock = ScoreLockDatabase.Instance.RetrieveEntity(link.ScoreLockID);
//            bool projectUnlocked = link.ProjectUnlocked;
//            statusList.Add(new ScoreLockStatus() { ScoreLock = scoreLock, IsProjectUnlock = projectUnlocked });
//        }
//        return statusList;
//    }

//    public bool IsProjectUnlockedForProfile(float projectID, float profileID)
//    {
//        ScoreLock scoreLock = ScoreLockDatabase.Instance.RetrieveScoreLockByProjectID(projectID);
//        ScoreLockProfileLink link = Entities.First(x => x.ProfileID == profileID && x.ScoreLockID == scoreLock.ID);
//        return link.ProjectUnlocked;
//    }

//    public void UnlockProjectForProfile(float scoreLockID, float profileID)
//    {
//        ScoreLockProfileLink link = Entities.First(x => x.ProfileID == profileID && x.ScoreLockID == scoreLockID);
//        link.ProjectUnlocked = true;
//    }

//    protected override void LoadFromDataFile()
//    {
//        throw new NotImplementedException();
//    }

//    //public static ScoreLock RetrieveScoreLock(Project project)
//    //{
//    //    ValidateDatabase();
//    //    ScoreLock gate = null;
//    //    gate = scoreLockList.First(x => x.ProjectIDToUnlock == project.ID);
//    //    return gate;
//    //}

//    //public List<ScoreLock> RetrieveAllScoreLocks()
//    //{
//    //    ValidateDatabase();
//    //    return scoreLockList;
//    //}
//}

//public class ScoreLockStatus
//{
//    public ScoreLock ScoreLock;
//    public bool IsProjectUnlock;
//}
