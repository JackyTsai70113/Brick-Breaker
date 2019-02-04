using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    //cached reference
    public AudioClip audioClip;
    FrameController frameController;

    Level level;
    void Start()
    {
        frameController = FindObjectOfType<FrameController>();
        level = FindObjectOfType<Level>();
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            level.MinusBallNumber();
            if (level.GetBallNumber() <= 0)
            {
                AudioSource.PlayClipAtPoint(
                    audioClip, Camera.main.transform.position);
                frameController.DropLoseFrame();
                level.StopWorking();
            }
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Fortune Square")
        {
            Destroy(other.gameObject);
        }
        else
        {
            Debug.LogError("Lose Collider collide with " + other.gameObject.tag);
        }
    }
}
