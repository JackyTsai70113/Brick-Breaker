using System;
using System.Collections;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // cached reference
    public Ball ball;
    public Level level;
    public bool isLevelWorking;

    // config parameter
    public float screenWidthInUnits;
    public float minX;
    public float maxX;

    // state variables
    [SerializeField] float paddleSizeX;
    [SerializeField] float paddleSizeY;
    [SerializeField] float paddleSizeZ;
    Coroutine changeScaleXCoroutine;

    void Start()
    {
        paddleSizeX = transform.localScale.x;
        paddleSizeY = transform.localScale.y;
        paddleSizeZ = transform.localScale.z;
    }

    void Update()
    {
        if (isLevelWorking)
        {
            transform.position = new Vector2(
                Mathf.Clamp(
                    PaddlePosX(level.isAutoPlayEnabled),
                    minX + transform.localScale.x / 2,
                    maxX - transform.localScale.x / 2),
                transform.position.y);
        }
    }

    //Paddle is automove or not.
    private float PaddlePosX(bool isPaddleAuto)
    {
        if (isPaddleAuto)
        {
            if (ball == null)
            {
                ball = level.GetComponentInChildren<Ball>();
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

    public void StartLevel()
    {
        isLevelWorking = true;
    }

    public void StopLevel()
    {
        isLevelWorking = false;
    }
}