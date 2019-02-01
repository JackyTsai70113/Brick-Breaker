using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    //cached reference
    Frame theFrame;
    Level level;
    void Start()
    {
        theFrame = FindObjectOfType<Frame>();
        level = FindObjectOfType<Level>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ball")
        {
            level.MinusBallNumber();
            if (level.ReturnBallNumber() <= 0)
            {
                collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                GetComponent<AudioSource>().Play();
                theFrame.DropLoseFrame();
                level.StopLevelWorking();
            }
            else if (level.ReturnBallNumber() > 1)
            {
                Destroy(collider.gameObject);
            }
        }
        else if(collider.gameObject.tag == "Fortune Square")
        {
            Destroy(collider.gameObject);
        }
        else
        {
            Debug.LogError("Lose Collider collider with " + collider.gameObject.tag);
        }
    }
}
