using UnityEngine;
using System.Collections;

/// <summary>
/// Set up a cubical boundary for an object that can be moved
/// </summary>
[System.Serializable]
public class CubeBoundary
{
    public float MaxBoundsX;
    public float MinBoundsX;
    public float MaxBoundsY;
    public float MinBoundsY;
    public float MaxBoundsZ;
    public float MinBoundsZ;
}
