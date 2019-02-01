﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    // config parameter
    [SerializeField] int pointPerBlockDestroyed = 40;
    
    //cached reference
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;
    
    // state variables
    [SerializeField] int currentScore;

    

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }

    private void Start()
    {
        setCurrentScoreZero();
        
    }

    public void setCurrentScoreZero()
    {
        currentScore = 0;
        SetScoreText();
    }

    void Update()
    {
        SetLevelText();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    // TimeText
    public void SetTimeText(float playingTime)
    {
        timeText.text = ((int)playingTime).ToString();
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
        scoreText.text = "Score:" + currentScore.ToString();
    }



}
