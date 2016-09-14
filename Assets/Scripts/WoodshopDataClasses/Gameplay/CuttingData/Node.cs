using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
