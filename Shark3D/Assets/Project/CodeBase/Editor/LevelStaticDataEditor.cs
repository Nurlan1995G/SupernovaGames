using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LevelStaticData))]
public class LevelStaticDataEditor : UnityEditor.Editor
{
    private const string SpawnPointPlayer = "SpawnPointPlayer";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LevelStaticData levelData = (LevelStaticData)target;

        if (GUILayout.Button("Collect"))
        {
            levelData.InitPlayerPosition = GameObject.FindWithTag(SpawnPointPlayer).transform.position;
        }
    }
}
