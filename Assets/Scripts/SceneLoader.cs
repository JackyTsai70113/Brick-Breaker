using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // cached reference
    GameStatus gameStatus;
    Frame frame;

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        //GetComponent<AudioSource>().Play();
    }
    public void ReLoadScene()
    {
        gameStatus.setCurrentScoreZero();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    public void LoadNextLevel()
    {
        int currentSceneIndex = 
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        if (FindObjectsOfType<GameStatus>().Length >= 1)
        {
            //gameStatus.ResetLevel();
        }
            
    }
    public void LoadIntroScene()
    {
        SceneManager.LoadScene(0);
        gameStatus.ResetGame();
    }
    public void QuitApplication()
    {
        Application.Quit();
    }

}
