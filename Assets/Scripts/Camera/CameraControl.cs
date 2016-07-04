using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public abstract class CameraControl : MonoBehaviour
{
    public Transform LookAtPoint;
    public LayerMask WoodProjectCollisionMask;
    public LayerMask OtherCollisionMask;

    [Header("Distance Variables")]
    public float Distance = 2.0f;
    public float MinDistance = 0.5f;
    public float MaxDistance = 5f;

    [Header("Controls")]
    public float ZoomSensitivity = 10.0f;
    public float ZoomSmoothing = 0.5f;

    protected Transform objTransform;
    protected float desiredDistance;
    protected float distanceVelocity;
    protected Vector3 finalPosition;
    protected Vector3 newPosition;
    protected Vector3 repositionVelocity;

    protected abstract void HandleInput();

    protected abstract void CalculateNewPosition();

    protected abstract void UpdateCameraPosition();

    protected Vector3 CalculatePosition(float zDistance, Vector3 lookAtPoint, float xRotation, float yRotation)
    {
        Vector3 direction = new Vector3(0.0f, 0.0f, -zDistance);
        Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
        Vector3 calculatedPosition = lookAtPoint + (rotation * direction);
        return calculatedPosition;
    }

    protected float CalculateWoodProjectCollision()
    {
        CameraHelper.ClipPlaneCoordinates planeCoordinates = CameraHelper.getNearClipPlanePoints(newPosition);
        Vector3[] collisionPoints = planeCoordinates.GetCoordinatesArray();

        RaycastHit hitInfo;
        float intersectingDistance = -1.0f;
        for (int i = 0; i < collisionPoints.Length; i++)
        {
            if (Physics.Linecast(transform.position, collisionPoints[i], out hitInfo, WoodProjectCollisionMask))
            {
                float distance = (transform.position - collisionPoints[i]).magnitude - hitInfo.distance;
                if (intersectingDistance < distance || intersectingDistance == -1)
                {
                    intersectingDistance = distance;
                }
            }
        }

        float collisionDistance = -1.0f;
        if (intersectingDistance != -1.0f)
        {
            collisionDistance = intersectingDistance + Distance + 0.2f;
        }
        return collisionDistance;
    }

    protected bool PlayerIsSwipingCamera(Gesture gesture)
    {
        return gesture.touchCount == 1
            && gesture.pickedObject == null
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_Swipe;
    }

    protected bool PlayerIsPinchingIn(Gesture gesture)
    {
        return gesture.touchCount == 2
            && gesture.pickedObject == null
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_PinchIn;
    }

    protected bool PlayerIsPinchingOut(Gesture gesture)
    {
        return gesture.touchCount == 2
            && gesture.pickedObject == null
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_PinchOut;
    }
}
