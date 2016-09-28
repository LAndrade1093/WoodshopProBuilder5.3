using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/* NOTES:
 * This is still pretty basic. It's meant to replace the list in most of the game manager classes that hold the available wood materials.
 * Basically, this is meant to be a container class with accessors for getting the available wood material gameobjects while the 
 * player is working on a project. The wood materials or pieces could be retrieved based on their gameobject name, tag, or id.
 * It should also take care of calling the classes in the WoodManagerHelper class when splitting the wood material.
 */

/// <summary>
/// Class designed to contain the wood material pieces used in a project.
/// Once a project starts, all of the wood materials needed are loade in anf saved here to use in a project.
/// </summary>
public class WoodMaterialManager : MonoBehaviour 
{
    public List<GameObject> WoodMaterials;

    public List<GameObject> GetRevealedPieces()
    {
        List<GameObject> materials = new List<GameObject>();
        foreach (GameObject go in WoodMaterials)
        {
            if (go.tag == "Piece")
            {
                materials.Add(go);
            }
        }
        return materials;
    }

    public List<GameObject> GetAllWoodMaterials()
    {
        return WoodMaterials;
    }

    public void HideAllPieces()
    {
        foreach (GameObject go in WoodMaterials)
        {
            go.transform.position = Vector3.zero;
            go.transform.rotation = Quaternion.identity;
            go.SetActive(false);
        }
    }

    public void HidePiece(GameObject woodMaterial)
    {
        woodMaterial.transform.position = Vector3.zero;
        woodMaterial.transform.rotation = Quaternion.identity;
        woodMaterial.SetActive(false);
    }
}