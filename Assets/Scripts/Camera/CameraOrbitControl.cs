using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class CameraOrbitControl : MonoBehaviour
{
    public Transform LookAtPoint;

    [Header("Distance Variables")]
    public float Distance = 2.0f;
    public float MinDistance = 0.5f;
    public float MaxDistance = 5f;

    [Header("Touch Sensitivity")]
    public float ZoomSensitivity = 10.0f;
    public float OrbitSensitivity = 5.0f;

    [Header("Smoothing")]
    public float ZoomSmoothing = 0.5f;
    public float OrbitSmoothing = 0.5f;

    [Header("Horizontal(Y) Rotation Clamp")]
    public float HorizontalMin = -60f;
    public float HorizontalMax = 60f;

    [Header("Vertical(X) Rotation Limit")]
    public float VerticalMin = -60f;
    public float VerticalMax = 60f;

    private Transform objTransform;
    private float horizontalInput; //y rotation
    private float verticalInput; // x rotation
    private float desiredDistance;
    private float distanceVelocity;
    private Vector3 finalPosition;
    private Vector3 newPosition;
    private Vector3 repositionVelocity;

    void Awake()
    {
        objTransform = transform;
        horizontalInput = 0;
        verticalInput = 0;
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

        finalPosition = Vector3.SmoothDamp(finalPosition, newPosition, ref repositionVelocity, OrbitSmoothing);
        transform.position = finalPosition;
        transform.LookAt(LookAtPoint.position);
    }

    private void HandleInput()
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

    private void CalculateNewPosition()
    {
        Distance = Mathf.SmoothDamp(Distance, desiredDistance, ref distanceVelocity, ZoomSmoothing);
        newPosition = CalculatePosition(Distance, LookAtPoint.position, verticalInput, horizontalInput);
    }

    private Vector3 CalculatePosition(float zDistance, Vector3 lookAtPoint, float xRotation, float yRotation, Vector3 lookAtPointOffset = new Vector3())
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -zDistance);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        Vector3 calculatedPosition = (lookAtPoint + lookAtPointOffset) + (rotation * direction);
        return calculatedPosition;
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

    private bool PlayerIsSwipingCamera(Gesture gesture)
    {
        return gesture.touchCount == 1 
            && gesture.pickedObject == null 
            && gesture.pickedUIElement == null 
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_Swipe;
    }

    private bool PlayerIsPinchingIn(Gesture gesture)
    {
        return gesture.touchCount == 2 
            && gesture.pickedObject == null 
            && gesture.pickedUIElement == null 
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_PinchIn;
    }

    private bool PlayerIsPinchingOut(Gesture gesture)
    {
        return gesture.touchCount == 2
            && gesture.pickedObject == null
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_PinchOut;
    }
}
