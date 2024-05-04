using Assets.Project.CodeBase.Fish;
using Assets.Project.CodeBase.SharkEnemy;
using UnityEngine;

public class TriggerSharkEnemy : MonoBehaviour
{
    [SerializeField] private SharkView _sharkView;
 
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
    }
}
