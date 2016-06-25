using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class SerializableGraphNode
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public int SetIndex;
    [SerializeField]
    public float AssociatedPieceID;
    [SerializeField]
    public List<int> IndexOfConnectedNodes;
}

public class GraphNode
{
    public string _id;
    public float _associatedPieceID;
    public List<GraphNode> _connectedNodes;

    public string ID
    {
        get { return _id; }
        private set { _id = value; }
    }

    public float AssociatedPieceID
    {
        get { return _associatedPieceID; }
        private set { _associatedPieceID = value; }
    }

    public List<GraphNode> ConnectedNodes
    {
        get { return _connectedNodes; }
        private set { _connectedNodes = value; }
    }

    public GraphNode() { this.ConnectedNodes = new List<GraphNode>(); }

    public GraphNode(string id, float pieceID) 
    {
        this.ID = id;
        this.AssociatedPieceID = pieceID;
        this.ConnectedNodes = new List<GraphNode>();
    }

    public GraphNode(string id, float pieceID, List<GraphNode> nodes)
    {
        this.ID = id;
        this.AssociatedPieceID = pieceID;
        if (nodes == null)
        {
            this.ConnectedNodes = new List<GraphNode>();
        }
        else
        {
            this.ConnectedNodes = nodes;
        }
    }

    public bool IsConnectedTo(GraphNode node)
    {
        return ConnectedNodes.Contains(node);
    }

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        GraphNode otherNode = (GraphNode)obj;
        if (this.ID != otherNode.ID) return false;
        if (this.AssociatedPieceID != otherNode.AssociatedPieceID) return false;
        if (this.ConnectedNodes.Count != otherNode.ConnectedNodes.Count) return false;
        for (int i = 0; i < this.ConnectedNodes.Count; i++)
        {
            if (this.ConnectedNodes[i].ID != otherNode.ConnectedNodes[i].ID) return false;
            if (this.ConnectedNodes[i].AssociatedPieceID != otherNode.ConnectedNodes[i].AssociatedPieceID) return false;
        }

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
