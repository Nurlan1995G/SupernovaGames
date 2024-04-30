using Assets.Project.CodeBase.Fish;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Fish fish))
        {
            Debug.Log("Соприкосновение произошло");
            Debug.Log(_playerView.ScoreLevel + " - _playerView.Score  PlayerTrigger");

            _playerView.AddScore(fish.ScoreLevel);
            fish.Destroys();
        }
    }
}