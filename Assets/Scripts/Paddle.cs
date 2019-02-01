using UnityEngine;

public class Paddle : MonoBehaviour
{

    // config parameter
    [SerializeField] float screenWidthInUnits = 24f;
    [SerializeField] float minX = -10f;
    [SerializeField] float maxX = 10f;

    //cached reference
    [SerializeField] float paddleSizeX;
    [SerializeField] float paddleSizeY;
    [SerializeField] float paddleSizeZ;
    [SerializeField] AudioClip goodFortuneSquareSound;
    [SerializeField] AudioClip badFortuneSquareSound;

    // state variables
    [SerializeField] bool isAutoPlayEnabled;
    Ball ball;
    Level level;
    [SerializeField] float fortuneTimeLength;
    [SerializeField] float paddleScaleXChangeStartingTime;
    [SerializeField] bool ifPaddleScaleXChange;

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
        fortuneTimeLength = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (level.IsLevelWorking())
        {
            transform.position = new Vector2
                (Mathf.Clamp(PaddlePosX(isAutoPlayEnabled), minX, maxX),
                 transform.position.y);
            if (ifPaddleScaleXChange && 
                Time.time - paddleScaleXChangeStartingTime >= fortuneTimeLength)
            {
                ifPaddleScaleXChange = false;
                transform.localScale = new Vector3
                    (paddleSizeX, paddleSizeY, paddleSizeZ);
            }
        }
        else if (!level.IsLevelWorking())
        {
            transform.position = new Vector2
                (transform.position.x, transform.position.y);
        }
    }

    //Paddle is auto or not.
    private float PaddlePosX(bool isPaddleAuto)
    {
        if (isPaddleAuto)
        {
            return ball.transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits
            - screenWidthInUnits / 2;
        }
    }

    public void ChangePaddleScaleX(float PaddleSizeScaleX)
    {
        ifPaddleScaleXChange = true;
        paddleScaleXChangeStartingTime = Time.time;
        transform.localScale = new Vector3
            (paddleSizeX * PaddleSizeScaleX, paddleSizeY, paddleSizeZ);
        if (PaddleSizeScaleX > 1)
        {
            level.playSoundEffect("good");
        }
        else if (PaddleSizeScaleX < 1)
        {
            level.playSoundEffect("bad");
        }
    }
}