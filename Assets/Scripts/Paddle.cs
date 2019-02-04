using System;
using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // config parameter
    public float screenWidthInUnits;
    public float minX;
    public float maxX;

    //cached reference
    [SerializeField] float paddleSizeX;
    [SerializeField] float paddleSizeY;
    [SerializeField] float paddleSizeZ;

    // state variables
    Coroutine changeScaleXCoroutine;
    public bool isAutoPlayEnabled;
    Ball ball;
    Level level;

    void Start()
    {
        paddleSizeX = transform.localScale.x;
        paddleSizeY = transform.localScale.y;
        paddleSizeZ = transform.localScale.z;
        if (gameObject.tag == "Paddle")
        {
            Sprite paddle = Resources.Load<Sprite>("paddle");
            gameObject.GetComponent<SpriteRenderer>().sprite = paddle;
        }
        ball = FindObjectOfType<Ball>();
        level = FindObjectOfType<Level>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level.IsLevelWorking())
        {
            transform.position = new Vector2(
                Mathf.Clamp(
                    PaddlePosX(isAutoPlayEnabled),
                    minX + transform.localScale.x / 2,
                    maxX - transform.localScale.x / 2),
                transform.position.y);
        }
    }

    //Paddle is auto or not.
    private float PaddlePosX(bool isPaddleAuto)
    {
        if (isPaddleAuto)
        {
            if (ball == null)
            {
                ball = FindObjectOfType<Ball>();
            }
            return ball.transform.position.x;
        }

        else
            return Input.mousePosition.x / Screen.width * screenWidthInUnits
                - screenWidthInUnits / 2;
    }

    public void CheckForChangingScaleX(float sizeScale, float duration)
    {
        if (changeScaleXCoroutine != null)
            StopCoroutine(changeScaleXCoroutine);
        changeScaleXCoroutine = StartCoroutine(ChangeScaleX(sizeScale, duration));
    }

    public IEnumerator ChangeScaleX(float PaddleSizeScaleX, float duration)
    {
        transform.localScale = new Vector3
            (paddleSizeX * PaddleSizeScaleX, paddleSizeY, paddleSizeZ);
        yield return new WaitForSeconds(duration);
        transform.localScale = new Vector3
                    (paddleSizeX, paddleSizeY, paddleSizeZ);
    }
}