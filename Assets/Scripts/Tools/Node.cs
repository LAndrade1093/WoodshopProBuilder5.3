﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour 
{
    public List<Node> ConnectedPieces;
    public float pieceID;
	
    public void SeverConnection(Node piece)
    {
        ConnectedPieces.Remove(piece);
    }
}
