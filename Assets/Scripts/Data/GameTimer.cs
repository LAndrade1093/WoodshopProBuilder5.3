using UnityEngine;
using System.Collections;
using System;

public class GameTimer 
{
    private long _totalTime;

    private DateTime startTime;
    private long currentTimePassedInTicks;
    private bool timerStarted;
    private bool timerPaused;

    public long TotalTime
    {
        get { return _totalTime; }
        private set { _totalTime = value; }
    }

    public GameTimer()
    {
        this.TotalTime = 0L;
        startTime = DateTime.Now;
        currentTimePassedInTicks = 0L;
    }

    public GameTimer(long totalTime)
    {
        this.TotalTime = totalTime;
        startTime = DateTime.Now;
        currentTimePassedInTicks = 0L;
    }

    public void StartTimer()
    {
        if (!timerStarted)
        {
            startTime = DateTime.Now;
            timerPaused = false;
            currentTimePassedInTicks = 0L;
        }
    }

    public void UpdateTimer()
    {
        if (timerStarted && !timerPaused)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan difference = currentTime.Subtract(startTime);
            currentTimePassedInTicks = difference.Ticks;
        }
    }

    public void PauseTimer()
    {
        if (timerStarted && !timerPaused)
        {
            UpdateTimer();
            timerPaused = true;
        }
    }

    public void UnpauseTimer()
    {
        if (timerStarted && timerPaused)
        {
            timerPaused = false;
            UpdateTimer();
        }
    }

    public void StopTimer()
    {
        if (timerStarted)
        {
            UpdateTimer();
            timerPaused = false;
            timerStarted = false;
            TotalTime += currentTimePassedInTicks;
            currentTimePassedInTicks = 0L;
        }
    }

    public TimeUnits GetTimePassed()
    {
        TimeSpan span = new TimeSpan(TotalTime);
        TimeUnits timePassed = new TimeUnits(span);
        return timePassed;
    }
}
