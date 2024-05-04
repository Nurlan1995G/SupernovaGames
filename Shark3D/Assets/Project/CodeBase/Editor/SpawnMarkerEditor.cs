using Assets.Project.CodeBase.SharkEnemy.Spawner;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SpawnPointEnemy))]
public class SpawnMarkerEditor : UnityEditor.Editor
{
    [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
    public static void RenderCustomGizmo(SpawnPointEnemy spawner, GizmoType gizmo)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(spawner.transform.position, 0.5f);
    }
}
