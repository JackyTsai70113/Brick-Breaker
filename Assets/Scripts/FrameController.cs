using UnityEngine;

public class FrameController : MonoBehaviour 
{
    // cached reference
    [SerializeField] GameObject winFrame;
    [SerializeField] GameObject loseFrame;
    GameObject activeFrame;

    // config parameter
    [SerializeField] float speed;

    // state variables
    float step;
    public float posX0;
    public float posY0;
    public float posY1;
    public float posX;
    public float posY;
    Vector2 target;

    // Update is called once per frame
    void Update()
    {
        DropFrame();
    }

    public void ResetFrame()
    {
        float frameHeight = GetComponent<RectTransform>().rect.height;
        posX0 = loseFrame.transform.localPosition.x;
        posY0 = frameHeight;
        target = new Vector2(posX0, 0);
        winFrame.transform.localPosition = new Vector2(posX0, posY0);
        loseFrame.transform.localPosition = new Vector2(posX0, posY0);
    }
   
    public void DropLoseFrame()
    {
        activeFrame = loseFrame;
    }

    public void DropWinFrame()
    {
        activeFrame = winFrame;
    }

    private void DropFrame()
    {
        if (activeFrame != null)
        {
            if (Vector2.Distance(activeFrame.transform.localPosition, target) > 0.1)
            {
                step = speed * Time.deltaTime;
                activeFrame.transform.localPosition = Vector2.MoveTowards
                    (activeFrame.transform.localPosition, target, step);
            }
            else
                activeFrame = null;
        }
    }
}