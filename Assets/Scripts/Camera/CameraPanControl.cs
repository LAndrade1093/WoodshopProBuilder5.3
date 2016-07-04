using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;
using System;

public class CameraPanControl : CameraControl
{
    public float PanSensitivity = 5.0f;
    public float PanSmoothing = 0.5f;

    [Header("Camera Pan Options")]
    public CameraBoundary bounds;
    public PanDirection MovementPlane = PanDirection.XZ_Plane;
    public bool MaintainCameraBounds = false;
    
    private Vector2 previousFingerPosition;
    private Vector3 newPanningPosition;
    private Vector3 finalPannedPosition;
    private Vector3 pannedPositionVelocity;

    void Awake()
    {
        objTransform = transform;
        previousFingerPosition = Vector2.zero;
        newPanningPosition = LookAtPoint.position;
        finalPannedPosition = LookAtPoint.position;

        desiredDistance = Distance;
        distanceVelocity = 0f;

        finalPosition = objTransform.position;
        newPosition = Vector3.zero;
        repositionVelocity = Vector3.zero;
    }

    void Update()
    {
        HandleInput();
        CalculateNewPosition();
        float collidedDistance = CalculateWoodProjectCollision();
        if(collidedDistance != -1)
        {
            newPosition = CalculatePosition(collidedDistance, LookAtPoint.position, 0f, 0f);
        }
        UpdateCameraPosition();
    }

    protected override void HandleInput()
    {
        Gesture gesture = EasyTouch.current;
        if(PlayerStartedTouchingScreen(gesture))
        {
            previousFingerPosition = gesture.position;
        }
        else if (PlayerIsSwipingCamera(gesture))
        {
            Vector2 currentFingerPosition = gesture.position;
            if (currentFingerPosition != previousFingerPosition)
            {
                Vector3 deltaPosition = gesture.deltaPosition * PanSensitivity * 0.01f;
                Vector3 movement;
                float x = -deltaPosition.x;
                float y = -deltaPosition.y;
                if (MovementPlane == PanDirection.XZ_Plane)
                {
                    movement = (Quaternion.Euler(new Vector3(0.0f, transform.rotation.eulerAngles.y, 0.0f)) * new Vector3(x, 0.0f, y));
                }
                else
                {
                    movement = transform.rotation * new Vector3(x, y, 0.0f);
                }
                newPanningPosition += movement;
                //if (MaintainCameraBounds)
                //{
                //    panOffset = AdjustToBoundary(panOffset);
                //}
                previousFingerPosition = currentFingerPosition;
            }
        }
        else if (PlayerIsPinchingIn(gesture))
        {
            float zoomAmount = gesture.deltaPinch * ZoomSensitivity;
            desiredDistance += zoomAmount;
            desiredDistance = Mathf.Clamp(desiredDistance, MinDistance, MaxDistance);
        }
        else if (PlayerIsPinchingOut(gesture))
        {
            float zoomAmount = gesture.deltaPinch * ZoomSensitivity;
            desiredDistance -= zoomAmount;
            desiredDistance = Mathf.Clamp(desiredDistance, MinDistance, MaxDistance);
        }
        finalPannedPosition = Vector3.SmoothDamp(finalPannedPosition, newPanningPosition, ref pannedPositionVelocity, PanSmoothing);
        LookAtPoint.position = finalPannedPosition;
    }

    protected override void CalculateNewPosition()
    {
        Distance = Mathf.SmoothDamp(Distance, desiredDistance, ref distanceVelocity, ZoomSmoothing);
        newPosition = CalculatePosition(Distance, LookAtPoint.position, 0f, 0f);
    }

    protected override void UpdateCameraPosition()
    {
        finalPosition = newPosition - transform.position;
        transform.Translate(finalPosition, Space.Self);
        transform.LookAt(LookAtPoint.position);
    }

    private Vector3 AdjustToBoundary(Vector3 position)
    {
        Vector3 adjustedPosition = position;
        if (MovementPlane == PanDirection.XY_Plane)
        {
            adjustedPosition.y = Mathf.Clamp(position.y, bounds.MinVerticalBounds, bounds.MaxVerticalBounds);
        }
        else if (MovementPlane == PanDirection.XZ_Plane)
        {
            adjustedPosition.z = Mathf.Clamp(position.z, bounds.MinVerticalBounds, bounds.MaxVerticalBounds);
        }
        adjustedPosition.x = Mathf.Clamp(position.x, bounds.MinHorizontalBounds, bounds.MaxHorizontalBounds);
        return adjustedPosition;
    }

    private bool PlayerStartedTouchingScreen(Gesture gesture)
    {
        return gesture.touchCount == 1
            && gesture.pickedObject == null
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_TouchStart;
    }
}

public enum PanDirection
{
    XY_Plane,
    XZ_Plane
}

[System.Serializable]
public class CameraBoundary
{
    public float MaxVerticalBounds;
    public float MinVerticalBounds;
    public float MaxHorizontalBounds;
    public float MinHorizontalBounds;

    public void ApplyBounds(float bounds)
    {
        MaxVerticalBounds = bounds;
        MinVerticalBounds = -bounds;
        MaxHorizontalBounds = bounds;
        MinHorizontalBounds = -bounds;
    }

    public void ApplyVerticalBounds(float bounds)
    {
        if (bounds > 0)
        {
            MaxVerticalBounds = bounds;
            MinVerticalBounds = -bounds;
        }
        else
        {
            Debug.Log("Cannot apply negative vertical boundaries to camera");
        }
    }

    public void ApplyVerticalBounds(float min, float max)
    {
        if (max <= min)
        {
            Debug.LogError("The vertical max is less than the minimum");
        }
        else
        {
            MaxVerticalBounds = max;
            MinVerticalBounds = min;
        }
    }

    public void ApplyHorizontalBounds(float bounds)
    {
        if (bounds > 0)
        {
            MaxHorizontalBounds = bounds;
            MinHorizontalBounds = -bounds;
        }
        else
        {
            Debug.Log("Cannot apply negative horizontal boundaries to camera");
        }
    }

    public void ApplyHorizontalBounds(float min, float max)
    {
        if (max <= min)
        {
            Debug.LogError("The horizontal max is less than the minimum");
        }
        else
        {
            MaxHorizontalBounds = max;
            MinHorizontalBounds = min;
        }
    }
}