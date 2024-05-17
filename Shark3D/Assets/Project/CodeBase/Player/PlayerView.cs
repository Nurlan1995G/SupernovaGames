using Assets.Project.CodeBase.SharkEnemy;
using System;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private ScoreLevelBar _scoreLevelBar;
    [SerializeField] private PlayerTrigger _playerTrigger;
    [SerializeField] private float _localScaleX = 0.2f;

    private int _score = 1;

    public int ScoreLevel => _score;

    private int _g = 10;
    public Action<PlayerView> PlayerDied;

    private void Update()
    {
        int increase = _score;
        int score;

        score = increase / _g;

        if (score >= 2)
        {
            transform.localScale += new Vector3(_localScaleX,_localScaleX, _localScaleX);
            _g *= 2;
        }
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreLevelBar.SetScore(_score);
    }

    public void Destroys()
    {
        PlayerDied?.Invoke(this);
        gameObject.SetActive(false);
    }
}