﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    // config parameters
	[SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] GameObject fortuneSquareSprite;
    [SerializeField] Sprite[] hitSprites;
    [SerializeField] float speedOfLuckySquare = -3f;

    // cached reference
    Level level;
    GameLoader gameLoader;

    // state variables
    [SerializeField] int timesHit; // TODO only serialized for debug purposes

    // Use this for initialization
    void Start ()
    {
        level = FindObjectOfType<Level>();
        gameLoader = FindObjectOfType<GameLoader>();
        Resources.Load<Sprite>("paddle");
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = 
                hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(gameObject.name + "Missing.");
        }
    }

    private void DestroyBlock()
    {
        PlayBlockDestroySFX();
        level.BlockDestroyed();
        TriggerSparklesVFX();
        TriggerLuckySquare();
        Destroy(gameObject);
    }

    private void PlayBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint
            (breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate
            (blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }

    public void TriggerLuckySquare()
    {
        int fortuneNumber = Random.Range(0, 20);
        if (fortuneNumber < gameLoader.FSSpriteNumber())
        {
            GameObject theFortuneSquare = Instantiate
                (fortuneSquareSprite, transform.position, transform.rotation);
            GameLoader.GetImage(theFortuneSquare, fortuneNumber);
            FindObjectOfType<FortuneSquare>().SetFortuneNumber(fortuneNumber);
            theFortuneSquare.GetComponent<Rigidbody2D>().velocity = new Vector2
                (0f, speedOfLuckySquare);
        }
        
    }
}
