using System;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    [SerializeField] private Text _scoreText;
    private int _score = 0;
    

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
}
