using UnityEngine;
using System.Collections;

public class GlueDryingTimer : MonoBehaviour 
{
    public static GlueDryingTimer instance = null;
    protected GlueDryingTimer() { }

    private Project _projectDrying;
    private CountdownTimer timer;

    public Project ProjectDrying
    {
        get { return _projectDrying; }
        private set { _projectDrying = value; }
    }

	void Awake () 
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _projectDrying = null;
        timer = null;
	}
	
	void Update () 
    {
        if (timer != null)
        {
            timer.UpdateCountdown();
            if (timer.CountdownIsDone())
            {
                timer = null;
            }
        }
	}

    public void SetUpDryingTime(Project project, TimeUnits timer)
    {
        this.ProjectDrying = project;
        this.timer = new CountdownTimer();
        this.timer.SetCountdown(timer);
    }

    public void SetUpDryingTime(Project project, int hoursToDry, int minutesToDry, int secondsToDry)
    {
        this.ProjectDrying = project;
        this.timer = new CountdownTimer();
        this.timer.SetCountdown(hoursToDry, minutesToDry, secondsToDry);
    }

    public void StartDrying()
    {
        timer.StartCountdown();
        //Set game state to drying project
    }

    public void StopDrying()
    {
        this.ProjectDrying = null;
        timer.StopCountdown();
        timer = null;
    }
}
