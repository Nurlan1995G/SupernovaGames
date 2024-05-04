using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SharkPositionStaticData))]
public class LevelStaticDataEditor : UnityEditor.Editor
{
    private const string SharkEnemy1 = "Shark1";
    private const string SharkEnemy2 = "Shark2";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SharkPositionStaticData levelData = (SharkPositionStaticData)target;

        if (GUILayout.Button("Collect"))
        {
            levelData.InitSharkOnePosition = GameObject.FindWithTag(SharkEnemy1).transform.position;
            levelData.InitSharkTwoPosition = GameObject.FindWithTag(SharkEnemy2).transform.position;
        }

        EditorUtility.SetDirty(target);
    }
}
