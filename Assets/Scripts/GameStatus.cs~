using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour 
{
    // config parameter
    public int pointPerBlockDestroyed = 40;

    //cached reference
    public GameObject gameCanvas;
    public FrameController frameController;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;

    // state variables
    private float totalTime;
    private int totalScore;
    private int totalBlocks;
    private int highestScore;

    void Awake()
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

    void Start()
    {
        SetScoreText();
    }

    // Time
    public void SetTimeText(int playingTime)
    {
        timeText.text = playingTime.ToString();
    }

    public void AddTotalTime(float time)
    {
        totalTime += time;
    }

    public float GetTotalTime()
    {
        return totalTime;
    }

    // Level
    public void SetLevelText()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    // Score
    public void AddtoScore()
    {
        totalScore += pointPerBlockDestroyed;
        SetScoreText();
    }

    public void SetScoreText()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ResetScore()
    {
        totalScore = 0;
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public int GetHighestScore()
    {
        return highestScore;
    }

    public void ResetHighestScore()
    {
         highestScore = 0;
    }

    public void CheckHighestScore()
    {
        if (totalScore > highestScore)
            highestScore = totalScore;
    }

    // Block
    public void AddTotalBlocks(int blocksNumber)
    {
        totalBlocks += blocksNumber;
    }

    public int GetTotalBlocks()
    {
        return totalBlocks;
    }

    //Music
    public AudioSource GetAudioSource()
    {
        return GetComponent<AudioSource>();
    }

    public void SetAudioClip(AudioClip clip)
    {
        GetComponent<AudioSource>().clip = clip;
        if (!GetComponent<AudioSource>().isPlaying)
            GetComponent<AudioSource>().Play();
    }

    public void SetGameCanvas(bool boolean)
    {
        gameCanvas.SetActive(boolean);
    }
}