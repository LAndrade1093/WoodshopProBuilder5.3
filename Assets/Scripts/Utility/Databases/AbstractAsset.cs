using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

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
