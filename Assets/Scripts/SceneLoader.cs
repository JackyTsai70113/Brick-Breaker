using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour 
{
    // cached reference
    public AudioClip ButtonClickAudio;
    public GameStatus gameStatus;

    // state variables
    int currentSceneIndex;

    public void ReLoadScene()
    {
        TriggerButtonClickAudio();
        gameStatus.ResetScore();
        gameStatus.SetScoreText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReplayLevel()
    {
        TriggerButtonClickAudio();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextScene()
    {
        TriggerButtonClickAudio();
        currentSceneIndex =
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFinalScene()
    {
        TriggerButtonClickAudio();
        currentSceneIndex =
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(4);
    }

    public void LoadIntroScene()
    {
        TriggerButtonClickAudio();
        gameStatus = FindObjectOfType<GameStatus>();
        SceneManager.LoadScene(0);
        gameStatus.ResetScore();
    }

    public void QuitApplication()
    {
        TriggerButtonClickAudio();
        Application.Quit();
    }

    public int GetCurrentSceneIndex()
    {
        return currentSceneIndex;
    }

    private void TriggerButtonClickAudio()
    {
        AudioSource.PlayClipAtPoint(
            ButtonClickAudio, Camera.main.transform.position);
    }
}