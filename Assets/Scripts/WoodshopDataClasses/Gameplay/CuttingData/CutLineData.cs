using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Data that represents the lines being cut in the game
/// </summary>
[System.Serializable]
public class CutLineData : GameplayEntity
{
    public CutLineType CutType; //Used to determine what tool will cut the line and what type of line to use
    public List<Vector3> Checkpoints; //The path of the line
    public List<GraphEdge> EdgesToDisconnect; //The ids of the pieces to separate when the line is cut
    public float Measurement; //The measurement to make from the left (either from the edge of the board or the nearest line from the left)
}