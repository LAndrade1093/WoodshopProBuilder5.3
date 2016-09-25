using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Woodshop.Utility.Exceptions;
using System.Linq;

/// <summary>
/// Parent class for all database classes.
/// </summary>
/// <typeparam name="T">Concrete type of T must implement IDalAsset in order to have an ID for each object</typeparam>
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

    protected abstract List<string> DataFilePaths { get; }

    public virtual T CreateEntity(T entity)
    {
        if(entity.ID <= -1f)
        {
            entity.ID = GetNextID();
        }
        else if(Contains(entity.ID))
        {
            throw new EntityAlreadyExistsException(GetType().ToString() + " entity with an ID of "+ entity.ID + " already exists and another cannot be made with this id");
        }
        Entities.Add(entity);
        return entity;
    }

    public virtual T RetrieveEntity(float id)
    {
        if(!Contains(id))
        {
            throw new EntityNotFoundException("Could not find "+GetType().ToString()+" entity with an ID of "+id);
        }
        T retrievedEntity = Entities.Find(x => x.ID == id);
        return retrievedEntity;
    }

    public virtual List<T> RetrieveAllEntities()
    {
        List<T> listCopy = Entities;
        return listCopy;
    }

    public virtual T UpdateEntity(T entity)
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

    public virtual void DeleteEntity(float id)
    {
        if(Contains(id))
        {
            T asset = RetrieveEntity(id);
            int index = Entities.IndexOf(asset);
            Entities.RemoveAt(index);
        }
    }

    public virtual void DeleteEntity(T entity)
    {
        DeleteEntity(entity.ID);
    }

    public virtual int Count()
    {
        return Entities.Count;
    }

    public virtual bool Contains(float id)
    {
        T retrievedEntity = Entities.Find(x => x.ID == id);
        bool found = (retrievedEntity != null);
        return found;
    }

    public virtual bool Contains(T entity)
    {
        return Contains(entity.ID);
    }

    public float GetNextID()
    {
        float nextID = 0;
        if (Entities != null)
        {
            if (Entities.Count > 0)
            {
                nextID = (from x in Entities select x.ID).Max() + 1;
            }
        }
        return nextID;
    }

    protected abstract void LoadFromDataFile();
}
