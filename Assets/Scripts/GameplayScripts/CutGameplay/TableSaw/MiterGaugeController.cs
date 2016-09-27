using UnityEngine;
using System.Collections;
using HedgehogTeam.EasyTouch;
using UnityEngine.UI;

public class MiterGaugeController : MonoBehaviour
{
    public Rigidbody WoodMaterial;
    public Transform Front;
    public LayerMask ToolLayer;
    public LayerMask WoodLayer;
    public Transform DadoCutSpawnPoint;

    [Header("Movement")]
    public float MinimumLimitZ;
    public float MaximumLimitZ;
    public GameObject MiterGaugeObject;
    public Transform InitialPosition;

    [Header("Rotation")]
    public Transform RotatingPiece;
    public float MinRotation = 45f;
    public float MaxRotation = 135f;

    [Header("UI Content")]
    public Button ShowButton;
    public Button HideButton;
    public Text AngleDisplay;
    public Slider AngleSlider;

    private Vector3 previousPosition;
    private Transform objTransform;
    private float initialRotation = 90f;
    private bool visible; //This determines whether or not miter gauge is on the table
    private bool movementEnabled; //The saw can only be moved when the saw is turned on

    void Awake()
    {
        previousPosition = Vector3.zero;
        objTransform = transform;
        AngleSlider.onValueChanged.AddListener(delegate { RotateMiterGauge(); });
        movementEnabled = false;
        RotateMiterGauge();
        HideMiterGauge();
    }

    void Update()
    {
        if (movementEnabled && visible)
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
    }

    public void EnableMovement(bool enable)
    {
        movementEnabled = enable;
        if(!enable)
        {
            transform.position = InitialPosition.position;
        }
    }

    public void SetAngle(float angle)
    {
        SetAngleText(AngleSlider.value);
        RotatingPiece.localRotation = Quaternion.Euler(0f, AngleSlider.value, 0f);
    }

    public void DisplayMiterGauge()
    {
        gameObject.SetActive(true);
        AngleSlider.value = 90f;
        SetAngle(90.0f);
        transform.position = InitialPosition.position;
        visible = true;
        AngleSlider.interactable = true;
        ShowButton.gameObject.SetActive(false);
        HideButton.gameObject.SetActive(true);
    }

    public void HideMiterGauge()
    {
        WoodMaterial.gameObject.transform.parent = null;
        WoodMaterial.gameObject.GetComponent<BoardController>().enabled = true;
        visible = false;
        AngleSlider.interactable = false;
        AngleSlider.value = 90f;
        SetAngle(90.0f);
        transform.position = InitialPosition.position;
        gameObject.SetActive(false);
        ShowButton.gameObject.SetActive(true);
        HideButton.gameObject.SetActive(false);
    }

    public void SetupMiterGauge()
    {
        if (visible)
        {
            WoodMaterial.rotation = Quaternion.Euler(0f, 0f, 0f);
            WoodMaterial.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            WoodMaterial.gameObject.transform.parent = MiterGaugeObject.transform;
            WoodMaterial.gameObject.GetComponent<BoardController>().enabled = false;
            WoodMaterial.position = new Vector3(0.8f, transform.position.y, transform.position.z);
            RaycastHit hit;
            Ray ray = new Ray(WoodMaterial.position, Vector3.left);
            if (Physics.Raycast(ray, out hit, 100f, ToolLayer))
            {
                RaycastHit hit2;
                Ray ray2 = new Ray(hit.point, Vector3.right);
                if (Physics.Raycast(ray2, out hit2, 100f, WoodLayer))
                {
                    Vector3 gap = hit.point - hit2.point;
                    WoodMaterial.position += gap;
                    WoodMaterial.position = new Vector3(WoodMaterial.position.x, WoodMaterial.position.y, -1.2f);
                    RaycastHit hit3;
                    Ray ray3 = new Ray(Front.position, Vector3.back);
                    if (Physics.Raycast(ray3, out hit3, 100f, WoodLayer))
                    {
                        Vector3 fGap = Front.position - hit3.point;
                        WoodMaterial.position += fGap;
                        WoodMaterial.position = new Vector3(WoodMaterial.position.x, 1.1f, WoodMaterial.position.z);
                    }
                }
            }
        }
    }

    public void SetupMiterGaugeForDadoCut()
    {
        if (visible)
        {
            Transform dadoBlockTransform = WoodMaterial.gameObject.transform;
            dadoBlockTransform.rotation = Quaternion.Euler(0f, 90f, 0f);
            dadoBlockTransform.parent = MiterGaugeObject.transform;
            dadoBlockTransform.gameObject.GetComponent<BoardController>().enabled = false;
            dadoBlockTransform.position = new Vector3(0.8f, transform.position.y, transform.position.z);
            RaycastHit hit;
            Ray ray = new Ray(dadoBlockTransform.position, Vector3.left);
            if (Physics.Raycast(ray, out hit, 100f, ToolLayer))
            {
                RaycastHit hit2;
                Ray ray2 = new Ray(hit.point, Vector3.right);
                if (Physics.Raycast(ray2, out hit2, 100f, WoodLayer))
                {
                    Vector3 gap = hit.point - hit2.point;
                    dadoBlockTransform.position += gap;
                    dadoBlockTransform.position = new Vector3(dadoBlockTransform.position.x, dadoBlockTransform.position.y, -1.2f);
                    RaycastHit hit3;
                    Ray ray3 = new Ray(Front.position, Vector3.back);
                    if (Physics.Raycast(ray3, out hit3, 100f, WoodLayer))
                    {
                        Vector3 fGap = Front.position - hit3.point;
                        dadoBlockTransform.position += fGap;
                        dadoBlockTransform.position = new Vector3(dadoBlockTransform.position.x, DadoCutSpawnPoint.position.y, dadoBlockTransform.position.z);
                    }
                }
            }
        }
    }

    public bool IsVisible()
    {
        return visible;
    }

    private void SetAngleText(float angle)
    {
        float value = angle - 90f;
        string sliderValue = value.ToString();
        AngleDisplay.text = sliderValue;
    }

    private void RotateMiterGauge()
    {
        SetAngle(AngleSlider.value);
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
