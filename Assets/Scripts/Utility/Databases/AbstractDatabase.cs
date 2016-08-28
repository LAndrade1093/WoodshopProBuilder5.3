using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Woodshop.Utility.Exceptions;
using System.Linq;

public abstract class AbstractDatabase<T> : ScriptableObject, IDal<T> where T : IDalAsset
{
    private List<T> _entities;

    protected List<T> Entities
    {
        get
        {
            if (_entities == null)
                _entities = new List<T>();
            return _entities;
        }

        set
        {
            _entities = value;
        }
    }

    protected abstract string DBFilePath { get; }
    protected abstract string DBFileName { get; }
    protected bool ValidateEntity() { return false; }

    public T CreateEntity(T entity)
    {
        if(entity.ID <= -1)
        {
            entity.ID = GetNextID();
        }
        Entities.Add(entity);
        return entity;
    }

    public T RetrieveEntity(float id)
    {
        if(!Contains(id))
        {
            throw new AssetNotFoundException("Could not find "+GetType().ToString()+" entity with an id of "+id);
        }
        T retrievedEntity = Entities.Find(x => x.ID == id);
        return retrievedEntity;
    }

    public List<T> RetrieveAllEntities()
    {
        List<T> listCopy = Entities;
        return listCopy;
    }

    public T UpdateEntity(T entity)
    {
        if(Contains(entity.ID))
        {
            T asset = RetrieveEntity(entity.ID);
            int index = Entities.IndexOf(asset);
            Entities.Insert(index, entity);
        }
        else
        {
            CreateEntity(entity);
        }
        return entity;
    }

    public void DeleteEntity(float id)
    {
        if(Contains(id))
        {
            T asset = RetrieveEntity(id);
            int index = Entities.IndexOf(asset);
            Entities.RemoveAt(index);
        }
    }

    public void DeleteEntity(T entity)
    {
        DeleteEntity(entity.ID);
    }

    public int Count()
    {
        return Entities.Count;
    }

    public bool Contains(float id)
    {
        T retrievedEntity = Entities.Find(x => x.ID == id);
        bool found = (retrievedEntity != null);
        return found;
    }

    public bool Contains(T entity)
    {
        return Contains(entity.ID);
    }

    public float GetNextID()
    {
        float nextID = (from x in Entities select x.ID).Max();
        return nextID + 1;
    }
}
