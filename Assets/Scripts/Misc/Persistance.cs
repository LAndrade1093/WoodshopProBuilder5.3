using UnityEngine;
using System.Collections;

/// <summary>
/// Place this script on gameobjects that should be deleted between scenes.
/// e.g. Wood material gameobjects, wood piece gameobjects, MonoBehaviour singeltons, etc.
/// </summary>
public class Persistance : MonoBehaviour
{
    void OnEnable()
    {
        DontDestroyOnLoad(gameObject);
    }
}
