using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Settlement : MonoBehaviour
{
    GameStatus gameStatus;
    public TextMeshProUGUI totalScoreText;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.CheckHighestScore();
        if (gameStatus != null)
        {
            SetTotalScoreText(
                gameStatus.GetTotalTime(), gameStatus.GetTotalScore(), 
                gameStatus.GetTotalBlocks(), gameStatus.GetHighestScore());
            gameStatus.SetGameCanvas(false);
        }

    }

    private void SetTotalScoreText(
        float totalTime, int totalScore, int totalBlocks, int highestScore)
    {
        totalScoreText.text =
            "Congratulation!\n" +
            "You got it!\n" +
            "Here is you score!\n" +
            "Total Time: " + totalTime.ToString() + "\n" +
            "Total Score: " + totalScore.ToString() + "\n" +
            "Total Block You broke: " + totalBlocks.ToString() + "\n" +
            "Your Highest Score: " + highestScore.ToString() + "\n";
    }
}
