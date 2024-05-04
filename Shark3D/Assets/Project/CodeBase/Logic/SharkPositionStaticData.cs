using UnityEngine;

[CreateAssetMenu(fileName = "PositionLevel")]
public class SharkPositionStaticData : ScriptableObject
{
    [field: SerializeField] public Vector3 InitSharkOnePosition;
    [field: SerializeField] public Vector3 InitSharkTwoPosition;
}
