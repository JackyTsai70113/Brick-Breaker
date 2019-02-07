using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    GameStatus gameStatus;
    AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        audioClip = GetComponent<AudioSource>().clip;
        //Debug.Log(gameStatus.GetAudioSource());
        if (gameStatus.GetAudioSource().clip == null ||
            gameStatus.GetAudioSource().clip != audioClip)
        {
            gameStatus.SetAudioClip(audioClip);
        }
    }
}
