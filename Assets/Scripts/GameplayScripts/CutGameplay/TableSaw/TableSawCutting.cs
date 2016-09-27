using UnityEngine;
using System.Collections;

/// <summary>
/// Replaced by TableSawCut
/// </summary>
public class TableSawCutting : MonoBehaviour 
{
    public TableSawManager manager;
    public Blade sawBlade;
    public CutState CurrentState { get; set; }

    [Header("Valid Line Cutting Distance Limits")]
    public float PerfectLineCutDistance = 0.0025f;
    public float GoodCutDistance = 0.004f;
    public float PassableCutOffset = 0.005f;

    //[Header("Push Rate Variables")]
    //public PushRateTracker pushRate;
    //public float maxStallTime = 3.0f;
    //private float pushRateScoreUpdateTime = 0.1f;

    private CutLine currentLine = null;
    private LineCutScoring currentLineScore = null;
    private bool cuttingAlongLine = false;
    private float totalTimePassed = 0.0f;

    void Start()
    {
        CurrentState = CutState.ReadyToCut;
    }

    void Update()
    {
        //if (manager.StillCutting)
        //{
        //    totalTimePassed += Time.deltaTime;

        //    if (CurrentState == CutState.ReadyToCut)
        //    {
        //        SwitchLine();
        //        if (sawBlade.CuttingWoodBoard && sawBlade.SawBladeActive)
        //        {
        //            Vector3 origin = sawBlade.EdgePosition() + new Vector3(0.0f, 0.5f, 0.0f);
        //            Ray ray = new Ray(origin, Vector3.down);
        //            RaycastHit hit;
        //            if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Piece" || hit.collider.tag == "Leftover"))
        //            {

        //            }
        //        }
        //    }
        //}

        CutLine nearestLine = manager.LinesToCut[0];
        nearestLine.DisplayLine(true, false);
        Vector3 origin = sawBlade.EdgePosition() + new Vector3(0.0f, 0.5f, 0.0f);
        Ray ray = new Ray(origin, Vector3.down);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Piece" || hit.collider.tag == "Leftover")
            {
                float distance = nearestLine.CalculateDistance(hit.point);
            }
        }
    }

    private void SwitchLine()
    {
        CutLine nearestLine = manager.GetNearestLine(sawBlade.transform.position);
        if (nearestLine.IsMarked && nearestLine.LineMark != null)
        {
            if (nearestLine.LineMark.GetComponent<LineMark>().GoodLineMark)
            {
                nearestLine.DisplayLine(true, false);
            }
        }
        if (currentLine != null && currentLine != nearestLine)
        {
            currentLine.DisplayLine(false, true);
        }
        currentLine = nearestLine;
        currentLineScore = nearestLine.gameObject.GetComponent<LineCutScoring>();
    }
}