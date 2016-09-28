using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Helper class that handles how to split the wood material
/// </summary>
public class WoodManagerHelper : MonoBehaviour 
{
    public static void RemoveCutLine(WoodMaterialObject boardToSplit, CutLine detachedLine)
    {
        detachedLine.SeverConnections();
        boardToSplit.RemoveLine(detachedLine);
        Destroy(detachedLine.gameObject);
    }

    /// <summary>
    /// Determines if the Node is a singular wood piece, a leftover wood piece, or a wood material gameobject that 
    /// contains child pieces that still need to be cut out.
    /// </summary>
    /// <param name="node">A Node monobehavior object</param>
    /// <param name="boardToSplit">The wood material gameobject that contains the pieces that will be split</param>
    /// <returns>A gamobject that either a piece, a leftover piece, or a large wood board object</returns>
    private static GameObject DeterminePiece(Node node, ref WoodMaterialObject boardToSplit)
    {
        GameObject objToReturn = null;
        if (node.ConnectedPieces.Count <= 0)
        {
            GameObject obj = node.gameObject;
            obj.transform.parent = null;
            if (obj.tag == "Piece")
            {
                //The Node object is a wood piece
                PieceController controller = obj.GetComponent<PieceController>();
                if (controller == null)
                {
                    controller = obj.AddComponent<PieceController>();
                }
            }
            else if (obj.tag == "Leftover")
            {
                //The Node object is a leftover piece. Run the script that will delete it
                WoodLeftover leftoverScript = obj.GetComponent<WoodLeftover>();
                leftoverScript.BeginDisappearing();
            }
            else
            {
                Debug.LogError(obj.name + " is not tag as Piece or Leftover");
            }
            objToReturn = obj;
        }
        else
        {
            //The Node object is still a child of a wood material. Call the method that will split it from the wood material board.
            GameObject obj = WoodManagerHelper.CreateSeparateBoard(node, ref boardToSplit);
            objToReturn = obj;
        }
        return objToReturn;
    }

    /// <summary>
    /// After a line is cut, this takes care of splitting the wood material at the line
    /// </summary>
    /// <param name="baseNode">A node that will be split by the cut line</param>
    /// <param name="baseNode2">The node that will be split from baseNode by the line</param>
    /// <param name="boardToSplit">The actual wood material object that eill be split</param>
    /// <param name="detachedLine">The line that was cut</param>
    /// <returns>The two objects representing the wood material cut into two separate pieces</returns>
    public static List<GameObject> SplitBoard(Node baseNode, Node baseNode2, WoodMaterialObject boardToSplit, CutLine detachedLine)
    {
        WoodManagerHelper.RemoveCutLine(boardToSplit, detachedLine);

        List<GameObject> splitPieces = new List<GameObject>();
        splitPieces.Add(WoodManagerHelper.DeterminePiece(baseNode, ref boardToSplit));
        splitPieces.Add(WoodManagerHelper.DeterminePiece(baseNode2, ref boardToSplit));
        Destroy(boardToSplit.gameObject);

        return splitPieces;
    }

    /// <summary>
    /// Recursive call to collect all connected nodes
    /// </summary>
    /// <param name="nodes">The list to fill out</param>
    /// <param name="baseNode">The node to start from</param>
    private static void RetrieveNodes(ref List<Node> nodes, Node baseNode)
    {
        nodes.Add(baseNode);
        foreach (Node c in baseNode.ConnectedPieces)
        {
            if (!nodes.Contains(c))
            {
                WoodManagerHelper.RetrieveNodes(ref nodes, c);
            }
        }
    }

    /// <summary>
    /// Separates the pieces of the wood material based on the node passed in.
    /// Using a graph structure, this builds out a new wood material gameobject with the pieces that were
    /// connected to the base node and the base node's children
    /// </summary>
    /// <param name="baseNode">The node to start from</param>
    /// <param name="boardToSplit">The wood material that will be split</param>
    /// <returns>A gameobject representing the split wood material</returns>
    public static GameObject CreateSeparateBoard(Node baseNode, ref WoodMaterialObject boardToSplit)
    {
        //Finds all of the connected nodes that will be part of the new wood material gameobject
        List<Node> nodes = new List<Node>();
        WoodManagerHelper.RetrieveNodes(ref nodes, baseNode);

        GameObject board = new GameObject("WoodStrip");
        board.tag = "WoodStrip";
        WoodMaterialObject woodBoard = board.AddComponent<WoodMaterialObject>();
        List<Node> boardNodes = new List<Node>(); //The pieces for the new wood material gameobject
        List<CutLine> boardLines = new List<CutLine>(); //The lines that belong to the new wood material gameobject
        Bounds boardBounds = new Bounds();
        for (int index = 0; index < nodes.Count; index++)
        {
            Node n = nodes[index];
            boardNodes.Add(n);
            woodBoard.WoodPieces.Add(n.gameObject);
            if (index == 0)
            {
                boardBounds = new Bounds(n.gameObject.transform.position, Vector3.zero);
            }
            else
            {
                boardBounds.Encapsulate(n.gameObject.transform.position);
            }
            //Like the lines, make sure the dado cut areas go to the correct wood material
            if (n.gameObject.tag == "DadoBlock")
            {
                woodBoard.AddDado(n.gameObject.GetComponent<DadoBlock>());
            }
            for (int i = 0; i < boardToSplit.LinesToCut.Count; i++)
            {
                if (boardToSplit.LinesToCut[i] == null)
                {
                    Debug.Log(i + " is null");
                }
                else
                {
                    if (boardToSplit.LinesToCut[i].ContainsPiece(n))
                    {
                        boardLines.Add(boardToSplit.LinesToCut[i]);
                        boardBounds.Encapsulate(boardToSplit.LinesToCut[i].gameObject.transform.position);
                        woodBoard.AddLine(boardToSplit.LinesToCut[i]);
                        boardToSplit.RemoveLine(i--);
                    }
                }
            }
        }

        board.transform.position = boardBounds.center;

        foreach (Node n in boardNodes)
        {
            n.gameObject.transform.parent = board.transform;
        }

        foreach (CutLine line in boardLines)
        {
            line.gameObject.transform.parent = board.transform;
        }
        Rigidbody r = board.AddComponent<Rigidbody>();
        r.useGravity = true;
        return board;
    }
}
