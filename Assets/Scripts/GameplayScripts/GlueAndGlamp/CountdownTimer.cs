using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A class used to countdown time for the specified amount of time.
/// </summary>
[System.Serializable]
public class CountdownTimer
{
    //Meant to be used when waiting for glue to dry in the Clamping steps of each project

    private TimeUnits _units;
    private bool _countingDown;
    private bool _paused;
    private DateTime _startTime;
    private DateTime _endTime;
    private bool timerSet;
    private DateTime currentTime;
    private bool paused;

    public TimeUnits Units
    {
        get { return _units; }
        private set { _units = value; }
    }

    public bool CountingDown
    {
        get { return _countingDown; }
        private set { _countingDown = value; }
    }

    public DateTime StartTime
    {
        get { return _startTime; }
        private set { _startTime = value; }
    }

    public DateTime EndTime
    {
        get
        {
            DateTime time = _endTime;
            if (!CountingDown && !timerSet)
            {
                time = DateTime.Now;
            }
            else if (!CountingDown && timerSet)
            {
                DateTime now = DateTime.Now;
                DateTime end = now.Add(new TimeSpan(Units.Hours, Units.Minutes, Units.Seconds));
                time = end;
            }
            return time;
        }
        private set { _endTime = value; }
    }

    public CountdownTimer()
    {
        this.CountingDown = false;
        this.StartTime = DateTime.Now;
        this.EndTime = DateTime.Now;
        this.timerSet = false;
        this.currentTime = DateTime.Now;
        this.paused = false;
    }

    public void SetCountdown(int hoursToCountdown = 0, int minutesToCountdown = 0, int secondsToCountDown = 0)
    {
        if (!CountingDown)
        {
            Units = new TimeUnits(hoursToCountdown, minutesToCountdown, secondsToCountDown);
            timerSet = true;
            //Debug.Log("Hours: " + hoursToCountdown + "; Minutes: " + minutesToCountdown + "; Seconds: " + secondsToCountDown);
        }
    }

    public void SetCountdown(TimeUnits time)
    {
        if (!CountingDown)
        {
            Units = time;
            timerSet = true;
            //Debug.Log("Hours: " + time.Hours + "; Minutes: " + time.Minutes + "; Seconds: " + time.Seconds);
        }
    }

    public void StartCountdown()
    {
        if (!CountingDown && timerSet)
        {
            StartTime = DateTime.Now;
            currentTime = StartTime;
            TimeSpan timeToCountDown = new TimeSpan(Units.Hours, Units.Minutes, Units.Seconds);
            EndTime = StartTime.Add(timeToCountDown);
            CountingDown = true;
            paused = false;
        }
        else if (!CountingDown && !timerSet)
        {
            Debug.Log("Countdown timer is not set");
        }
        else if (CountingDown && timerSet)
        {
            Debug.Log("Countdown has already started");
        }
        //Debug.Log("Start Time: " + StartTime);
        //Debug.Log("End Time: " + EndTime);
    }

    public void UpdateCountdown()
    {
        if (CountingDown && !paused)
        {
            currentTime = DateTime.Now;
            if (CountdownIsDone())
            {
                StopCountdown();
            }
        }
    }

    public TimeUnits GetTimeRemaining()
    {
        TimeUnits timeRemaining = new TimeUnits(0, 0, 0);
        if (timerSet && CountingDown)
        {
            TimeSpan span = EndTime - currentTime;
            TimeUnits units = new TimeUnits(span.Hours, span.Minutes, span.Seconds);
            timeRemaining = units;
        }
        return timeRemaining;
    }

    public void StopCountdown()
    {
        CountingDown = false;
        timerSet = false;
        paused = false;
    }

    public void SetCountdownPause()
    {
        if (timerSet && CountingDown)
        {
            paused = !paused;
        }
        else
        {
            Debug.Log("Countdown has not been set or started, so it can't be paused");
        }
    }

    public bool CountdownIsDone()
    {
        bool timeUp = false;
        if (!CountingDown)
        {
            timeUp = false;
        }
        else
        {
            timeUp = (currentTime.CompareTo(EndTime) >= 0);
        }
        return timeUp;
    }
}

[System.Serializable]
public class TimeUnits
{
    private int _hours;
    private int _minutes;
    private int _seconds;

    public int Hours
    {
        get { return _hours; }
        private set { _hours = value; }
    }

    public int Minutes
    {
        get { return _minutes; }
        private set { _minutes = value; }
    }

    public int Seconds
    {
        get { return _seconds; }
        private set { _seconds = value; }
    }

    public TimeUnits()
    {
        this.Hours = 0;
        this.Minutes = 0;
        this.Seconds = 0;
    }

    public TimeUnits(int hours, int minutes, int seconds)
    {
        this.Hours = hours;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public TimeUnits(int minutes)
    {
        this.Hours = 0;
        this.Minutes = minutes;
        if (minutes > 59)
        {
            this.Hours = minutes / 60;
            this.Minutes = minutes - (this.Hours * 60);
        }
        this.Seconds = 0;
    }

    public TimeUnits(TimeSpan timeSpan)
    {
        this.Hours = timeSpan.Hours;
        this.Minutes = timeSpan.Minutes;
        this.Seconds = timeSpan.Seconds;
    }
}