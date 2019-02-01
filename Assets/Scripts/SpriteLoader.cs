using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    [SerializeField] static List<Sprite> fortuneSquareSprites;

    // Use this for initialization
    void Start () {
    }

    public Sprite GetImage(int fortuneNumber)
    {
        return fortuneSquareSprites[fortuneNumber];
    }

    public int GetFortuneSquareSpritesLength()
    {
        LoadSprites();
        return fortuneSquareSprites.Count;
    }

    private void LoadSprites()
    {
        fortuneSquareSprites = new List<Sprite>
        {
            Resources.Load<Sprite>("makePaddleLonger"),   //0
            Resources.Load<Sprite>("makePaddleShorter"),  //1
            Resources.Load<Sprite>("makeBallBigger"),     //2
            Resources.Load<Sprite>("makeBallSmaller"),    //3
            Resources.Load<Sprite>("multipleBall"),       //4
            Resources.Load<Sprite>("makePaddleSeparated") //5
        };
    }
}