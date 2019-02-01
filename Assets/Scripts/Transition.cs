using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

    private float step;
    private float speed = 80f;
    private float posX0;
    private float posY0;
    public GameObject Left;
    public GameObject Right;
    void Start () {
        step = speed * Time.deltaTime;
        posX0 = Left.GetComponent<Rigidbody2D>().position.x;
        posY0 = posX0 * 6f / 4f;
        Left.transform.position = new Vector2(posX0, posY0);
        Right.transform.position = new Vector2(3*posX0, posY0);
    }
	
	// Update is called once per frame
	void Update () {

        Left.transform.position = Vector2.MoveTowards
            (Left.transform.position, new Vector2(-posX0, posY0), step);
        Right.transform.position = Vector2.MoveTowards
            (Right.transform.position, new Vector2(5*posX0, posY0), step);
        //Debug.Log(Left.GetComponent<Rigidbody2D>().position);
        //Debug.Log(Right.GetComponent<Rigidbody2D>().position);
    }
}
