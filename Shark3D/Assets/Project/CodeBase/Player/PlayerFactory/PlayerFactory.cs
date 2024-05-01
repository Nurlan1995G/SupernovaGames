using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.Player.Statica;
using UnityEngine; 

    public class PlayerFactory
    {
        private readonly AssetProvider _assetProvider;
        private readonly PlayerStaticData _playerStaticData;

        public PlayerFactory(AssetProvider assetProvider, PlayerStaticData playerStaticData)
        {
            _assetProvider = assetProvider ?? throw new System.ArgumentNullException(nameof(assetProvider));
            _playerStaticData = playerStaticData ?? throw new System.ArgumentNullException(nameof(playerStaticData));
        }

        public GameObject CreatePlayer(string path, Vector3 position)
        {
            GameObject gameObject = _assetProvider.Instantiate(path, position);

            return gameObject;
        }
    }
