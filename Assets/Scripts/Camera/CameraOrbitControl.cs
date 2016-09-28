using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;
using System;

/// <summary>
/// A camera orbit control script that uses velocity and smooth dampening
/// </summary>
public class CameraOrbitControl : CameraControl
{
    public float OrbitSensitivity = 5.0f;
    public float OrbitSmoothing = 0.5f;
    public bool EnableOrbit = true;

    [Header("Horizontal(Y) Rotation Clamp")]
    public float HorizontalMin = -60f;
    public float HorizontalMax = 60f;

    [Header("Vertical(X) Rotation Limit")]
    public float VerticalMin = -60f;
    public float VerticalMax = 60f;

    [Header("Initial Viewing Angle")]
    public bool EnableAngleClamp = true;
    public float HorizontalAngle = 0f;
    public float VerticalAngle = -45f;

    private float horizontalInput; //y rotation
    private float verticalInput; // x rotation

    void Awake()
    {
        Init();
        horizontalInput = HorizontalAngle;
        verticalInput = VerticalAngle;
    }

    void Update()
    {
        HandleInput();
        CalculateNewPosition();
        if (EnableCollision)
        {
            planeCoordinates = CameraHelper.getNearClipPlanePoints(newPosition);
            float collidedDistance = CalculateWoodProjectCollision();
            if (collidedDistance != -1)
            {
                newPosition = CalculatePosition(collidedDistance, LookAtPoint.position, verticalInput, horizontalInput);
            }
            else
            {
                float distance = CalculateEnvironmentCollision();
                if (distance != -1.0f)
                {
                    newPosition = CalculatePosition(distance, LookAtPoint.position, verticalInput, horizontalInput);
                }
            }
        }
        UpdateCameraPosition();
    }

    protected override void HandleInput()
    {
        Gesture gesture = EasyTouch.current;
        bool o = PlayerIsSwipingCamera(gesture);
        //Debug.Log("PlayerIsSwipingCamera: " + o);
        if (o && EnableOrbit)
        {
            horizontalInput += gesture.deltaPosition.x * OrbitSensitivity;
            verticalInput -= gesture.deltaPosition.y * OrbitSensitivity;
        }
        else if (PlayerIsPinchingIn(gesture) && EnableZoom)
        {
            float zoomAmount = gesture.deltaPinch * ZoomSensitivity * Time.deltaTime;
            desiredDistance += zoomAmount;
            desiredDistance = Mathf.Clamp(desiredDistance, MinDistance, MaxDistance);
        }
        else if (PlayerIsPinchingOut(gesture) && EnableZoom)
        {
            float zoomAmount = gesture.deltaPinch * ZoomSensitivity * Time.deltaTime;
            desiredDistance -= zoomAmount;
            desiredDistance = Mathf.Clamp(desiredDistance, MinDistance, MaxDistance);
        }
        if (EnableAngleClamp)
        {
            horizontalInput = ClampAngle(horizontalInput, HorizontalMin, HorizontalMax);
            verticalInput = ClampAngle(verticalInput, VerticalMin, VerticalMax);
        }
    }

    protected override void CalculateNewPosition()
    {
        Distance = Mathf.SmoothDamp(Distance, desiredDistance, ref distanceVelocity, ZoomSmoothing);
        newPosition = CalculatePosition(Distance, LookAtPoint.position, verticalInput, horizontalInput);
    }

    protected override void UpdateCameraPosition()
    {
        finalPosition = Vector3.SmoothDamp(finalPosition, newPosition, ref repositionVelocity, OrbitSmoothing);
        transform.position = finalPosition;
        transform.LookAt(LookAtPoint.position);
    }

    private float ClampAngle(float angle, float minAngle, float maxAngle)
    {
        float adjustedAngle = angle;
        do
        {
            if (adjustedAngle < -360)
            {
                adjustedAngle += 360;
            }

            if (adjustedAngle > 360)
            {
                adjustedAngle -= 360;
            }

        } while (adjustedAngle < -360 || adjustedAngle > 360);

        float finalAngle = Mathf.Clamp(adjustedAngle, minAngle, maxAngle);

        return finalAngle;
    }

    public void ChangeAngle(float v, float h)
    {
        verticalInput = v;
        horizontalInput = h;
    }

    public void ChangeDistanceConstraints(float min, float max)
    {
        MinDistance = min;
        MaxDistance = max;
    }

    public void ChangeDistanceConstraints(float distance, float min, float max)
    {
        desiredDistance = distance;
        Distance = distance;
        MinDistance = min;
        MaxDistance = max;
    }
}
