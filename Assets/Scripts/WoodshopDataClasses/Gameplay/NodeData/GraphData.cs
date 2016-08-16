using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class GraphData : ScriptableObject
{
    public string ID;
    public List<GraphNode> nodeSet = null;
    private List<SerializableGraphNode> serializableNodeSet = new List<SerializableGraphNode>();

    public GraphData() 
    {
        this.nodeSet = new List<GraphNode>();
    }

    public GraphData(List<GraphNode> nodes)
    {
        if (nodes == null)
        {
            this.nodeSet = new List<GraphNode>();
        }
        else
        {
            this.nodeSet = nodes;
        }
    }

    public MethodResult AddNode(GraphNode node)
    {
        MethodResult result;
        if (this.Contains(node.ID))
        {
            result = new MethodResult(message: "There is already a node with this ID, so it cannot be added to the graph.", successful: false, error: ErrorType.UnableToAddNode);
        }
        else
        {
            nodeSet.Add(node);
            result = new MethodResult(successful: true);
        }
        return result;
    }

    public MethodResult AddNode(string id, float pieceID, List<GraphNode> nodes = null)
    {
        MethodResult result;
        if(nodeSet.Any(x => x.ID == id))
        {
            result = new MethodResult(message: "There is already a node with this ID, so it cannot be added to the graph.", successful: false, error: ErrorType.UnableToAddNode);
        }
        else
        {
            GraphNode node = new GraphNode(id, pieceID, nodes);
            result = this.AddNode(node);
        }
        return result;
    }

    public GraphEdge AddConnection(GraphNode fromNode, GraphNode toNode)
    {
        GraphEdge edge = null;
        if (!fromNode.IsConnectedTo(toNode) && !toNode.IsConnectedTo(fromNode))
        {
            fromNode.ConnectedNodes.Add(toNode);
            toNode.ConnectedNodes.Add(fromNode);
            edge = new GraphEdge() { NodeOneID = fromNode.ID, NodeTwoID = toNode.ID };
        }
        return edge;
    }

    public GraphEdge RemoveConnection(GraphNode fromNode, GraphNode toNode)
    {
        GraphEdge edgeRemoved = null;
        if (fromNode.IsConnectedTo(toNode) && toNode.IsConnectedTo(fromNode))
        {
            fromNode.ConnectedNodes.Remove(toNode);
            toNode.ConnectedNodes.Remove(fromNode);
            edgeRemoved = new GraphEdge(){ NodeOneID = fromNode.ID, NodeTwoID = toNode.ID };
        }
        return edgeRemoved;
    }

    public GraphEdge RemoveConnection(GraphEdge edgeToDisconnect)
    {
        GraphNode fromNode = GetByID(edgeToDisconnect.NodeOneID);
        GraphNode toNode = GetByID(edgeToDisconnect.NodeTwoID);
        GraphEdge edge = null;
        if (fromNode != null && toNode != null)
        {
            edge = RemoveConnection(fromNode, toNode);
        }
        return edge;
    }

    public GraphEdge GetEdge(GraphNode fromNode, GraphNode toNode)
    {
        GraphEdge edge = null;
        if (fromNode.IsConnectedTo(toNode) && toNode.IsConnectedTo(fromNode))
        {
            edge = new GraphEdge(){ NodeOneID = fromNode.ID, NodeTwoID = toNode.ID };
        }
        return edge;
    }

    public bool Contains(string nodeID)
    {
        return nodeSet.Any(x => x.ID == nodeID);
    }

    public bool Remove(string nodeID)
    {
        bool successful = true;
        if (this.Contains(nodeID))
        {
            GraphNode nodeToRemove = nodeSet.First(x => x.ID == nodeID);
            nodeSet.Remove(nodeToRemove);
            foreach (GraphNode currentNode in nodeSet)
            {
                int connectionIndex = currentNode.ConnectedNodes.IndexOf(nodeToRemove);
                if (connectionIndex != -1)
                {
                    this.RemoveConnection(nodeToRemove, currentNode);
                }
            }
        }
        else
        {
            successful = false;
        }

        return successful;
    }

    public int Count
    {
        get { return nodeSet.Count; }
    }

    public void Save()
    {
        if (nodeSet.Count > 0)
        {
            serializableNodeSet.Clear();
            AddToSerialzedNodeList(nodeSet[0]);
        }
    }

    public void Load()
    {
        if (serializableNodeSet.Count > 0)
        {
            nodeSet.Clear();
            bool[] deserializedNodeFlag = new bool[serializableNodeSet.Count];
            for (int i = 0; i < deserializedNodeFlag.Length; i++ )
            {
                deserializedNodeFlag[i] = false;
            }
            ReadFromSerialzedNodeList(0, deserializedNodeFlag);
        }
    }

    private void AddToSerialzedNodeList(GraphNode node)
    {
        SerializableGraphNode sgn = new SerializableGraphNode()
        {
            ID = node.ID,
            AssociatedPieceID = node.AssociatedPieceID,
            IndexOfConnectedNodes = new List<int>()
        };
        serializableNodeSet.Add(sgn);
        foreach (GraphNode cn in node.ConnectedNodes)
        {
            if (serializableNodeSet.Any(x => x.ID == cn.ID))
            {
                int index = serializableNodeSet.IndexOf(serializableNodeSet.First(x => x.ID == cn.ID));
                sgn.IndexOfConnectedNodes.Add(index);
            } 
            else 
            {
                AddToSerialzedNodeList(cn);
            }
        }
    }

    private GraphNode ReadFromSerialzedNodeList(int serializedNodeIndex, bool[] deserializedNodeFlag)
    {
        SerializableGraphNode sgn = serializableNodeSet[serializedNodeIndex];
        GraphNode newNode = new GraphNode(sgn.ID, sgn.AssociatedPieceID);
        nodeSet.Add(newNode);
        int indexInSet = nodeSet.IndexOf(newNode);
        deserializedNodeFlag[serializedNodeIndex] = true;

        for (int i = 0; i < sgn.IndexOfConnectedNodes.Count; i++)
        {
            int serializedChildIndex = sgn.IndexOfConnectedNodes[i];
            bool childIsDeserialized = deserializedNodeFlag[serializedChildIndex];
            if (childIsDeserialized)
            {
                string childID = serializableNodeSet[serializedChildIndex].ID;
                bool childNodeFound = false;
                for (int setIndex = 0; setIndex < nodeSet.Count && !childNodeFound; setIndex++)
                {
                    if (nodeSet[setIndex].ID == childID)
                    {
                        childNodeFound = true;
                        nodeSet[indexInSet].ConnectedNodes.Add(nodeSet[setIndex]);
                    }
                }
            }
            else
            {
                nodeSet.Add(ReadFromSerialzedNodeList(serializedChildIndex, deserializedNodeFlag));
            }
        }

        return newNode;
    }

    private GraphNode GetByID(string nodeID)
    {
        GraphNode node = null;
        for (int i = 0; i < nodeSet.Count; i++)
        {
            if (nodeSet[i].ID == nodeID)
            {
                node = nodeSet[i];
                break;
            }
        }
        return node;
    }
}
