using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using Assets.Project.CodeBase.SharkEnemy.Static;
using System;

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

        private void InitShark(SharkPositionStaticData levelStaticData)
        {
            BotSharkView botShark1 = _factoryShark.CreateSharkEnemy(AssetAdress.SharkEnemy1, levelStaticData.InitSharkOnePosition);
            BotSharkView botShark2 = _factoryShark.CreateSharkEnemy(AssetAdress.SharkEnemy2, levelStaticData.InitSharkTwoPosition);

            botShark1.Construct(_spawnerFish, _sharkStaticData, _playerView);
            botShark2.Construct(_spawnerFish, _sharkStaticData, _playerView);
        }
    }
}
