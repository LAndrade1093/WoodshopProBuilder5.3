using System.Collections;

public class ScoreTracker 
{
    private float _totalPointsEarned;
    private float _previousScore;
    private bool _isTracking;

    public float TotalPointsEarned 
    {
        get { return _totalPointsEarned; }
        set { _totalPointsEarned = value; }
    }

    public float PreviousScore
    {
        get { return _previousScore; }
        private set { _previousScore = value; }
    }

    public bool TrackingActive
    {
        get { return _isTracking; }
        private set { _isTracking = value; }
    }

    public ScoreTracker()
    {
        this.TotalPointsEarned = 0f;
        this.PreviousScore = 0f;
        this.TrackingActive = false;
    }

    public ScoreTracker(float points)
    {
        this.TotalPointsEarned = points;
        this.PreviousScore = 0f;
        this.TrackingActive = false;
    }

    public ScoreTracker(float points, bool isTrackingActive)
    {
        this.TotalPointsEarned = points;
        this.PreviousScore = 0f;
        this.TrackingActive = isTrackingActive;
    }

    public void ApplyScore(float amount)
    {
        if (TrackingActive)
        {
            TotalPointsEarned += amount;
        }
    }

    public void SetTotalPointsEarned(float points)
    {
        TotalPointsEarned = points;
    }

    public void StartScoreTracking()
    {
        PreviousScore = TotalPointsEarned;
        TotalPointsEarned = 0f;
        TrackingActive = true;
    }

    public void SetScore()
    {
        if (TrackingActive)
        {
            TrackingActive = false;
            if (TotalPointsEarned <= PreviousScore)
            {
                TotalPointsEarned = PreviousScore;
            }
        }
    }

    public void RevertScore()
    {
        if (TrackingActive)
        {
            TotalPointsEarned = PreviousScore;
            TrackingActive = false;
        }
    }
}