using Assets.Project.CodeBase.Fish;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

namespace Assets.Project.AssetProviders
{
    public class AssetProvider
    {
        public Fish Instantiate(Fish fish, Vector3 whereToSpawn, Quaternion identity) =>
            Object.Instantiate(fish, whereToSpawn, identity);

        public SharkView Instantiate(string path, Vector3 position) =>
            Object.Instantiate(Resources.Load<SharkView>(path), position, Quaternion.identity);
    }
}