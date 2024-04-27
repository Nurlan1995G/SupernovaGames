using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Fish.Factory;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    //[SerializeField] private ScoreLevel _scoreLevel;
    [SerializeField] private FishStaticData _fishStaticData;

    private void Awake()
    {
        _spawner.Construct(new FishFactory(_fishStaticData, new AssetProvider()));
        _spawner.StartWork();
    }
}
