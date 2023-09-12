using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText,highScoreText;
    private int score = 0,highScore = 0;

    private void Start() {
        highScore = PlayerPrefs.GetInt("HighScore");
    }

    private void Update() {
        if (scoreText != null && highScoreText != null)
        {
        scoreText.text = score.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();
            
        }
    }

    private void OnCollisionExit(Collision other) {
        score++;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore",highScore);
        }
    }
}
