using UnityEngine;
using System.Collections;

/// <summary>
/// Countdown timer script for when the gluing is drying in the Clamping step of a project.
/// </summary>
public class GlueDryingTimer : MonoBehaviour 
{
    private static string HourKey = "DryingProject_Hours";
    private static string MinuteKey = "DryingProject_Minutes";
    private static string SecondsKey = "DryingProject_Seconds";
    private CountdownTimer timer;

    void Awake () 
    {
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

    public void SetUpDryingTime(TimeUnits timer)
    {
        this.timer = new CountdownTimer();
        this.timer.SetCountdown(timer);
    }

    public void SetUpDryingTime(int hoursToDry, int minutesToDry, int secondsToDry)
    {
        this.timer = new CountdownTimer();
        this.timer.SetCountdown(hoursToDry, minutesToDry, secondsToDry);
    }

    public void StartDrying()
    {
        timer.StartCountdown();
    }

    public void StopDrying()
    {
        timer.StopCountdown();
        timer = null;
    }

    public void SaveTimer()
    {
        TimeUnits timeLeft = timer.GetTimeRemaining();
        PlayerPrefs.SetInt(HourKey, timeLeft.Hours);
        PlayerPrefs.SetInt(MinuteKey, timeLeft.Minutes);
        PlayerPrefs.SetInt(SecondsKey, timeLeft.Seconds);
    }

    public bool LoadInTimer()
    {
        bool canBeLoadedIn = (PlayerPrefs.HasKey(HourKey) && PlayerPrefs.HasKey(MinuteKey) && PlayerPrefs.HasKey(SecondsKey));
        if(canBeLoadedIn)
        {
            TimeUnits time = new TimeUnits(PlayerPrefs.GetInt(HourKey), PlayerPrefs.GetInt(MinuteKey), PlayerPrefs.GetInt(SecondsKey));
            SetUpDryingTime(time);
            StartDrying();
        }
        return canBeLoadedIn;
    }
}
