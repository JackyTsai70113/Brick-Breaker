using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{

    // config parameters
    [Range(0.1f, 10f)] [SerializeField] public float gameSpeed = 1f;
    [SerializeField] int breakableBlocks;

    // state variables
    private float startingTime;
    private float playingTime;
    private bool isWorking;
    [SerializeField] int ballNumber;
    [SerializeField] bool ifSeparatedPaddleActivate;

    private float paddleSeparateStartingTime;
    private float paddleSeparateTimeLength = 3f;
    private bool ifPaddleSeparate;

    private float SFXStartingTime;
    private float SFXTimeLength = 1f;
    private bool ifSFXStart;
    // cached reference
    GameStatus gameStatus;
    Frame frame;
    AudioSource myAudioSource;
    [SerializeField] GameObject paddle;
    [SerializeField] GameObject separatedPaddle;
    [SerializeField] AudioClip goodFortuneSquareSound;
    [SerializeField] AudioClip badFortuneSquareSound;
    



    public void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        frame = FindObjectOfType<Frame>();
        startingTime = Time.time;
        isWorking = true;
        frame.ResetFrame();
        gameStatus.SetLevelText();
        gameStatus.SetTimeText(0f);
        ballNumber = 1;
        SeparatePaddle(ifSeparatedPaddleActivate);
        myAudioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        playingTime = Time.time - startingTime;
        if (isWorking)
        {
            gameStatus.SetTimeText(playingTime);
            if (ifSFXStart && Time.time - SFXStartingTime >= SFXTimeLength)
            {
                ifSFXStart = false;
                myAudioSource.Stop();
            }
            if (ifSeparatedPaddleActivate &&
                Time.time - paddleSeparateStartingTime >= paddleSeparateTimeLength)
            {
                ifSeparatedPaddleActivate = false;
                SeparatePaddle(ifSeparatedPaddleActivate);
            }
        }

    }
    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        gameStatus.AddtoScore();
        if (breakableBlocks <= 0)
        {
            frame.DropWinFrame();
            
            StopLevelWorking();
        }
    }

    public void StopLevelWorking()
    {
        isWorking = false;
    }

    public bool IsLevelWorking()
    {
        return isWorking;
    }

    public int ReturnBallNumber()
    {
        return ballNumber;
    }

    public void AddBallNumber()
    {
        ballNumber++;
    }

    public void MinusBallNumber()
    {
        ballNumber--;
    }

    public void MakePaddleSeparated(bool ifActivate)
    {
        ifSeparatedPaddleActivate = ifActivate;
        playSoundEffect("bad");
        paddleSeparateStartingTime = Time.time;
        SeparatePaddle(ifSeparatedPaddleActivate);
    }
    public void SeparatePaddle(bool ifSeparatedPaddleActivate)
    {
        Debug.Log("SeparatePaddle(" + ifSeparatedPaddleActivate + ")"); //還有問題
        paddle.SetActive(!(ifSeparatedPaddleActivate));
        separatedPaddle.SetActive(ifSeparatedPaddleActivate);
    }


    public void playSoundEffect(string soundType)
    {
        AudioClip clip = null;
        ifSFXStart = true;
        SFXStartingTime = Time.time;
        if (soundType == "good")
        {
            clip = goodFortuneSquareSound;
        }
        else if (soundType == "bad")
        {
            clip = badFortuneSquareSound;
        }
        myAudioSource.PlayOneShot(clip);
    }



    

}
