using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Intro : MonoBehaviour
{

    public TextMeshProUGUI highestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.SetGameCanvas(false);
        SetHighestScore(gameStatus.GetHighestScore());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetHighestScore(int highestScore)
    {
        highestScoreText.text = "Highest Score: " + highestScore.ToString();
    }
}
