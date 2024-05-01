using UnityEngine;

[CreateAssetMenu(fileName = "PositionLevel")]
public class LevelStaticData : ScriptableObject
{
    [field: SerializeField] public Vector3 InitPlayerPosition;
}
