using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{
    // cached reference
    public TextMeshProUGUI highestScoreText;

    void Start()
    {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.SetGameCanvas(false);
        SetHighestScore(gameStatus.GetHighestScore());
    }

    public void SetHighestScore(int highestScore)
    {
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }
}