using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using Assets.Project.CodeBase.SharkEnemy.Static;
using System;
using UnityEngine;

namespace Assets.Project.CodeBase.Loading
{
    public class LoadLevelScene
    {
        private readonly FactoryShark _factoryShark;
        private readonly SharkPositionStaticData _levelStaticData;
        private readonly SpawnerFish _spawnerFish;
        private readonly PlayerView _playerView;
        private readonly SharkStaticData _sharkStaticData;

        public LoadLevelScene(FactoryShark factoryShark, SharkPositionStaticData levelStaticData
            ,SpawnerFish spawnerFish, SharkStaticData sharkStaticData, PlayerView playerView)
        {
            _sharkStaticData = sharkStaticData ?? throw new ArgumentNullException(nameof(sharkStaticData));
            _factoryShark = factoryShark ?? throw new ArgumentNullException(nameof(factoryShark));
            _levelStaticData = levelStaticData ?? throw new ArgumentNullException(nameof(levelStaticData));
            _spawnerFish = spawnerFish ?? throw new ArgumentNullException(nameof(spawnerFish));
            _playerView = playerView ?? throw new ArgumentNullException(nameof(playerView));

            InitShark(levelStaticData);
        }

        public void RespawnBotShark(GameObject gameObject)
        {
            InitShark(_levelStaticData);
        }

        private void InitShark(SharkPositionStaticData levelStaticData)
        {
            CreateSharkScene( levelStaticData.InitSharkOnePosition, AssetAdress.SharkEnemy1);

            CreateSharkScene(levelStaticData.InitSharkTwoPosition, AssetAdress.SharkEnemy2);
        }

        private BotSharkView CreateSharkScene(Vector3 positionShark, string sharkEnemy)
        {
            BotSharkView botShark = _factoryShark.CreateSharkEnemy(sharkEnemy, positionShark);

            botShark.Construct(_spawnerFish, _sharkStaticData, _playerView);

            return botShark;
        }
    }
}
