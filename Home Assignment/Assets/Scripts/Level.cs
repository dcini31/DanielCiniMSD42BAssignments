using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    //Delays the game over scene 
    [SerializeField] float delaySeconds = 2f;
    //Delays the win scene 
    [SerializeField] float delaySecond = 1f;

    IEnumerator WinningScreen()
    {
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene("WinScene");
    }

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delaySeconds);
        SceneManager.LoadScene("GameOver");
    }
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        //loads 2DCarGame Scene
        SceneManager.LoadScene("2DCarGame");
        //reset GameSession
        GameSession gs = FindObjectOfType<GameSession>();
        if (gs != null)
        {
           gs.ResetGame();
        }
    }

    public void GameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void Win()
    {
        StartCoroutine(WinningScreen());
    }

    public void QuitGame()
    {
        //Quits Scene
        Application.Quit();
    }
}
