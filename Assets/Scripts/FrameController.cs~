using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FrameController : MonoBehaviour {

    // config parameter
    [SerializeField] float speed = 400f;

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
        posX0 = winFrame.transform.position.x;
        ResetFrame();
    }

    public void ResetFrame()
    {
        float canvasHeight = GetComponent<RectTransform>().rect.height;
        float frameHeight = winFrame.GetComponent<RectTransform>().rect.height;
        float canvasLocalScaleY = GetComponent<RectTransform>().localScale.y;
        posY0 = (canvasHeight + frameHeight / 2) * canvasLocalScaleY;
        winFrame.transform.position = new Vector2(posX0, posY0);
        loseFrame.transform.position = new Vector2(posX0, posY0);
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
            float canvasHeight = GetComponent<RectTransform>().rect.height;
            float canvasLocalScaleY = GetComponent<RectTransform>().localScale.y;
            posY1 = canvasHeight / 2 * canvasLocalScaleY;
            target = new Vector2(posX0, posY1);
            posX = activeFrame.transform.position.x;
            posY = activeFrame.transform.position.y;
            if (Vector2.Distance(activeFrame.transform.position, target) > 0.001)
            {
                step = speed * Time.deltaTime;
                activeFrame.transform.position = Vector2.MoveTowards
                    (activeFrame.transform.position, target, step);
            }
            else
                activeFrame = null;
        }
    }
}
