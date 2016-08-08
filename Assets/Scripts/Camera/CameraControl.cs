using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public abstract class CameraControl : MonoBehaviour
{
    public Transform LookAtPoint;
    public LayerMask WoodProjectCollisionMask;
    public LayerMask EnvironmentCollisionMask;
    public bool EnableCollision = true;

    [Header("Distance Variables")]
    public float Distance = 2.0f;
    public float MinDistance = 0.5f;
    public float MaxDistance = 5f;

    [Header("Controls")]
    public float ZoomSensitivity = 10.0f;
    public float ZoomSmoothing = 0.5f;
    public bool EnableZoom = true;

    protected Transform objTransform;
    protected float desiredDistance;
    protected float distanceVelocity;
    protected Vector3 finalPosition;
    protected Vector3 newPosition;
    protected Vector3 repositionVelocity;
    protected CameraHelper.ClipPlaneCoordinates planeCoordinates;

    protected void Init()
    {
        objTransform = transform;
        desiredDistance = Distance;
        distanceVelocity = 0f;
        finalPosition = objTransform.position;
        newPosition = Vector3.zero;
        repositionVelocity = Vector3.zero;
        planeCoordinates = new CameraHelper.ClipPlaneCoordinates();
    }

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
        Vector3[] collisionPoints = planeCoordinates.GetCoordinatesArray();

        RaycastHit hitInfo;
        float intersectingDistance = -1.0f;
        for (int i = 0; i < collisionPoints.Length; i++)
        {
            //Debug.DrawLine(transform.position, collisionPoints[i], Color.black);
            if (Physics.Linecast(transform.position, collisionPoints[i], out hitInfo, WoodProjectCollisionMask))
            {
                //Debug.Log("Wood Object Hit: " + hitInfo.collider.gameObject);
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

    protected float CalculateEnvironmentCollision()
    {
        Vector3[] collisionPoints = planeCoordinates.GetCoordinatesArray();

        RaycastHit hitInfo;
        float smallestDistance = -1.0f;
        for (int i = 0; i < collisionPoints.Length; i++)
        {
            //Debug.DrawLine(LookAtPoint.position, collisionPoints[i]);
            if (Physics.Linecast(LookAtPoint.position, collisionPoints[i], out hitInfo, EnvironmentCollisionMask))
            {
                //Debug.Log("Environment Hit: "+ hitInfo.collider.gameObject);
                if (hitInfo.distance < smallestDistance || smallestDistance == -1.0f)
                {
                    smallestDistance = hitInfo.distance;
                }
            }
        }

        float finalDistance = -1.0f;
        if (smallestDistance != -1.0f)
        {
            finalDistance = smallestDistance - Camera.main.nearClipPlane + 0.2f;
            if (finalDistance < 0.25f)
            {
                finalDistance = 0.25f;
            }
        }
        return finalDistance;
    }

    protected bool PlayerIsSwipingCamera(Gesture gesture)
    {
        bool objectPicked = (gesture.pickedObject == null) ? true : gesture.pickedObject.name == "Blade";
        return gesture.touchCount == 1
            && objectPicked
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && (gesture.type == EasyTouch.EvtType.On_Swipe || (objectPicked && (gesture.type == EasyTouch.EvtType.On_Drag)));
    }

    protected bool PlayerIsPinchingIn(Gesture gesture)
    {
        bool objectPicked = (gesture.pickedObject == null) ? true : gesture.pickedObject.name == "Blade";
        return gesture.touchCount == 2
            && objectPicked
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_PinchIn;
    }

    protected bool PlayerIsPinchingOut(Gesture gesture)
    {
        bool objectPicked = (gesture.pickedObject == null) ? true : gesture.pickedObject.name == "Blade";
        return gesture.touchCount == 2
            && objectPicked
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_PinchOut;
    }
}
