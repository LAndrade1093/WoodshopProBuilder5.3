using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;

public class MiterGaugeController : MonoBehaviour
{
    public float MinimumLimitZ;
    public float MaximumLimitZ;
    public float MinRotation;
    public float MaxRotation;
    public GameObject MiterGaugeObject;

    private Vector3 previousPosition;
    private Transform objTransform;

    void Start()
    {
        previousPosition = Vector3.zero;
        objTransform = transform;
    }

    void Update()
    {
        Gesture gesture = EasyTouch.current;
        if (PlayerHasStartedDraggingObject(gesture))
        {
            previousPosition = gesture.GetTouchToWorldPoint(objTransform.position);
        }
        else if (PlayerIsDragginObject(gesture))
        {
            Vector3 position = gesture.GetTouchToWorldPoint(objTransform.position);
            Vector3 nextPosition = position - previousPosition;
            objTransform.position += new Vector3(0.0f, 0.0f, nextPosition.z);
            float z = Mathf.Clamp(objTransform.position.z, MinimumLimitZ, MaximumLimitZ);
            objTransform.position = new Vector3(objTransform.position.x, objTransform.position.y, z);
            previousPosition = position;
        }
    }

    private bool PlayerHasStartedDraggingObject(Gesture gesture)
    {
        return gesture.touchCount == 1
            && gesture.pickedObject == MiterGaugeObject
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_DragStart;
    }

    private bool PlayerIsDragginObject(Gesture gesture)
    {
        return gesture.touchCount == 1
            && gesture.pickedObject == MiterGaugeObject
            && gesture.pickedUIElement == null
            && !gesture.isOverGui
            && gesture.type == EasyTouch.EvtType.On_Drag;
    }
}
