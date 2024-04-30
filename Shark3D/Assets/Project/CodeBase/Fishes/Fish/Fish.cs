using System;
using TMPro;
using UnityEngine;

namespace Assets.Project.CodeBase.Fish
{
    public abstract class Fish : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        private RandomLevelFish _randomLevelFish;

        public event Action<Fish> FishDied;

        public int ScoreLevel { get; private set; }

        private void Awake()
        {
            _randomLevelFish = new RandomLevelFish();

            ScoreLevel = _randomLevelFish.GetRandomLevel();

            _scoreText.text = ScoreLevel.ToString();
        }

        public void Destroys()
        {
            FishDied?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
