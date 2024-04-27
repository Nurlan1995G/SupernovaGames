using TMPro;
using UnityEngine;

public class ScoreLevel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private RandomLevelFish _levelFish;

    private void Awake()
    {
        _levelFish = new RandomLevelFish();
        int scoreLevel = _levelFish.GetRandomLevel();

        _scoreText.text = scoreLevel.ToString();
    }
}
