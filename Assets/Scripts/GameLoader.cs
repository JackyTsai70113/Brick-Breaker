using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    //[SerializeField] GameObject gameObject;
    [SerializeField] static List<Sprite> fortuneSquareSprite;
    //[SerializeField] Sprite paddle;

    // Use this for initialization
    void Start () {
        fortuneSquareSprite = new List<Sprite>();
        fortuneSquareSprite.Add(Resources.Load<Sprite>("makePaddleLonger"));   //0
        fortuneSquareSprite.Add(Resources.Load<Sprite>("makePaddleShorter"));  //1
        fortuneSquareSprite.Add(Resources.Load<Sprite>("makeBallBigger"));     //2
        fortuneSquareSprite.Add(Resources.Load<Sprite>("makeBallSmaller"));    //3
        fortuneSquareSprite.Add(Resources.Load<Sprite>("multipleBall"));       //4
        fortuneSquareSprite.Add(Resources.Load<Sprite>("makePaddleSeparated"));//5
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void GetFortuneSquareimage(GameObject g, int n)
    {
        g.GetComponent<SpriteRenderer>().sprite = fortuneSquareSprite[n];
    }

    public static void GetImage(GameObject theFortuneSquare, int fortuneNumber)
    {
        theFortuneSquare.GetComponent<SpriteRenderer>().sprite = fortuneSquareSprite[fortuneNumber];
    }

    public int FSSpriteNumber()
    {
        return fortuneSquareSprite.Count;
    }


}
