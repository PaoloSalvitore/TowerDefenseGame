using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public static int playerScore;

    public static ScoreManager staticScore;

    public void Awake()
    {
        staticScore = this;
    }
    public void AddScore(int score)
    {
        playerScore += score;
        scoreText.text = "Score: " + playerScore;
    }

}
