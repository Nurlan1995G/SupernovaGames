using Assets.Project.CodeBase.Loading;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Project.CodeBase.Logic.Respawn
{
    public class RespawnObject : MonoBehaviour
    {
        private const string PlayerTag = "Player";

        private List<string> _sharkTags = new List<string>()
        {
            "Shark1",
            "Shark2",
        };
        private LoadLevelScene _loadLevelScene;

        private void Update()
        {
            GameObject targetPlayer = StaticClassLogic.FindObject(PlayerTag);

            if (targetPlayer == null)
                Debug.Log("Spawn PLayer");

            FindMiddingShark();
        }

        public void Construct(LoadLevelScene loadLevelScene)
        {
            _loadLevelScene = loadLevelScene;
        }

        private void FindMiddingShark()
        {
            foreach (var sharkTag in _sharkTags)
            {
                GameObject shark = StaticClassLogic.FindObject(sharkTag);

                if(shark == null)
                {
                    Debug.Log("RespawnShark - " + sharkTag);
                    _loadLevelScene.RespawnBotShark(shark);
                }
            }
        }
    }
}
