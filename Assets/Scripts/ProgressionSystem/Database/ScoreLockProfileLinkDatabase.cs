using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ScoreLockProfileLinkDatabase 
{
    private static List<ScoreLockProfileLink> scoreLockToProfileList;

    public static void ValidateDatabase()
    {
        if (scoreLockToProfileList == null)
        {
            scoreLockToProfileList = new List<ScoreLockProfileLink>();
        }
    }

    public static MethodResult AddLink(ScoreLockProfileLink link)
    {
        MethodResult result = new MethodResult();
        ValidateDatabase();
        if (!scoreLockToProfileList.Contains(link))
        {
            scoreLockToProfileList.Add(link);
        }
        else
        {
            result = new MethodResult("Profile ID " + link.ProfileID + " to ScoreLock ID " + link.ScoreLockID + " is already in the ScoreLockProfileLink database", false, ErrorType.UnableToAddToDatabase);
        }
        return result;
    }

    public static Project RetrieveProjectToUnlock(float scoreLockID)
    {
        ValidateDatabase();
        ScoreLockProfileLink link = scoreLockToProfileList.First(x => x.ScoreLockID == scoreLockID);
        ScoreLock scoreLock = ScoreLockDatabase.RetrieveScoreLock(link.ScoreLockID);
        Project project = ProjectsDatabase.RetrieveProject(scoreLock.ProjectIDToUnlock);
        return project;
    }

    public static List<ScoreLockStatus> RetrieveAllScoreLockStatusByProfile(float profileID)
    {
        ValidateDatabase();
        List<ScoreLockStatus> statusList = new List<ScoreLockStatus>();
        List<ScoreLockProfileLink> linkList = scoreLockToProfileList.Where(x => x.ProfileID == profileID).ToList();
        foreach (ScoreLockProfileLink link in linkList)
        {
            ScoreLock scoreLock = ScoreLockDatabase.RetrieveScoreLock(link.ScoreLockID);
            bool projectUnlocked = link.ProjectUnlocked;
            statusList.Add(new ScoreLockStatus() { ScoreLock = scoreLock, IsProjectUnlock = projectUnlocked });
        }
        return statusList;
    }

    public static bool IsProjectUnlockedForProfile(float projectID, float profileID)
    {
        ValidateDatabase();
        ScoreLock scoreLock = ScoreLockDatabase.RetrieveScoreLockByProjectID(projectID);
        ScoreLockProfileLink link = scoreLockToProfileList.First(x => x.ProfileID == profileID && x.ScoreLockID == scoreLock.ID);
        return link.ProjectUnlocked;
    }

    public static void UnlockProjectForProfile(float scoreLockID, float profileID)
    {
        ValidateDatabase();
        ScoreLockProfileLink link = scoreLockToProfileList.First(x => x.ProfileID == profileID && x.ScoreLockID == scoreLockID);
        link.ProjectUnlocked = true;
    }

    //public static ScoreLock RetrieveScoreLock(Project project)
    //{
    //    ValidateDatabase();
    //    ScoreLock gate = null;
    //    gate = scoreLockList.First(x => x.ProjectIDToUnlock == project.ID);
    //    return gate;
    //}

    //public List<ScoreLock> RetrieveAllScoreLocks()
    //{
    //    ValidateDatabase();
    //    return scoreLockList;
    //}
}

public class ScoreLockStatus
{
    public ScoreLock ScoreLock;
    public bool IsProjectUnlock;
}
