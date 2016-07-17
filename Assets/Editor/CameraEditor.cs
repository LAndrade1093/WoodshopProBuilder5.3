using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CameraPanControl))]
public class PanCameraEditor : Editor
{
    //void OnEnable()

    //public override void OnInspectorGUI()
    //{
    //    CameraPanControl control = target as CameraPanControl;
    //    control.EnableCameraBounds = GUILayout.Toggle(control.EnableCameraBounds, "Enable Camera Bounds");

    //}
}

[CustomEditor(typeof(CameraOrbitControl))]
public class OrbitCameraEditor : Editor
{

}