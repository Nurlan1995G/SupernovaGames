using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Static;
using System;
using UnityEngine;

namespace Assets.Project.CodeBase.SharkEnemy.Factory
{
    public class FactoryShark
    {
        private readonly AssetProvider _assetProviser;

        public FactoryShark(AssetProvider assetProvider)
        {
            _assetProviser = assetProvider ?? throw new ArgumentNullException(nameof(assetProvider));
        }

        public SharkView CreateSharkEnemy(string sharkEnemy, Vector3 position)
        {
            SharkView shark = _assetProviser.Instantiate(sharkEnemy, position);

            return shark;
        }
    }
}
