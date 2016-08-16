using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class WoodPieceData : ScriptableObject 
{
    [SerializeField]
    public string ID;
    [SerializeField]
    public List<SnapPointData> SnapPoints;
    [SerializeField]
    public List<ClampPointData> ClampPoints;
    [SerializeField]
    public List<GlueAreaData> GlueAreas;
    [SerializeField]
    public Sprite ButtonIcon;
    [SerializeField]
    public Texture WoodTexture;
    [SerializeField]
    public Vector3 LocalPositionToProject;
    [SerializeField]
    public Vector3 LocalRotationToProject;
    [SerializeField]
    public Vector3 LocalPositionToBoard;
    [SerializeField]
    public Vector3 LocalRotationToBoard;
    [SerializeField]
    public Vector3 Scale;
    [SerializeField]
    public GameObject PieceGameObject;
}
