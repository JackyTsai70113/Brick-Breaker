using System.Collections.Generic;
using UnityEngine;

public class FortuneSquare : MonoBehaviour
{
    // cached reference
    public List<Sprite> fortuneSquareSprites;
    public SpriteRenderer FSSprite;
    Level level;

    // config parameters
    [SerializeField] float duration;
    [SerializeField] float biggerPaddleSizeScaleX;
    [SerializeField] float smallerPaddleSizeScaleX;
    [SerializeField] float biggerBallSizeScale;
    [SerializeField] float smallerBallSizeScale;
    [SerializeField] float speed;

    // state variables
    private int fortuneNumber;

    public void GetSpeed()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!level.IsLevelWorking())
            Destroy(gameObject);
        if (other.gameObject.tag == "Paddle"
            || other.gameObject.tag == "Separated Paddle")
        {
            TriggerFortune();
        }
        else if (other.gameObject.tag == "Lose Bottom Collider")
            Destroy(gameObject);
        else if (!(other.gameObject.tag == "Breakable"
            || other.gameObject.tag == "Unbreakable"
            || other.gameObject.tag == "Ball"
            || other.gameObject.tag == "Fortune Square"
            || other.gameObject.tag == "Collider"))
        {
            Debug.LogError("Fortune Square collider with " + 
                other.gameObject.transform.position);
            Debug.LogError(other.gameObject.name);
        }

    }

    public void SetFortuneNumber(int fortuneNumber)
    {
        if (fortuneNumber >= fortuneSquareSprites.Count)
        {
            Destroy(gameObject);
            return;
        }
        this.fortuneNumber = fortuneNumber;
        FSSprite.sprite = fortuneSquareSprites[fortuneNumber];
    }

    private void TriggerFortune()
    {
        switch (fortuneNumber)
        {
            case 0:
                level.TriggerGoodFortuneSquareSound();
                StartCoroutine(level.activePaddle.GetComponent<Paddle>().
                    ChangeScaleX(biggerPaddleSizeScaleX, duration));
                break;
            case 1:
                level.TriggerBadFortuneSquareSound();
                StartCoroutine(level.activePaddle.GetComponent<Paddle>().
                    ChangeScaleX(smallerPaddleSizeScaleX, duration));
                break;
            case 2:
                level.TriggerGoodFortuneSquareSound();
                foreach (Ball ball in level.balls.GetComponentsInChildren<Ball>())
                    ball.CheckForChangingScale(biggerBallSizeScale, duration);
                break;
            case 3:
                level.TriggerBadFortuneSquareSound();
                foreach (Ball ball in level.balls.GetComponentsInChildren<Ball>())
                   ball.CheckForChangingScale(smallerBallSizeScale, duration);
                break;
            case 4:
                Ball[] balls = level.balls.GetComponentsInChildren<Ball>();
                if (balls.Length >= 9)
                    break;
                level.TriggerGoodFortuneSquareSound();
                for (int i = 0; i < 3 && i < balls.Length && balls[i] !=null; i++)
                    balls[i].MultiBall();
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

    public void SetLevel(Level level)
    {
        this.level = level;
    }
}