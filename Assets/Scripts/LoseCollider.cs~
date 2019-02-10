using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    //cached reference
    public Level level;

    void Start()
    {
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            level.MinusBallNumber();
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
