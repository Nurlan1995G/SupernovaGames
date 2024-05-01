using Assets.Project.CodeBase.Fish;
using UnityEngine;

namespace Assets.Project.AssetProviders
{
    public class AssetProvider
    {
        public Fish Instantiate(Fish fish, Vector3 whereToSpawn, Quaternion identity) =>
            Object.Instantiate(fish, whereToSpawn, identity);

        public GameObject Instantiate(string path, Vector3 position) =>
            Object.Instantiate(Resources.Load<GameObject>(path), position, Quaternion.identity);
    }
}