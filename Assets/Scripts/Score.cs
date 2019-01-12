using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text highScoreText;
    public Text scoreText;

    private int highScore;
    private int score;

    private string highScoreKey = "highScore";

    private void Start()
    {
        Initialize();
    }

    void Update () {

        if (score > highScore)
        {
            highScore = score;
        }

        highScoreText.text = "High Score : " + highScore.ToString();
        scoreText.text = "Score : " + score.ToString();

	}

    private void Initialize()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        Debug.Log(highScore);
    }

    public void addPoint(int point)
    {
        score = score + point;
    }

    public void Save()
    {
        PlayerPrefs.SetInt(highScoreKey, highScore);
        PlayerPrefs.Save();

        Initialize();
    }
}
