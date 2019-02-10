using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameStatus gameStatus = FindObjectOfType<GameStatus>();
        gameStatus.SetGameCanvas(false);
        gameStatus.ResetScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
