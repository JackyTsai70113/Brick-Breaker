using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    // cached reference

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
        if (currentSceneIndex == 3)
            Destroy(FindObjectOfType<GameStatus>());
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
