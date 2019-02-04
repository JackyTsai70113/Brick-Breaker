using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    // config parameters
    [SerializeField] AudioClip unBreakSound;
    [SerializeField] AudioClip breakSound;
    [SerializeField] ParticleSystem blockSparklesVFX;
    [SerializeField] GameObject fortuneSquareSprite;
    [SerializeField] Sprite[] hitSprites;

    // cached reference
    Level level;

    // state variables
    [SerializeField] int timesHit; // only serialized for debug purposes
    int fortuneNumber;
    // Use this for initialization
    void Start()
    {
        level = FindObjectOfType<Level>();
        //Resources.Load<Sprite>("paddle");
        CountBreakableBlocks();
        fortuneNumber = Random.Range(2, 5);
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
            HandleHit();
    }

    private void HandleHit()
    {
        timesHit++;
        if (timesHit > hitSprites.Length)
            DestroyBlock();
        else
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
        ParticleSystem sparkles = Instantiate
            (blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
    }

    private void TriggerLuckySquare()
    {
        GameObject fortuneSquare = Instantiate(
            fortuneSquareSprite, transform.position, Quaternion.identity);
        fortuneSquare.
            GetComponent<FortuneSquare>().SetFortuneNumber(fortuneNumber);
    }
}