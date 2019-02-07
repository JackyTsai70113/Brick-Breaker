using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour {
    // config params
    public float xPush;
    public float yPush;

    //Cached component references
    public GameObject ballPrefab;
    float sizeX;
    float sizeY;
    float sizeZ;
    Rigidbody2D myRigidbody2D;
    public Level level;
    Transform paddle;

    // state variables
    public AudioClip paddleCollisionAudio;
    Coroutine changeScaleCoroutine;
    Vector2 paddleToBallVector;
    bool hasStarted;
    float velocityMagnitude;

    void Start()
    {
        sizeX = 1.5f;
        sizeY = 1.5f;
        sizeZ = 1f;
        level = GetComponentInParent<Level>();
        level.AddBallNumber();
        paddle = level.paddle.transform;     
        paddleToBallVector = 
            transform.position - paddle.transform.position;
        myRigidbody2D = GetComponent<Rigidbody2D>();
        velocityMagnitude = new Vector2(xPush, yPush).magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (level.IsLevelWorking())
        {
            if (!hasStarted)
            {
                LockBallToPaddle();
                LauchOnMouseClick();
            }
            else if (Mathf.Abs(myRigidbody2D.velocity.x) < 2)
            {
                myRigidbody2D.velocity +=
                    new Vector2(1, 0) * Mathf.Sign(myRigidbody2D.velocity.x);
            }
            else if (Mathf.Abs(myRigidbody2D.velocity.y) < 2)
            {
                myRigidbody2D.velocity +=
                    new Vector2(0, 1) * Mathf.Sign(myRigidbody2D.velocity.y);
            }
            else if (myRigidbody2D.velocity.magnitude < velocityMagnitude)
                myRigidbody2D.velocity *= velocityMagnitude / myRigidbody2D.velocity.magnitude;
            else if (myRigidbody2D.velocity.magnitude > 2 * velocityMagnitude)
                myRigidbody2D.velocity *= velocityMagnitude / myRigidbody2D.velocity.magnitude;
        }
        else
            myRigidbody2D.velocity = Vector2.zero;

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
        //Debug.Log("kk" + paddlePos + " " + transform.position);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted && ( 
            collision.gameObject.tag == "Paddle" ||
            collision.gameObject.tag == "Separated Paddle"))
            AudioSource.PlayClipAtPoint(
                paddleCollisionAudio, Camera.main.transform.position);
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
            (ballPrefab, transform.position, transform.rotation, level.balls.transform);
        ballObject.name = "Ball";
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
