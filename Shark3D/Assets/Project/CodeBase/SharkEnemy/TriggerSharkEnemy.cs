using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

public class TriggerSharkEnemy : MonoBehaviour
{
    [SerializeField] private SharkModel _sharkView;
 
    private void OnTriggerEnter(Collider other) 
    {
         if(other.TryGetComponent(out Fish fish))
         {
            if (_sharkView.ScoreLevel >= fish.ScoreLevel)
            {
                _sharkView.AddScore(fish.ScoreLevel);
                fish.Destroys();
            }
         }

         if(other.TryGetComponent(out PlayerView playerView))
         {
            if(_sharkView.ScoreLevel >= playerView.ScoreLevel)
            {
                Debug.Log("Акула бот убила ИГРОКА");
            }
         }
    }
}
