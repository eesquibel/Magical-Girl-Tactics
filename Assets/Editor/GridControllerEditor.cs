using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(GridController))]
public class GridControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridController myScript = (GridController)target;
        if (GUILayout.Button("Move Object"))
        {
            myScript.transform.position = GameManager.Instance.Grid2World(myScript.GridPosition);
        }
    }
}
