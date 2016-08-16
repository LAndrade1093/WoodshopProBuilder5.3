using UnityEngine;
using System.Collections;

public class PushRateTracker : MonoBehaviour
{
    public bool trackingPushRate = false;    
    public float trackingRateSmoothing = 0.3f;
    public float perfectRateMinimum;
    public float perfectRateMaximum;
    public float maximumPushRate;
    public PushRateBarUI pushRateBar;
    public Transform _pieceToTrack;

    private float currentPushRate = 0f;
    private Vector3 previousPiecePosition = Vector3.zero;
    private float playerSmoothingVelocity = 0.0f;

    #region Properties
    public Transform PieceToTrack
    {
        get
        {
            if (_pieceToTrack == null)
            {
                Debug.LogError("_pieceToTrack is not set");
            }
            return _pieceToTrack;
        }
        set
        {
            _pieceToTrack = value;
            previousPiecePosition = _pieceToTrack.position;
        }
    }

    public bool PushRateTooSlow
    {
        get
        {
            bool tooSlow = false;
            if (trackingPushRate && currentPushRate < perfectRateMinimum)
            {
                tooSlow = true;
            }
            return tooSlow;
        }
    }

    public bool PushRateWithinRange
    {
        get
        {
            bool withinRange = false;
            if (trackingPushRate && currentPushRate >= perfectRateMinimum && currentPushRate <= perfectRateMaximum)
            {
                withinRange = true;
            }
            return withinRange;
        }
    }

    public bool PushRateTooFast
    {
        get
        {
            bool tooFast = false;
            if (trackingPushRate && currentPushRate > perfectRateMaximum)
            {
                tooFast = true;
            }
            return tooFast;
        }
    }
    #endregion

    void Awake()
    {
        if (_pieceToTrack != null)
        {
            trackingPushRate = true;
            previousPiecePosition = _pieceToTrack.position;
        }
    }

    void LateUpdate()
    {
        if (trackingPushRate)
        {
            if (_pieceToTrack != null)
            {
                UpdatePushRate();
                pushRateBar.UpdateIndicator(this);
            }
            else
            {
                Debug.LogError("_pieceToTrack not set to update push rate");
            }
        }
    }

    private void UpdatePushRate()
    {
        Vector3 deltaVector = _pieceToTrack.position - previousPiecePosition;
        deltaVector = new Vector3(deltaVector.x, 0.0f, deltaVector.z);
        float unitsPerSecond = deltaVector.magnitude / Time.deltaTime;
        currentPushRate = Mathf.SmoothDamp(currentPushRate, unitsPerSecond, ref playerSmoothingVelocity, trackingRateSmoothing);
        if (currentPushRate > maximumPushRate)
        {
            currentPushRate = maximumPushRate;
        }
        previousPiecePosition = _pieceToTrack.position;
    }

    public void ActivePushRateTracking(bool activatingTracking)
    {
        if (_pieceToTrack != null)
        {
            trackingPushRate = activatingTracking;
            if (activatingTracking)
            {
                previousPiecePosition = _pieceToTrack.position;
            }
        }
        else
        {
            Debug.LogError("Tracking cannot be changed until _pieceToTrack is set");
        }
    }

    public float GetCurrentPushRate()
    {
        return currentPushRate;
    }
}
