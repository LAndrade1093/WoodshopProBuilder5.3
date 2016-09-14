using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

/// <summary>
/// Any class that will be retrieved from a database
/// Most likely from a database class that inherits from AbstractDatabase
/// </summary>
[System.Serializable]
public class AbstractAsset : IDalAsset {

    [SerializeField]
    private float _id;

    public float ID
    {
        get
        {
            return _id;
        }

        set
        {
            _id = value;
        }
    }

    public AbstractAsset()
    {
        ID = -1f;
    }

    public AbstractAsset(float id)
    {
        ID = id;
    }
    
}
