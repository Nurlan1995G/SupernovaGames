using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private ScoreLevelBar _scoreLevelBar;
    [SerializeField] private PlayerTrigger _playerTrigger;

    private int _score = 0;

    public int ScoreLevel { get; set; }

    public void AddScore(int score)
    {
        _score += score;
        _scoreLevelBar.SetScore(_score);
    }
}