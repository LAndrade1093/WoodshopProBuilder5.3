using UnityEngine;
using System.Collections;

public static class CameraHelper
{
    public class ClipPlaneCoordinates
    {
        public Vector3 TopLeft;
        public Vector3 TopRight;
        public Vector3 BottomLeft;
        public Vector3 BottomRight;
        public Vector3 Center;

        public Vector3[] GetCoordinatesArray()
        {
            Vector3[] collisionPoints = new Vector3[5];
            collisionPoints[0] = BottomLeft;
            collisionPoints[1] = TopLeft;
            collisionPoints[2] = BottomRight;
            collisionPoints[3] = TopRight;
            collisionPoints[4] = Center;
            return collisionPoints;
        }
    }

    public static ClipPlaneCoordinates getNearClipPlanePoints(Vector3 cameraPos)
    {
        if (Camera.main == null)
        {
            Debug.LogError("\"(InputHelper\\getNearClipPlanePoints)\" - Main camera is missing");
            return new ClipPlaneCoordinates();
        }
        else
        {
            ClipPlaneCoordinates points = new ClipPlaneCoordinates();

            Transform mainCameraTrans = Camera.main.transform;
            float halfFOV = (Camera.main.fieldOfView * 0.5f) * Mathf.Deg2Rad;
            float aspectRatio = Camera.main.aspect;
            float nearClipDistance = Camera.main.nearClipPlane;
            float planeHeight = Mathf.Tan(halfFOV) * nearClipDistance;
            float planeWidth = planeHeight * aspectRatio;
            Vector3 toNearClipPlaneVector = mainCameraTrans.forward * nearClipDistance;

            Vector3 moveRightVector = cameraPos + (mainCameraTrans.right * planeWidth);
            Vector3 moveLeftVector = cameraPos - (mainCameraTrans.right * planeWidth);
            Vector3 upPlaneVector = mainCameraTrans.up * planeHeight;

            points.TopLeft = moveLeftVector;
            points.TopLeft += upPlaneVector;
            points.TopLeft += toNearClipPlaneVector;

            points.TopRight = moveRightVector;
            points.TopRight += upPlaneVector;
            points.TopRight += toNearClipPlaneVector;

            points.BottomLeft = moveLeftVector;
            points.BottomLeft -= upPlaneVector;
            points.BottomLeft += toNearClipPlaneVector;

            points.BottomRight = moveRightVector;
            points.BottomRight -= upPlaneVector;
            points.BottomRight += toNearClipPlaneVector;

            points.Center = toNearClipPlaneVector;
            points.Center += cameraPos;

            //Debug.Log("TopLeft : " + points.TopLeft);
            //Debug.Log("TopRight : " + points.TopRight);
            //Debug.Log("BottomLeft : " + points.BottomLeft);
            //Debug.Log("BottomRight : " + points.BottomRight);
            //Debug.Log("Center : " + points.Center);

            return points;
        }
    }
}
