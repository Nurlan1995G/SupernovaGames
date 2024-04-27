using Assets.Project.AssetProviders;
using System;
using UnityEngine;

namespace Assets.Project.CodeBase.Fish.Factory
{
    public class FishFactory
    {
        private readonly FishStaticData _fishStaticData;
        private readonly AssetProvider _assetProvider;

        public FishFactory(FishStaticData fishStaticData, AssetProvider assetProvider)
        {
            _fishStaticData = fishStaticData ?? throw new ArgumentNullException(nameof(fishStaticData));
            _assetProvider = assetProvider ?? throw new ArgumentNullException(nameof(assetProvider));
        }

        public Fish GetFish(TypeFish fishType, Vector3 whereToSpawn)
        {
            switch (fishType)
            {
                case TypeFish.Hedgehog:
                    Debug.Log($"Instantiate HedgehogFish");
                    return _assetProvider.Instantiate(_fishStaticData.HedgehogPrefab, whereToSpawn, Quaternion.identity);

                case TypeFish.BlueSergeon:
                    Debug.Log($"Instantiate BlueSergeonFish");
                    return _assetProvider.Instantiate(_fishStaticData.BlueSergeonPrefab, whereToSpawn
                        , Quaternion.identity);

                case TypeFish.Cloun:
                    Debug.Log($"Instantiate ClounFish");
                    return _assetProvider.Instantiate(_fishStaticData.ClounPrefab, whereToSpawn, Quaternion.identity);

                default:
                    throw new InvalidOperationException(nameof(fishType));
            }
        }

        /*public ScoreLevel GetScore() => 
            _assetProvider.Instantiate(AssetAdress.ScoreLevel);*/
    }
}
