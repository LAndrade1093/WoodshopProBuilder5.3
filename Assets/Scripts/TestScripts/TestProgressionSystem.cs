using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class ProjectDisplay
{
    public Text NameText;
    public Text SalePriceText;
    public Text ScoreText;
    public Text UnlockedText;
}

public class TestProgressionSystem : MonoBehaviour 
{
    public ProjectDisplay projectDisplay;
    public ProjectDisplay lockedProjectDisplay;
    public Text highScoreDisplay;

    private Project project;
    private Project lockedProject;
    private ScoreLock projectLock;

	void Start () 
    {
        //Score score1 = new Score("score0");
        //project = new Project("project1", "Project Test", 100, score1);
        //ProjectsCollection.CreateProject(project);
        //highScoreDisplay.text = project.ProjectScore.HighScore.ToString();

        //Score score2 = new Score("score1");
        //lockedProject = new Project("project2", "Locked Project", 200, score2);
        //ProjectsCollection.CreateProject(lockedProject);

        //ScoreRequirement s = new ScoreRequirement(600f, project.ID);
        //projectLock = new ScoreLock("scoreLock", lockedProject.ID, s);
        //projectLock.OnProjectUnlocked += UnlockLockedProject;

        //FillInText(projectDisplay, project);
        //FillInText(lockedProjectDisplay, lockedProject, projectLock);
	}

	void Update () 
    {
        //projectDisplay.ScoreText.text = project.ProjectScore.GetCurrentScore().ToString();
        //highScoreDisplay.text = project.ProjectScore.HighScore.ToString();
	}

    public void IncreaseScore()
    {
        //project.ProjectScore.Increase(Random.RandomRange(10f, 50f));
    }

    public void DecreaseScore()
    {
        //project.ProjectScore.Decrease(Random.RandomRange(10f, 50f));
    }

    public void SetScore()
    {
        //project.ProjectScore.ResetScore(true);
    }

    public void UnlockLockedProject(object sender, System.EventArgs e)
    {
        //ScoreLockEventArgs s = e as ScoreLockEventArgs;
        //if (!projectLock.ProjectIsUnlocked && s.ProjectID == projectLock.ProjectIDToUnlock)
        //{
        //    lockedProjectDisplay.UnlockedText.text = "true";
        //}
    }

    private void FillInText(ProjectDisplay display, Project project, ScoreLock locker = null)
    {
        //display.NameText.text = project.Name;
        //display.SalePriceText.text = project.SalePrice.ToString();
        //display.ScoreText.text = project.ProjectScore.HighScore.ToString();
        //if (locker == null)
        //{
        //    display.UnlockedText.text = "true";
        //}
        //else
        //{
        //    display.UnlockedText.text = locker.ProjectIsUnlocked.ToString();
        //}
    }
}
