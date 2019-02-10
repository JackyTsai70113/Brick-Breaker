using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrameController : MonoBehaviour {

    // config parameter
    [SerializeField] float speed;

    //cached reference

    [SerializeField] GameObject winFrame;
    [SerializeField] GameObject loseFrame;
    GameObject activeFrame;

    // state variables
    float step;
    public float posX0;
    public float posY0;
    public float posY1;
    public float posX;
    public float posY;
    Vector2 target;

    private void Start()
    {
    }

    public void ResetFrame()
    {
        float frameHeight = loseFrame.GetComponent<RectTransform>().rect.height;
        posX0 = loseFrame.transform.localPosition.x;
        posY0 = frameHeight *  2f;
        target = new Vector2(posX0, 0);
        winFrame.transform.localPosition = new Vector2(posX0, posY0);
        loseFrame.transform.localPosition = new Vector2(posX0, posY0);
    }

    // Update is called once per frame
    private void Update ()
    {
        DropFrame();
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
