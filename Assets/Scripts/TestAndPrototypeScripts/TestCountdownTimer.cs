using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/* NOTES:
 * Testing CountdownTimer class. Ignore or delete 
 */

public class TestCountdownTimer : MonoBehaviour 
{
    public int hours;
    public int minutes;
    public int seconds;

    public Text hoursText;
    public Text minutesText;
    public Text secondsText;

    private CountdownTimer timer;

	void Start () 
    {
        timer = new CountdownTimer();
	}
	
	void Update () 
    {
        timer.UpdateCountdown();
        if (timer.CountingDown)
        {
            TimeUnits units = timer.GetTimeRemaining();
            hoursText.text = formatText(units.Hours.ToString());
            minutesText.text = formatText(units.Minutes.ToString());
            secondsText.text = formatText(units.Seconds.ToString());
        }
	}

    public void SetTimer()
    {
        TimeUnits units = new TimeUnits(hours, minutes, seconds);
        timer.SetCountdown(units);
        hoursText.text = formatText(units.Hours.ToString());
        minutesText.text = formatText(units.Minutes.ToString());
        secondsText.text = formatText(units.Seconds.ToString());
    }

    public void StartTimer()
    {
        timer.StartCountdown();
    }

    public void StopTimer()
    {
        timer.StopCountdown();
    }

    private string formatText(string time)
    {
        string timeString = (time.Length >= 2) ? time : "0" + time;
        return timeString;
    }
}
