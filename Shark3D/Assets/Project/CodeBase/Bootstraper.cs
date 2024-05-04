using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Fish.Factory;
using Assets.Project.CodeBase.Loading;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private SpawnerFish _spawner;
    [SerializeField] private FishStaticData _fishStaticData;
    [SerializeField] private SharkPositionStaticData _sharkPositionStaticData;

    private void Awake() 
    {
        AssetProvider assetProvider = new AssetProvider();
        RandomServer random = new RandomServer();

        LoadLevelScene loadLevel = new LoadLevelScene(new FactoryShark(assetProvider), _sharkPositionStaticData);

        _spawner.Construct(new FishFactory(_fishStaticData, assetProvider), random);

        _spawner.StartWork();

        random.Construct(_spawner);
    }
}
