using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Fish.Factory;
using Assets.Project.CodeBase.Loading;
using Assets.Project.CodeBase.Player.Statica;
using UnityEngine;

public class Bootstraper : MonoBehaviour
{
    [SerializeField] private SpawnerFish _spawner;
    [SerializeField] private FishStaticData _fishStaticData;
    [SerializeField] private PlayerStaticData _playerStaticData;

    private void Awake() 
    {
        AssetProvider assetProvider = new AssetProvider();
        RandomServer random = new RandomServer();
        LoadLevelScene loadLevel = new LoadLevelScene(new PlayerFactory(assetProvider, new PlayerStaticData())
            , new LevelStaticData());

        _spawner.Construct(new FishFactory(_fishStaticData, assetProvider), random);

        _spawner.StartWork();
    }
}
