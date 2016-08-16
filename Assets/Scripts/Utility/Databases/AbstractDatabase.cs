using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Woodshop.Utility.Exceptions;

public abstract class AbstractDatabase<T> : ScriptableObject, IDal<T> where T : IDalAsset
{
    private List<T> _assets;

    protected List<T> Assets
    {
        get
        {
            if (_assets == null)
                _assets = new List<T>();
            return _assets;
        }

        set
        {
            _assets = value;
        }
    }

    protected abstract string DBFilePath { get; }
    protected abstract string DBFileName { get; }
    protected bool ValidateAsset() { return false; }

    public T CreateAsset(T asset)
    {
        throw new NotImplementedException();
    }

    public T RetrieveAsset(float id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> RetrieveAllAssets()
    {
        throw new NotImplementedException();
    }

    public T UpdateAsset(T asset)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsset(float id)
    {
        throw new NotImplementedException();
    }

    public void DeleteAsset(T asset)
    {
        DeleteAsset(asset.ID);
    }

    public int Count()
    {
        throw new NotImplementedException();
    }

    public bool Contains(float id)
    {
        throw new NotImplementedException();
    }

    public bool Contains(T asset)
    {
        return Contains(asset.ID);
    }

    public float GetNextID()
    {
        throw new NotImplementedException();
    }
}
