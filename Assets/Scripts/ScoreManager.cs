using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
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

    public void OnGameOver()
    {
        HighScoreActions();
    }

    private void HighScoreActions()
    {
        int[] currentHighScores = GetHighScores();
        int tmp;
        int newScore = _score;

        for (int i = 0; i < currentHighScores.Length; i++)
        {
            if (newScore > currentHighScores[i])
            {
                tmp = currentHighScores[i];
                currentHighScores[i] = newScore;
                newScore = tmp;
            }
            
            PlayerPrefs.SetInt($"HighScore{i}", currentHighScores[i]);
        }

        if (_score > currentHighScores[1])
        {
            _scoreText.text = $"HIGH SCORE!\n{_score}";
        }
    }

    public void OnGameRestart()
    {
        _score = 0;
        UpdateScoreText();
    }

    public int[] GetHighScores()
    {
        int[] highScores = new int[10];
        
        for (int i = 0; i <= 9; i++)
        {
            highScores[i] = PlayerPrefs.GetInt($"HighScore{i}");
        }

        return highScores;
    }

}
