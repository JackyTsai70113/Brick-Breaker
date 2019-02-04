using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour
{
    // determine breakable blocks
    // config parameters
    [Range(0.1f, 10f)] public float gameSpeed = 1f;
    [SerializeField] int breakableBlocks;

    // state variables
    private float startingTime;
    private int playingTime;
    private bool isWorking;
    public int ballNumber;
    Coroutine SeparatePaddleCoroutine;

    // cached reference
    GameStatus gameStatus;
    FrameController frameController;
    public GameObject paddle;
    public GameObject separatedPaddle;
    public AudioClip loseAudio;
    public AudioClip goodFortuneSquareSound;
    public AudioClip badFortuneSquareSound;

    public void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        frameController = FindObjectOfType<FrameController>();

        gameStatus.SetLevelText();
        Reset();
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        playingTime = (int)(Time.time - startingTime);
        if (isWorking)
            gameStatus.SetTimeText(playingTime);

    }

    private void Reset()
    {
        frameController.ResetFrame();
        startingTime = Time.time;
        isWorking = true;
        gameStatus.SetLevelText();
        separatedPaddle.SetActive(false);
    }

    public void CountBlocks()
    {
        breakableBlocks++;
        //Debug.Log("++ : " + breakableBlocks + " Blocks");
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        //Debug.Log("-- : " + breakableBlocks + " Blocks");
        gameStatus.AddtoScore();
        if (breakableBlocks <= 0)
        {
            StopWorking();
            frameController.DropWinFrame();
        }
    }

    public void StopWorking()
    {
        isWorking = false;
        foreach (Ball ball in FindObjectsOfType<Ball>())
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public bool IsLevelWorking()
    {
        return isWorking;
    }

    public int GetBallNumber()
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
        if (GetBallNumber() <= 0)
        {
            AudioSource.PlayClipAtPoint(
                loseAudio, Camera.main.transform.position);
            frameController.DropLoseFrame();
            StopWorking();
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
        paddle.SetActive(false);
        separatedPaddle.SetActive(true);
        yield return new WaitForSeconds(duration);
        paddle.SetActive(true);
        separatedPaddle.SetActive(false);
    }

    public void TriggerGoodFortuneSquareSound()
    {
        AudioSource.PlayClipAtPoint(
            goodFortuneSquareSound, Camera.main.transform.position);
    }

    public void TriggerBadFortuneSquareSound()
    {
        AudioSource.PlayClipAtPoint(
            goodFortuneSquareSound, Camera.main.transform.position);
    }

    public void ResetSizeOfAllBalls(float sizeX, float sizeY, float sizeZ)
    {
        foreach (Ball ball in FindObjectsOfType<Ball>())
            ball.transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
    }
}
