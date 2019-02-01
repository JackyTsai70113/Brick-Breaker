using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FortuneSquare : MonoBehaviour
{

    //cached reference
    [SerializeField] float biggerPaddleSizeScaleX;
    [SerializeField] float smallerPaddleSizeScaleX;
    [SerializeField] float biggerBallSizeScale;
    [SerializeField] float smallerBallSizeScale;
    [SerializeField] float speed;

    // cached reference
    Ball ball;
    Paddle paddle;
    Level level;
    //AudioSource myAudioSource;
    [SerializeField] TextMeshPro fortuneNumberText;

    // state variables
    private int fortuneNumber;
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        level = FindObjectOfType<Level>();
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);

        //myAudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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
            || other.gameObject.tag == "Fortune Square")
        {

        }
        else
        {
            Debug.LogError("Fortune Square collider with " + other.gameObject.tag);
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
        level = FindObjectOfType<Level>();
        switch (fortuneNumber)
        {
            case 0:
                biggerPaddleSizeScaleX = 1.5f;
                paddle.ChangePaddleScaleX(biggerPaddleSizeScaleX);
                break;
            case 1:
                smallerPaddleSizeScaleX = 0.5f;
                paddle.ChangePaddleScaleX(smallerPaddleSizeScaleX);
                break;
            case 2:            
                biggerPaddleSizeScaleX = 1.5f;
                ball.ChangeBallScale(biggerBallSizeScale);
                break;
            case 3:
                smallerPaddleSizeScaleX = 0.5f;
                ball.ChangeBallScale(smallerBallSizeScale);
                break;
            case 4:
                ball.MultiBall();
                break;
            case 5:
                level.MakePaddleSeparated(true);
                break;
            default:
                Debug.Log("Nothing.");
                break;
        }
    }


}
