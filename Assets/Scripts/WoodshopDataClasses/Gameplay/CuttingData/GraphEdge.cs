using UnityEngine;
using System.Collections;

/// <summary>
/// A connection between two nodes in the wood material.
/// </summary>
[System.Serializable]
public class GraphEdge
{
    public string FirstNodeID;
    public string SecondNodeID;
}
