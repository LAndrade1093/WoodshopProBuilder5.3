using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;
using UnityEngine.UI;

public class MiterGaugeController : MonoBehaviour
{
    [Header("Movement")]
    public float MinimumLimitZ;
    public float MaximumLimitZ;
    public GameObject MiterGaugeObject;

    [Header("Rotation")]
    public Transform RotatingPiece;
    public float MinRotation = 45f;
    public float MaxRotation = 135f;
    public Text AngleDisplay;
    public Slider AngleSlider;

    private Vector3 previousPosition;
    private Transform objTransform;

    void Start()
    {
        previousPosition = Vector3.zero;
        objTransform = transform;
        AngleSlider.onValueChanged.AddListener(delegate { RotateMiterGauge(); });
        RotateMiterGauge();
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

    private void RotateMiterGauge()
    {
        float value = AngleSlider.value - 90f;
        string sliderValue = value.ToString();
        AngleDisplay.text = sliderValue;

        RotatingPiece.localRotation = Quaternion.Euler(0f, AngleSlider.value, 0f);
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
