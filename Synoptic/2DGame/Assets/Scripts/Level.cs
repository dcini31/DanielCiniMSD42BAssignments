using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    //Delays the win scene 
    [SerializeField] float delaySecond = 2f;

    IEnumerator WinningScreen()
    {
        yield return new WaitForSeconds(delaySecond);
        SceneManager.LoadScene("Win");
    }

    public void LoadGame()
    {
        //loads 2DGame Scene
        SceneManager.LoadScene("Game");
        //reset GameSession
        Session gs = FindObjectOfType<Session>();
        if (gs != null)
        {
            gs.ResetGame();
        }
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
