using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;


[CustomEditor(typeof(ParasiteSpawner))]
public class ParasiteSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        ParasiteSpawner myScript = (ParasiteSpawner)target;
        if (GUILayout.Button("Kill Parasites"))
        {
            myScript.KillParasites();
        }
    }
}
#endif