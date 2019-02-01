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

    // cached reference
    Ball ball;
    Paddle paddle;
    Level level;
    //AudioSource myAudioSource;
    [SerializeField] TextMeshPro fortuneNumberText;

    // state variables
    private int theFortuneNumber;
    void Start()
    {
        ball = FindObjectOfType<Ball>();
        paddle = FindObjectOfType<Paddle>();
        level = FindObjectOfType<Level>();
        //myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Paddle"
            || collider.gameObject.tag == "Separated Paddle")
        {
            ChooseFortune();
        }
        else if (collider.gameObject.tag == "Lose Bottom Collider")
        {
            Destroy(gameObject);
        }
        else if (collider.gameObject.tag == "Breakable"
            || collider.gameObject.tag == "Unbreakable"
            || collider.gameObject.tag == "Ball"
            || collider.gameObject.tag == "Fortune Square")
        {

        }
        else
        {
            Debug.LogError("Fortune Square collider with " + collider.gameObject.tag);
        }
    }

    public void SetFortuneNumber(int fortuneNumber)
    {
        fortuneNumberText.text = fortuneNumber.ToString();
        theFortuneNumber = fortuneNumber;
    }

    private void ChooseFortune()
    {
        level = FindObjectOfType<Level>();
        switch (theFortuneNumber)
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
