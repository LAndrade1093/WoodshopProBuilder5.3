using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Data that represents the lines being cut in the game
/// </summary>
[System.Serializable]
public class CutLineData : WoodshopGameplayEntity
{
    //NOTE: PieceNodeID is used to determine what wood material the line belongs to, not necessarily what piece
    public CutLineType CutType; //Used to determine what tool will cut the line and what type of line to use
    public List<Vector3> Checkpoints; //The path of the line
    public List<GraphEdge> EdgesToDisconnect; //The ids of the pieces to separate when the line is cut
    public LineMeasurement Measurement; 
}

public class LineMeasurement
{
    public float FirstMeasurement; //The measurement to make from the left (either from the edge of the board or the nearest line from the left)
    public float IsAngled; //Determines if the cut must be angled
    public float SecondMeasurement; //If angled, this is the measurement for the other end of the line (also from the left)
    public float Angle; //The angle the piece must be in when cut
}