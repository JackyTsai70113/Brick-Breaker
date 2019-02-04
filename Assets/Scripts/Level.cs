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
    private float playingTime;
    private bool isWorking;
    public int ballNumber;
    Coroutine SeparatePaddleCoroutine;

    // cached reference
    GameStatus gameStatus;
    FrameController frameController;
    public GameObject paddle;
    public GameObject separatedPaddle;
    public AudioClip goodFortuneSquareSound;
    public AudioClip badFortuneSquareSound;

    public void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        frameController = FindObjectOfType<FrameController>();

        frameController.ResetFrame();
        startingTime = Time.time;
        isWorking = true;
        gameStatus.SetLevelText();
        separatedPaddle.SetActive(false);
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        playingTime = Time.time - startingTime;
        if (isWorking)
            gameStatus.SetTimeText(playingTime);

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
            StopWorking();
            frameController.DropWinFrame();
        }
    }

    public void StopWorking()
    {
        isWorking = false;
        foreach (Ball ball in FindObjectsOfType<Ball>())
            ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        foreach (FortuneSquare fs in FindObjectsOfType<FortuneSquare>())
            fs.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
