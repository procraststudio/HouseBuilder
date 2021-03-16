using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

    public Animator transition;
    public float transitionTime = 1f;
    public void LoadGameScene()
    {
        
        //  SceneManager.LoadScene(1);
        StartCoroutine(LoadLevel());


    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
       // FindObjectOfType<GameSession>().ResetGame();

    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
        
       SceneManager.LoadScene(currentSceneIndex+1);
    }
}


