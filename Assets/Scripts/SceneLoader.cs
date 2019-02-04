using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // cached reference
    GameStatus gameStatus;
    FrameController frame;

    private void Start()
    {
    }
    public void ReLoadScene()
    {
        FindObjectOfType<GameStatus>().SetCurrentScoreZero();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = 
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
            
    }
    public void LoadIntroScene()
    {
        Destroy(FindObjectOfType<GameStatus>());
        SceneManager.LoadScene(0);
    }
    public void QuitApplication()
    {
        Application.Quit();
    }

}
