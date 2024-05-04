using Assets.Project.CodeBase.Fish;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fish fish))
        {
            if (_playerView.ScoreLevel >= fish.ScoreLevel)
            {
                _playerView.AddScore(fish.ScoreLevel);
                fish.Destroys();
            }
        }
    }
}