using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FortuneSquare : MonoBehaviour
{

    //cached reference
    [SerializeField] float duration;
    [SerializeField] float biggerPaddleSizeScaleX;
    [SerializeField] float smallerPaddleSizeScaleX;
    [SerializeField] float biggerBallSizeScale;
    [SerializeField] float smallerBallSizeScale;
    [SerializeField] float speed;

    // cached reference]
    Level level;

    // state variables
    private int fortuneNumber;
    void Start()
    {
        level = FindObjectOfType<Level>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (level.IsLevelWorking() == false)
            Destroy(gameObject);
        if (other.gameObject.tag == "Paddle"
            || other.gameObject.tag == "Separated Paddle")
        {
            TriggerFortune();
        }
        else if (other.gameObject.tag == "Lose Bottom Collider")
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Breakable"
            || other.gameObject.tag == "Unbreakable"
            || other.gameObject.tag == "Ball"
            || other.gameObject.tag == "Fortune Square"
            || other.gameObject.tag == "Collider")
        {

        }
        else
        {
            Debug.LogError("Fortune Square collider with " + other.gameObject.transform.position);
            Debug.LogError(other.gameObject.name);
        }

    }

    public void SetFortuneNumber(int fortuneNumber)
    {
        if (fortuneNumber >= GetComponent<SpriteLoader>().GetFortuneSquareSpritesLength())
        {
            Destroy(gameObject);
            return;
        }

        this.fortuneNumber = fortuneNumber;
        Debug.Log(" " + fortuneNumber + " " + GetComponent<SpriteLoader>().GetFortuneSquareSpritesLength());
        GetComponent<SpriteRenderer>().sprite = 
            GetComponent<SpriteLoader>().GetImage(fortuneNumber);
    }

    private void TriggerFortune()
    {
        switch (fortuneNumber)
        {
            case 0:
                level.TriggerGoodFortuneSquareSound();
                StartCoroutine(FindObjectOfType<Paddle>().
                    ChangeScaleX(biggerPaddleSizeScaleX, duration));
                break;
            case 1:
                level.TriggerBadFortuneSquareSound();
                StartCoroutine(FindObjectOfType<Paddle>().
                    ChangeScaleX(smallerPaddleSizeScaleX, duration));
                break;
            case 2:
                level.TriggerGoodFortuneSquareSound();
                foreach (Ball ball in FindObjectsOfType<Ball>())
                    ball.CheckForChangingScale(biggerBallSizeScale, duration);
                break;
            case 3:
                level.TriggerBadFortuneSquareSound();
                foreach (Ball ball in FindObjectsOfType<Ball>())
                   ball.CheckForChangingScale(smallerBallSizeScale, duration);
                break;
            case 4:
                Ball[] balls = FindObjectsOfType<Ball>();
                if (balls.Length >= 9)
                    break;
                level.TriggerGoodFortuneSquareSound();
                for (int i = 0; i < 3 && i < balls.Length;i++)
                {
                    balls[i].MultiBall();
                }
                break;
            case 5:
                level.TriggerBadFortuneSquareSound();
                level.CheckForSeparatingPaddle(duration);
                break;
            default:
                Debug.Log("Nothing.");
                break;
        }
        Destroy(gameObject);
    }


}
