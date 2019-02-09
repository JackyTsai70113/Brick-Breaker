using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    // config parameter
    public int pointPerBlockDestroyed = 40;

    public GameObject playSpace;
    public GameObject gameCanvas;
    public FrameController frameController;
    public LoseCollider[] loseColliders;

    //cached reference
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI scoreText;

    private float totalTime;
    private int totalScore;
    private int totalBlocks;

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
        SetFrameController();
        SetLoseColliders();
        SetScoreText();
    }

    private void SetFrameController()
    {
        frameController = GetComponentInChildren<FrameController>();
    }

    public FrameController GetFrameController()
    {
        SetFrameController();
        return frameController;
    }

    private void SetLoseColliders()
    {
        loseColliders = GetComponentsInChildren<LoseCollider>();
    }

    public LoseCollider[] GetLoseColliders()
    {
        return loseColliders;
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

    public void ResetScoreText()
    {
        totalScore = 0;
        scoreText.text = totalScore.ToString();
    }

    public int GetTotalScore()
    {
        return totalScore;
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

    public void SetGameStatusUI(bool boolean)
    {
        playSpace.SetActive(boolean);
        gameCanvas.SetActive(boolean);
    }
}
