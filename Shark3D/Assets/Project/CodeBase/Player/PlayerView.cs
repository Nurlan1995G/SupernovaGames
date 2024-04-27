using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private ScoreLevelBar _scoreLevelBar;

    private int _scoreLevel;

    public int ScoreLevel { get; set; }



}