using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;
using System;

public class CameraOrbitControl : CameraControl
{
    public float OrbitSensitivity = 5.0f;
    public float OrbitSmoothing = 0.5f;

    [Header("Horizontal(Y) Rotation Clamp")]
    public float HorizontalMin = -60f;
    public float HorizontalMax = 60f;

    [Header("Vertical(X) Rotation Limit")]
    public float VerticalMin = -60f;
    public float VerticalMax = 60f;
    
    private float horizontalInput; //y rotation
    private float verticalInput; // x rotation

    void Awake()
    {
        Init();
        horizontalInput = 0;
        verticalInput = 0;
    }

    void Update()
    {
        HandleInput();
        CalculateNewPosition();
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
        UpdateCameraPosition();
    }

    protected override void HandleInput()
    {
        Gesture gesture = EasyTouch.current;
        if (PlayerIsSwipingCamera(gesture))
        {
            horizontalInput += gesture.deltaPosition.x * OrbitSensitivity;
            horizontalInput = ClampAngle(horizontalInput, HorizontalMin, HorizontalMax);

            verticalInput -= gesture.deltaPosition.y * OrbitSensitivity;
            verticalInput = ClampAngle(verticalInput, VerticalMin, VerticalMax);
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
}
