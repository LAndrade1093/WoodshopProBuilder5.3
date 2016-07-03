using UnityEngine;
using System.Collections;

public class CameraHelper
{
    //public static float ClampAngle(float angle, float minAngle, float maxAngle)
    //{
    //    float adjustedAngle = angle;
    //    do
    //    {
    //        if (adjustedAngle < -360)
    //        {
    //            adjustedAngle += 360;
    //        }

    //        if (adjustedAngle > 360)
    //        {
    //            adjustedAngle -= 360;
    //        }

    //    } while (adjustedAngle < -360 || adjustedAngle > 360);

    //    float finalAngle = Mathf.Clamp(adjustedAngle, minAngle, maxAngle);

    //    return finalAngle;
    //}

    //public static Vector3 CalculatePosition(float zDistance, Vector3 lookAtPoint, float xRotation, float yRotation, Vector3 lookAtPointOffset = new Vector3())
    //{
    //    Vector3 direction = new Vector3(0.0f, 0.0f, -zDistance);
    //    Quaternion rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
    //    Vector3 calculatedPosition = (lookAtPoint + lookAtPointOffset) + (rotation * direction);
    //    return calculatedPosition;
    //}
}
