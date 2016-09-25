using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Base class for storing all gameplay data in a Step object
/// </summary>
/// <typeparam name="T">Concrete type of T must inherit from WoodshopGameplayEntity</typeparam>
public class WoodshopGameplayContainer<T> where T : WoodshopGameplayEntity
{
    private List<T> _gameplayEntities;

    public List<T> GameplayEntities
    {
        get
        {
            if (_gameplayEntities == null)
                _gameplayEntities = new List<T>();
            return _gameplayEntities;
        }
        set { _gameplayEntities = value; }
    }

    public float Count
    {
        get { return GameplayEntities.Count; }
    }

    public float CalculateTotalMaxScore()
    {
        float total = 0f;
        foreach (T gameplay in GameplayEntities)
        {
            total += gameplay.PerfectScore;
        }
        return total;
    }
}