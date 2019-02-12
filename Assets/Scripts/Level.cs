using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    // cached reference
    public GameStatus gameStatus;
    public FrameController frameController;

    public GameObject paddle;
    public GameObject separatedPaddle;
    public GameObject activePaddle;
    public Transform balls;
    public Transform fortuneSquares;

    public List<GameObject> ballList;
    public List<string> blockList;

    public AudioClip winAudio;
    public AudioClip loseAudio;
    public AudioClip goodFortuneSquareSound;
    public AudioClip badFortuneSquareSound;

    // config parameters
    [Range(0.1f, 10f)] public float gameSpeed = 1f;
    [SerializeField] int breakableBlocks;
    public bool isAutoPlayEnabled;

    // state variables
    private float startingTime;
    private float playingTime;
    private float ballNumber;
    private bool isWorking;
    Coroutine SeparatePaddleCoroutine;

    private void Start()
    {
        ResetLevel();
        ResetFrame();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        if (isWorking)
        {
            playingTime = Time.time - startingTime;
            gameStatus.SetTimeText((int)playingTime);
        }
    }

    private void ResetFrame()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.SetLevelText();
        gameStatus.SetGameCanvas(true);
        frameController = gameStatus.frameController;
        gameStatus.frameController.ResetFrame();
    }

    private void ResetLevel()
    {
        startingTime = Time.time;
        isWorking = true;
        separatedPaddle.gameObject.SetActive(false);
        activePaddle = paddle;
        paddle.GetComponent<Paddle>().StartLevel();
        separatedPaddle.GetComponent<Paddle>().StartLevel();
    }

    private void StopLevel()
    {
        isWorking = false;
        paddle.GetComponent<Paddle>().StopLevel();
        separatedPaddle.GetComponent<Paddle>().StopLevel();
    }

    public void CountBlocks()
    {
        breakableBlocks++;
    }

    public void AddBlockList(string objectName, float timesHit)
    {
        for (int i = 0; i < blockList.Count; i++)
            if (blockList[i].Contains(objectName))
            {
                blockList.RemoveAt(i);
                break;
            }
        blockList.Add(objectName + " " + timesHit.ToString());
        blockList.Sort();
    }

    public void AddBallList(GameObject ballObject)
    {
        for (int i = 0; i < ballList.Count; i++)
            if (ballList[i] == ballObject)
            {
                ballList.RemoveAt(i);
                break;
            }
        ballList.Add(ballObject);
        ballList.Sort();
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        gameStatus.AddTotalBlocks(1);
        gameStatus.AddtoScore();
        if (breakableBlocks <= 0)
        {
            AudioSource.PlayClipAtPoint(
                winAudio, Camera.main.transform.position);
            StopLevel();
            gameStatus.AddTotalTime(playingTime);
            frameController.DropWinFrame();
        }
    }

    public bool IsLevelWorking()
    {
        return isWorking;
    }

    public float GetBallNumber()
    {
        return ballNumber;
    }

    public void AddBallNumber()
    {
        ballNumber++;
    }

    public void MinusBallNumber()
    {
        ballNumber = ballNumber - 1;
        if (ballNumber <= 0)
        {
            AudioSource.PlayClipAtPoint(
                loseAudio, Camera.main.transform.position);
            gameStatus.AddTotalTime(playingTime);
            StopLevel();
            frameController.DropLoseFrame();
        }
    }

    public void CheckForSeparatingPaddle(float duration)
    {
        if (SeparatePaddleCoroutine != null)
            StopCoroutine(SeparatePaddleCoroutine);
        SeparatePaddleCoroutine = StartCoroutine(SeparatePaddle(duration));
    }

    private IEnumerator SeparatePaddle(float duration)
    {
        separatedPaddle.SetActive(true);
        separatedPaddle.transform.position = paddle.transform.position;
        paddle.SetActive(false);
        activePaddle = separatedPaddle;
        yield return new WaitForSeconds(duration);
        paddle.gameObject.SetActive(true);
        paddle.transform.position = separatedPaddle.transform.position;
        separatedPaddle.gameObject.SetActive(false);
        activePaddle = paddle;
    }

    public void TriggerGoodFortuneSquareSound()
    {
        AudioSource.PlayClipAtPoint(
            goodFortuneSquareSound, Camera.main.transform.position);
    }

    public void TriggerBadFortuneSquareSound()
    {
        AudioSource.PlayClipAtPoint(
            badFortuneSquareSound, Camera.main.transform.position);
    }

    public void ResetSizeOfAllBalls(float sizeX, float sizeY, float sizeZ)
    {
        foreach (Ball ball in balls.GetComponentsInChildren<Ball>())
            ball.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }
}