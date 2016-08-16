using UnityEngine;
using System.Collections;

[System.Serializable]
public class GraphEdge
{
    [SerializeField]
    public string NodeOneID = null;
    [SerializeField]
    public string NodeTwoID = null;

    public override bool Equals(object obj)
    {
        if (this == obj) return true;
        if (obj == null || GetType() != obj.GetType()) return false;

        GraphEdge otherEdge = (GraphEdge)obj;
        if (this.NodeOneID != otherEdge.NodeOneID) return false;
        if (this.NodeOneID != otherEdge.NodeOneID) return false;

        return true;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

//public string NodeOneID
//{
//    get { return nodeOneID; }
//    private set { nodeOneID = value; }
//}

//public string NodeTwoID
//{
//    get { return nodeTwoID; }
//    private set { nodeTwoID = value; }
//}

//public GraphEdge(string nodeOneID, string nodeTwoID)
//{
//    this.NodeOneID = nodeOneID;
//    this.NodeTwoID = nodeTwoID;
//}

//public GraphEdge(GraphNode nodeOne, GraphNode nodeTwo)
//{
//    this.NodeOneID = nodeOne.ID;
//    this.NodeTwoID = nodeTwo.ID;
//}
