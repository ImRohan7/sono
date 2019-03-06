using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;


[CustomEditor(typeof(SetPiece))]
public class SetPieceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SetPiece myScript = (SetPiece)target;
        if (GUILayout.Button("Build Set Piece"))
        {
            myScript.DoSetup();
        }
    }
}
#endif