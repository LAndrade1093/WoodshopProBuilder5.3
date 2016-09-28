using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Notes:
 * On the table saw, chop saw, and band saw, the idea is that a perfect cut is made if the player cuts at a decent speed and as close
 * to the line as possible. The score is lowered if they cut too far from the line and if they push the wood against the blade
 * too fast or too slow. Lose enough points, and the player loses, forcing them to lose valuable materials and start over.
 * Currently, the band saw's score is not affected by the speed.
 */

/// <summary>
/// Class that handles detecting the line being cut and how it affects the score
/// </summary>
public class TableSawCut : MonoBehaviour 
{
    public TableSawManager manager;
    public Blade SawBlade;
    public float ValidCutOffset = 0.005f; //The distance the blade can be at before the player starts losing points
    public float MaxStallTime = 3.0f;
    public FeedRate FeedRateTracker;
    public CutState CurrentState { get; set; }

    private CutLine currentLine = null;
    private bool cuttingAlongLine = false;
    private Vector3 currentPiecePosition;
    private Vector3 previousPiecePosition;
    
    private float playerFeedRate = 0.0f;
    private float playerSmoothingVelocity = 0.0f;

    private float totalTimePassed = 0.0f;
    private float timeUpdateFrequency = 0.1f;

    private float totalTimeStalling = 0.0f;

    private float timeNotCuttingLine = 0.0f;

    void Start()
    {
        CurrentState = CutState.ReadyToCut;
    }

    /// <summary>
    /// Finds the nearest marked line and highlights it
    /// </summary>
    private void SwitchLine()
    {
        CutLine nearestLine = manager.GetNearestLine(SawBlade.transform.position);
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
    }

    /// <summary>
    /// When the blade hits the wood material, set up the blade edge to better track how close the blade is to the line.
    /// </summary>
    /// <param name="cutStartPoint">The point at which the blade hit the wood material</param>
    private void StartWoodCutting(Vector3 cutStartPoint)
    {
        SawBlade.SetEdgePosition(cutStartPoint);
        currentLine.DetermineCutDirection(SawBlade.EdgePosition());

        float distanceFromBlade = currentLine.CalculateDistance(SawBlade.EdgePosition());
        cuttingAlongLine = (distanceFromBlade <= ValidCutOffset);
        //If the blade is already to far from the line, change the score in the Feed Rate
        if (cuttingAlongLine && distanceFromBlade >= 0.003f)
        {
            FeedRateTracker.ReduceScoreDirectly(0.5f);
        }
        else if (!cuttingAlongLine)
        {
            FeedRateTracker.ReduceScoreDirectly(1.0f);
        }
        //Restrict the movement of the board to just the z direction
        manager.RestrictCurrentBoardMovement(false, true);
        previousPiecePosition = manager.GetCurrentBoardPosition();
        CurrentState = CutState.Cutting;
        totalTimePassed = 0.0f;
    }

    private float TrackPushRate()
    {
        Vector3 deltaVector = currentPiecePosition - previousPiecePosition;
        deltaVector = new Vector3(deltaVector.x, 0.0f, deltaVector.z);
        float unitsPerSecond = deltaVector.magnitude / Time.deltaTime;
        return Mathf.SmoothDamp(playerFeedRate, unitsPerSecond, ref playerSmoothingVelocity, 0.3f);
    }

    private void UpdateFeedRateData()
    {
        if (SawBlade.SawBladeActive)
        {
            playerFeedRate = TrackPushRate();
        }
        else
        {
            playerFeedRate = 0.0f;
        }
        FeedRateTracker.UpdateDataDisplay(playerFeedRate);
    }

    void Update()
    {
        #region CuttingCode
        if (manager.StillCutting)
        {
            currentPiecePosition = manager.GetCurrentBoardPosition();
            totalTimePassed += Time.deltaTime;
            UpdateFeedRateData();

            //Waiting for the wood material to touch the blade
            if (CurrentState == CutState.ReadyToCut)
            {
                SwitchLine();

                //The blade has touched the wood material
                if (SawBlade.CuttingWoodBoard && SawBlade.SawBladeActive)
                {
                    Vector3 origin = SawBlade.EdgePosition() + new Vector3(0.0f, 0.5f, 0.0f);
                    Ray ray = new Ray(origin, Vector3.down);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit) && (hit.collider.tag == "Piece" || hit.collider.tag == "Leftover"))
                    {
                        StartWoodCutting(hit.point);
                    }
                }
            }
            //The blade is now cutting the wood material
            else if (CurrentState == CutState.Cutting && SawBlade.SawBladeActive)
            {
                if (cuttingAlongLine)
                {
                    currentLine.UpdateLine(SawBlade.EdgePosition());
                    if (currentLine.LineIsCut())
                    {
                        CurrentState = CutState.EndOfCut;
                    }
                    else
                    {
                        if (totalTimePassed >= timeUpdateFrequency)
                        {
                            totalTimePassed = 0.0f;
                            totalTimeStalling = 0.0f;
                            FeedRateTracker.UpdateScoreWithRate(playerFeedRate);
                        }
                        if (FeedRateTracker.RateTooSlow || FeedRateTracker.RateTooFast)
                        {
                            totalTimeStalling += Time.deltaTime;
                            FeedRateTracker.ReduceScoreDirectly(0.1f);
                            if (totalTimeStalling >= MaxStallTime && FeedRateTracker.RateTooSlow)
                            {
                                manager.StopGameDueToLowScore("You were cutting too slow, now the wood is burnt.");
                            }
                            else if (totalTimeStalling >= 1.0f && FeedRateTracker.RateTooFast)
                            {
                                manager.StopGameDueToLowScore("You were cutting too fast and caused the saw to bind.");
                            }
                        }
                    }
                }
                else
                {
                    if (SawBlade.NoInteractionWithBoard)
                    {
                        timeNotCuttingLine = 0.0f;
                        CurrentState = CutState.ReadyToCut;
                        SawBlade.ResetEdgePosition();
                        currentLine = null;
                        manager.RestrictCurrentBoardMovement(false, false);
                    }
                    else
                    {
                        timeNotCuttingLine += Time.deltaTime;
                        if (totalTimePassed >= timeUpdateFrequency)
                        {
                            totalTimePassed = 0.0f;
                            FeedRateTracker.ReduceScoreDirectly(1.0f);
                        }
                        if (timeNotCuttingLine >= MaxStallTime)
                        {
                            manager.StopGameDueToLowScore("You were not cutting along the line, and now the board is ruined.");
                        }
                    }
                }
            }
            else if (CurrentState == CutState.EndOfCut)
            {
                if (!SawBlade.CuttingWoodBoard && SawBlade.NoInteractionWithBoard)
                {
                    manager.DisplayScore(FeedRateTracker);
                    manager.SplitMaterial(currentLine);
                    cuttingAlongLine = false;
                    currentLine = null;
                    SawBlade.ResetEdgePosition();
                    CurrentState = CutState.ReadyToCut;
                    FeedRateTracker.ResetFeedRate();
                }
            }
        }
        previousPiecePosition = currentPiecePosition;
        if (FeedRateTracker.GetLineScore() <= 0.0f)
        {
            manager.StopGameDueToLowScore("This cut is too messed up to keep going.");
        }
        if (totalTimePassed >= timeUpdateFrequency)
        {
            totalTimePassed = 0.0f;
        }
        #endregion
    }

    void OnDisable()
    {
        if (currentLine != null)
        {
            currentLine.DisplayLine(false, true);
            currentLine = null;
        }
        CurrentState = CutState.ReadyToCut;
        SawBlade.ResetEdgePosition();
    }
}