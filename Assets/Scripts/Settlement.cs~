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
        SetTotalScoreText(gameStatus.GetTotalTime(), 
            gameStatus.GetTotalScore(), gameStatus.GetTotalBlocks());
        gameStatus.SetGameStatusUI(false);
    }

    private void SetTotalScoreText(float totalTime, int totalScore, int totalBlocks)
    {
        totalScoreText.text =
            "Congratulation!\n" +
            "You got it!\n" +
            "Here is you score!\n" +
            "Total Time: " + totalTime.ToString() + "\n" +
            "Total Score: " + totalScore.ToString() + "\n" +
            "Total Block You broke: " + totalBlocks.ToString() + "\n";
    }
}
