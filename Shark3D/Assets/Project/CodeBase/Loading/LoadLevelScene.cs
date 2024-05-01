using Assets.Project.AssetProviders;

namespace Assets.Project.CodeBase.Loading
{
    public class LoadLevelScene
    {
        private PlayerFactory _playerFactory;

        public LoadLevelScene(PlayerFactory playerFactory, LevelStaticData levelStaticData)
        {
            _playerFactory = playerFactory ?? throw new System.ArgumentNullException(nameof(playerFactory));

            InitPlayer(levelStaticData);
        }

        private void InitPlayer(LevelStaticData levelStaticData) =>
            _playerFactory.CreatePlayer(AssetAdress.PlayerShark ,levelStaticData.InitPlayerPosition);
    }
}
