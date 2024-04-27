using UnityEngine;

namespace Assets.Project.CodeBase.Fish.Factory
{
    [CreateAssetMenu(fileName = "FishFactory", menuName = "Fish/Factory")]
    public class FishStaticData : ScriptableObject
    {
        [field: SerializeField] public HedgehogFish HedgehogPrefab;
        [field: SerializeField] public BlueSergeonFish BlueSergeonPrefab;
        [field: SerializeField] public ClounFish ClounPrefab;
    }
}
