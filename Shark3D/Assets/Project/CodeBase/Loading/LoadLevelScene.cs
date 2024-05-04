using Assets.Project.AssetProviders;
using Assets.Project.CodeBase.SharkEnemy.Factory;
using UnityEngine;

namespace Assets.Project.CodeBase.Loading
{
    public class LoadLevelScene
    {
        private FactoryShark _factoryShark;

        public LoadLevelScene(FactoryShark factoryShark, SharkPositionStaticData levelStaticData)
        {
            _factoryShark = factoryShark ?? throw new System.ArgumentNullException(nameof(factoryShark));

            InitShark(levelStaticData);
        }

        private void InitShark(SharkPositionStaticData levelStaticData)
        {
            Debug.Log(levelStaticData.InitSharkOnePosition + " - InitSharkOnePosition");
            Debug.Log(levelStaticData.InitSharkTwoPosition + " - InitSharkTwoPosition");

            _factoryShark.CreateSharkEnemy(AssetAdress.SharkEnemy1, levelStaticData.InitSharkOnePosition);
            _factoryShark.CreateSharkEnemy(AssetAdress.SharkEnemy2, levelStaticData.InitSharkTwoPosition);
        }
    }
}
