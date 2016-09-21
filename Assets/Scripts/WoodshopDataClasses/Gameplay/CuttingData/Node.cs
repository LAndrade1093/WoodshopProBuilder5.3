using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A wood piece and all of the other pieces it is adjacent to in the wood material that will be cut.
/// </summary>
public class Node : MonoBehaviour 
{
    private string _nodeID; 
    public List<Node> ConnectedPieces;

    public string NodeID
    {
        get { return _nodeID; }
    }

    void Start()
    {
        _nodeID = gameObject.name;
    }
	
    public void SeverConnection(Node piece)
    {
        ConnectedPieces.Remove(piece);
    }
}
