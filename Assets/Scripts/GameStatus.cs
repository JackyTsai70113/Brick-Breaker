using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    // config parameter
    [SerializeField] int pointPerBlockDestroyed = 40;
    
    //cached reference
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;

    // state variables
    public int currentScore;

    

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        SetCurrentScoreZero();
        
    }

    public void SetCurrentScoreZero()
    {
        currentScore = 0;
        SetScoreText();
    }

    void Update()
    {
    }

    // TimeText
    public void SetTimeText(int playingTime)
    {
        timeText.text = playingTime.ToString();
    }

    // LevelText
    public void SetLevelText()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    // ScoreText
    public void AddtoScore()
    {
        currentScore += pointPerBlockDestroyed;
        SetScoreText();
    }

    public void SetScoreText()
    {
        scoreText.text = currentScore.ToString();
    }
}
