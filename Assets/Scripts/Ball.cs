﻿using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {
    // config params
    public float xPush;
    public float yPush;
    public AudioClip ballSounds;
    public float randomFactor;


    //Cached component references
    public GameObject ballPrefab;
    float sizeX;
    float sizeY;
    float sizeZ;
    Rigidbody2D myRigidbody2D;
    Level level;
    Paddle paddle;

    // state variables
    Coroutine changeScaleCoroutine;
    Vector2 paddleToBallVector;
    bool hasStarted;
    float minVelocity;

    void Start()
    {
        sizeX = 1.5f;
        sizeY = 1.5f;
        sizeZ = 1f;
        level = FindObjectOfType<Level>();
        level.AddBallNumber();

        paddle = FindObjectOfType<Paddle>();       
        paddleToBallVector = 
            transform.position - paddle.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        minVelocity = Mathf.Sqrt(
            Mathf.Pow(xPush, 2) + Mathf.Pow(yPush, 2));
    }

    // Update is called once per frame
    void Update()
    {
        if (level.IsLevelWorking())
            if (!hasStarted)
            {
                LockBallToPaddle();
                LauchOnMouseClick();
            }
            else if (Mathf.Abs(myRigidbody2D.velocity.x) < 1)
            {
                myRigidbody2D.velocity += 
                    new Vector2(1, 0) * Mathf.Sign(myRigidbody2D.velocity.x);
            }
            else if (Mathf.Abs(myRigidbody2D.velocity.y) < 1)
            {
                myRigidbody2D.velocity +=
                    new Vector2(0, 1) * Mathf.Sign(myRigidbody2D.velocity.y);
            }
            else if (myRigidbody2D.velocity.magnitude < minVelocity)
                myRigidbody2D.velocity *= (minVelocity / myRigidbody2D.velocity.magnitude);
    }

    private void LauchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(
        paddle.transform.position.x, 
            paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //f(myRigidbody2D.velocity.magnitude)
        /*Vector2 velocityTweak = new Vector2
            (Random.Range(-randomFactor, randomFactor),
            Random.Range(-randomFactor, randomFactor));
        if (hasStarted)
        {
            AudioSource.PlayClipAtPoint(
                ballSounds, Camera.main.transform.position);
            if (level.IsLevelWorking())
            {
                GetComponent<Rigidbody2D>().velocity += velocityTweak;
            }
        }*/
    }

    public void MultiBall()
    {
        if (gameObject == null)
        {
            return;
        }
        InstantiateBall(Mathf.PI / 6);
        InstantiateBall(-Mathf.PI / 6);
    }

    public void InstantiateBall(float radians)
    {
        Vector2 myVelocity = GetComponent<Rigidbody2D>().velocity;
        GameObject ballObject = Instantiate
            (ballPrefab, transform.position, transform.rotation);
        ballObject.GetComponent<Ball>().SetBallStart();
        ballObject.GetComponent<Rigidbody2D>().velocity =
            Rotate(myVelocity, radians);
        ballObject.transform.localScale = transform.localScale;
    }

    //rotate Vctor2 about z-axis radians
    private Vector2 Rotate(Vector2 v, float radians)
    {
        return new Vector2(
            v.x * Mathf.Cos(radians) - v.y * Mathf.Sin(radians),
            v.y * Mathf.Cos(radians) + v.x * Mathf.Sin(radians));
    }

    public void CheckForChangingScale(float sizeScale, float duration)
    {
        if (changeScaleCoroutine != null)
            StopCoroutine(changeScaleCoroutine);
        changeScaleCoroutine = StartCoroutine(ChangeScale(sizeScale, duration));
    }

    public IEnumerator ChangeScale(float sizeScale, float duration)
    {
        transform.localScale = new Vector3(
            sizeX * sizeScale, sizeY * sizeScale, sizeZ);
        yield return new WaitForSeconds(duration);
        level.ResetSizeOfAllBalls(sizeX, sizeY, sizeZ);

    }

    public void SetBallStart()
    {
        hasStarted = true;
    }
}
