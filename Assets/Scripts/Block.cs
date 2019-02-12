﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // cached reference
    Level level;
    Transform fortuneSquaresTransform;

    // config parameters
    [SerializeField] AudioClip unBreakSound;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] GameObject fortuneSquareSprite;
    [SerializeField] Sprite[] hitSprites;

    // state variables
    [SerializeField] int timesHit; // only serialized for debug purposes
    int fortuneNumber;

    void Start()
    {
        level = FindObjectOfType<Level>();
        fortuneSquaresTransform = level.fortuneSquares.transform;
        CountBreakableBlocks();
        fortuneNumber = Random.Range(0, 15);
        if (fortuneNumber >= 10)
            fortuneNumber = 4;
    }

    private void CountBreakableBlocks()
    {
        if (tag == "Breakable")
        {
            level.CountBlocks();
            level.AddBlockList(gameObject.name, timesHit);
        }
    }

    private void OnCollisionEnter2D(Collision2D Collision)
    {
        if (tag == "Breakable")
            HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        level.AddBlockList(gameObject.name, timesHit);
        if (timesHit == hitSprites.Length + 1)
        {
            gameObject.SetActive(false);
            DestroyBlock();
        }
        else if (timesHit < hitSprites.Length + 1)
        {

            AudioSource.PlayClipAtPoint
                (unBreakSound, Camera.main.transform.position);
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
    }

    private void DestroyBlock()
    {
        TriggerLuckySquare();
        TriggerBlockDestroySFX();
        TriggerSparklesVFX();
        level.BlockDestroyed();
        Destroy(gameObject);
    }

    private void TriggerBlockDestroySFX()
    {
        AudioSource.PlayClipAtPoint
            (breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate
            (blockSparklesVFX, transform.position, 
            transform.rotation);
        Destroy(sparkles, 0.5f);
    }

    private void TriggerLuckySquare()
    {
        GameObject fortuneSquare = Instantiate(
            fortuneSquareSprite, transform.position, 
            Quaternion.identity, fortuneSquaresTransform);
        fortuneSquare.
            GetComponent<FortuneSquare>().SetFortuneNumber(fortuneNumber);
        fortuneSquare.GetComponent<FortuneSquare>().SetLevel(level);
        fortuneSquare.GetComponent<FortuneSquare>().GetSpeed();
    }
}