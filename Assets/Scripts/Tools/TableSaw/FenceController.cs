using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class FenceController : MonoBehaviour
{
    public float MinimumLimitX;
    public float MaximumLimitX;

    private Vector3 previousPosition;
    private Transform objTransform;

	void Start ()
    {
        previousPosition = Vector3.zero;
        objTransform = transform;
	}
	
	void Update ()
    {
        Gesture gesture = EasyTouch.current;
        if(PlayerHasTouchedObject(gesture))
        {
            previousPosition = gesture.GetTouchToWorldPoint(objTransform.position);
        }
        else if(PlayerIsDragginObject(gesture))
        {
            Vector3 position = gesture.GetTouchToWorldPoint(transform.position);
            Vector3 nextPosition = position - previousPosition;
            objTransform.position += new Vector3(nextPosition.x, 0.0f, 0.0f);
            float x = Mathf.Clamp(objTransform.position.x, MinimumLimitX, MaximumLimitX);
            objTransform.position = new Vector3(x, objTransform.position.y, objTransform.position.z);
            previousPosition = position;
        }
	}

    private bool PlayerHasTouchedObject(Gesture gesture)
    {
        return gesture.touchCount == 1
            && gesture.pickedObject == gameObject
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_TouchStart;
    }

    private bool PlayerIsDragginObject(Gesture gesture)
    {
        return gesture.touchCount == 1
            && gesture.pickedObject == gameObject
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_Drag;
    }
}
