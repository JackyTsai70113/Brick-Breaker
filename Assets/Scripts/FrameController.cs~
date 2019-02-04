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
    float posX0;
    float posY0;
    float posY1;
    Vector2 target;
    [SerializeField] bool isWinFrameActive;     
    [SerializeField] bool isLoseFrameActive;

    private void Start()
    {
        float canvasHeight = GetComponent<RectTransform>().rect.height;
        float frameHeight = winFrame.GetComponent<RectTransform>().rect.height;
        float canvasLocalScaleY = GetComponent<RectTransform>().localScale.y;
        posX0 = winFrame.transform.position.x;
        posY0 = (canvasHeight + frameHeight / 2) * canvasLocalScaleY;
        posY1 = canvasHeight / 2 * canvasLocalScaleY;
        target = new Vector2(posX0, posY1);
        ResetFrame();
    }

    public void ResetFrame()
    {
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
            Debug.Log(activeFrame.name
                + activeFrame.transform.position
                + target);
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
