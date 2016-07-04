using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class CameraPanControl : MonoBehaviour
{
    public Transform LookAtPoint;
    public LayerMask CollisionMask;

    [Header("Distance Variables")]
    public float Distance = 2.0f;
    public float MinDistance = 0.5f;
    public float MaxDistance = 5f;

    [Header("Touch Sensitivity")]
    public float ZoomSensitivity = 10.0f;
    public float PanSensitivity = 5.0f;

    [Header("Smoothing")]
    public float ZoomSmoothing = 0.5f;
    public float PanSmoothing = 0.5f;

    [Header("Camera Pan Options")]
    public CameraBoundary bounds;
    public PanDirection MovementPlane = PanDirection.XZ_Plane;
    public bool MaintainCameraBounds = false;

    private Transform objTransform;
    private Vector2 previousFingerPosition;
    private Vector3 newPanningPosition;
    private Vector3 finalPannedPosition;
    private Vector3 pannedPositionVelocity;

    private float desiredDistance;
    private float distanceVelocity;

    private Vector3 finalPosition;
    private Vector3 newPosition;
    private Vector3 repositionVelocity;

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

        finalPannedPosition =  Vector3.SmoothDamp(finalPannedPosition, newPanningPosition, ref pannedPositionVelocity, PanSmoothing);
        LookAtPoint.position = finalPannedPosition;

        CalculateNewPosition();
        CheckCollision();

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

    private void HandleInput()
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
    }

    private void CalculateNewPosition()
    {
        Distance = Mathf.SmoothDamp(Distance, desiredDistance, ref distanceVelocity, ZoomSmoothing);
        newPosition = CalculatePosition(Distance, LookAtPoint.position, 0f, 0f);
    }

    private Vector3 CalculatePosition(float zDistance, Vector3 lookAtPoint, float xRotation, float yRotation, Vector3 lookAtPointOffset = new Vector3())
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -zDistance);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        Vector3 calculatedPosition = (lookAtPoint + lookAtPointOffset) + (rotation * direction);
        return calculatedPosition;
    }

    private void CheckCollision()
    {
        CameraHelper.ClipPlaneCoordinates planeCoordinates = CameraHelper.getNearClipPlanePoints(newPosition);
        Vector3[] collisionPoints = planeCoordinates.GetCoordinatesArray();

        RaycastHit hitInfo;
        float intersectingDistance = -1.0f;
        for (int i = 0; i < collisionPoints.Length; i++)
        {
            if (Physics.Linecast(transform.position, collisionPoints[i], out hitInfo, CollisionMask))
            {
                float distance = (transform.position - collisionPoints[i]).magnitude - hitInfo.distance;
                if (intersectingDistance < distance || intersectingDistance == -1)
                {
                    intersectingDistance = distance;
                }
            }
        }

        if (intersectingDistance != -1.0f)
        {
            float finalDistance = intersectingDistance + Distance + 0.2f;
            newPosition = CalculatePosition(finalDistance, LookAtPoint.position, 0f, 0f);
        }
    }

    private bool PlayerStartedTouchingScreen(Gesture gesture)
    {
        return gesture.touchCount == 1
            && gesture.pickedObject == null
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_TouchStart;
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
