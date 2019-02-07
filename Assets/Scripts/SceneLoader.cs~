using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

    public AudioClip ButtonClickAudio;
    // cached reference
    GameStatus gameStatus;

    int currentSceneIndex;

    private void Start()
    {
        gameStatus = GetComponentInParent<GameStatus>();
    }

    public void ReLoadScene()
    {
        TriggerButtonClickAudio();
        gameStatus.ResetScoreText();
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
        currentSceneIndex =
            SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
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
