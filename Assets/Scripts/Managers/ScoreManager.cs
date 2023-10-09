using Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class ScoreManager : GameElement
    {
        public static ScoreManager Instance;
        [SerializeField] private Text _scoreText;
        private int _score;

        private void Awake()
        {
            Instance = this;
        }

        public void IncreaseScore(int value)
        {
            _score += value;
            UpdateScoreText();
        }

        public void UpdateScoreText()
        {
            _scoreText.text = _score.ToString();
        }

        protected override void OnStart()
        {
        }

        protected override void OnGameOver()
        {
            HighScoreActions();
        }

        private void HighScoreActions()
        {
            var currentHighScores = GetHighScores();
            int tmp;
            var newScore = _score;

            for (var i = 0; i < currentHighScores.Length; i++)
            {
                if (newScore > currentHighScores[i])
                {
                    tmp = currentHighScores[i];
                    currentHighScores[i] = newScore;
                    newScore = tmp;
                }

                PlayerPrefs.SetInt($"HighScore{i}", currentHighScores[i]);
            }

            if (_score > currentHighScores[1]) _scoreText.text = $"HIGH SCORE!\n{_score}";
        }

        protected override void OnGameRestart()
        {
            _score = 0;
            UpdateScoreText();
        }

        public int[] GetHighScores()
        {
            var highScores = new int[10];

            for (var i = 0; i <= 9; i++) highScores[i] = PlayerPrefs.GetInt($"HighScore{i}");

            return highScores;
        }
    }
}